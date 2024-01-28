using DotNet7.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet7.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
  
  private LearnDb_Context _dbContext;
  public ProductsController(LearnDb_Context dbContext){
      this._dbContext = dbContext;
  }
  [HttpGet]
  public async Task<ActionResult<List<Product>>> GetAllProducts(){
        
        var productList =await  _dbContext.Products.ToListAsync();
        if(productList != null) return Ok(productList);
        else return Ok("No Products Found");
  }

  [HttpGet("GetById")]
  public async Task<ActionResult<Product>> GetProductsById(Guid productId){

        var product =  _dbContext.Products.Where(x => x.Id == productId).FirstOrDefaultAsync();
        if(product != null) return Ok(await product);
        else return Ok("No Products Found");
  }


  [HttpDelete("GetById")]
  public  ActionResult DeleteProductsById(Guid productId){

        var product =  _dbContext.Products.Where(x => x.Id == productId).FirstOrDefault();
        if(product != null) {
            _dbContext.Products.Remove(product);

            _dbContext.SaveChanges();
            return Ok("Deleted");

        }
        else return Ok("No matching products Found");
  }

    [HttpPost("AddProduct")]
  public  async Task<ActionResult> AddProduct(Product product){

        var matchingProduct = await _dbContext.Products.Where(x => x.Id == product.Id).FirstOrDefaultAsync();
        if(matchingProduct != null) {
            matchingProduct.Name = product.Name;
            matchingProduct.Price = product.Price;
            
         int rowsUpdated =  await _dbContext.SaveChangesAsync();
         if(rowsUpdated > 0){
            return Ok("Existing record updated successfully");
         }
        }
        else{
            var entityEntry = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            if(entityEntry.Entity != null){
                return Ok("New record added successfully");
            }
        }
        return Ok("No matching products Found");
  }

}