using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using VueBlog.Database;

[assembly: OwinStartup(typeof(VueBlog.Startup))]
namespace VueBlog
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // configure api to camelize names in json responses
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            WebApiConfig.Register(config);
            ConfigureOAuth(app);

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);

            AutoMapperConfig.Configure();
            UnityConfig.ConfigureUnity(config);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            var OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                //AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(10),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }

    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            ClaimsIdentity identity = null;

            using(var dbContext = new BlogDbContext())
            {
                using (var userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(dbContext)))
                {
                    IdentityUser user = await userManager.FindAsync(context.UserName, context.Password);

                    if (user == null)
                    {
                        context.SetError("invalid_grant", "The user name or password is incorrect.");
                        return;
                    }

                    identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("userName", context.UserName));
                    var roles = GetRolesClaim(user, dbContext);
                    identity.AddClaim(new Claim(ClaimTypes.Role, roles));
                    identity.AddClaim(new Claim("userId", user.Id));
                }
            }

            context.Validated(identity);
        }

        private string GetRolesClaim(IdentityUser user, BlogDbContext dbContext)
        {
            var userRolesIds = user.Roles.Select(r => r.RoleId).ToArray();
            var userRoles = dbContext.Roles.Where(r => userRolesIds.Contains(r.Id)).Select(r => r.Name).ToArray();

            return string.Join(",", userRoles);
        }
    }
}
