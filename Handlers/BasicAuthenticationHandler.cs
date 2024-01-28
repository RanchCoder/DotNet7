using System;
using Microsoft.AspNetCore.Authentication;
using System.Text.Encodings.Web;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DotNet7.Handlers;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private LearnDb_Context _dbContext;
    public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, LearnDb_Context dbContext)
     : base(options, logger, encoder, clock)
    {
       _dbContext = dbContext;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if(!Request.Headers.ContainsKey("Authorization")){
            return AuthenticateResult.Fail("Unauthorize Request");
        }

        var _headerValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
        var bytes = Convert.FromBase64String(_headerValue.Parameter ?? null);
        string credentials = Encoding.UTF8.GetString(bytes);
         
        if(!string.IsNullOrEmpty(credentials)){
            string[] array = credentials.Split(":");
            string userName = array[0];
            string password = array[1];
            
            var user = await _dbContext.TblUsers.FirstOrDefaultAsync(x=>x.Name == userName && x.Password == password);

            if(user == null){
               return AuthenticateResult.Fail("Unauthorized");
            }

           var claim=new[]{new Claim(ClaimTypes.Name,userName)};
           var identity=new ClaimsIdentity(claim,Scheme.Name);
           var principal=new ClaimsPrincipal(identity);
           var ticket=new AuthenticationTicket(principal,Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }else{
                return AuthenticateResult.Fail("UnAuthorized");

            }

        //}

        //return AuthenticateResult.Fail("Unauthorized Request");
    }
}

