using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using VueBlog.Database;
using VueBlog.Models;

namespace VueBlog.Controllers
{
    public class AuthController : ApiController
    {
        private readonly UserStore<IdentityUser> _userStore;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController()
        {
            // inject it
            var ctx = new BlogDbContext();
            _userStore = new UserStore<IdentityUser>(ctx);
            _userManager = new UserManager<IdentityUser>(_userStore);
        }

        public async Task<IHttpActionResult> RegisterNewUser(RegisterModel registerModel)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    var result = await _userManager.CreateAsync(new IdentityUser(registerModel.UserName), registerModel.Password);
                    if (result.Succeeded)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest($"Can't register user with name {registerModel.UserName}. Try another name");
                    }
                }
                else
                {
                    return BadRequest("UserName or Password are invalid");
                }
            }
            catch(Exception e)
            {
                throw;
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<UserApiModel> GetCurrentUser()
        {
            var currentUserName = ((ClaimsPrincipal)this.User).Claims.Single(c => c.Type == "userName").Value;
            var user = await _userStore.FindByNameAsync(currentUserName);

            var model = Mapper.Map<UserApiModel>(user);
            model.IsAdmin = await _userStore.IsInRoleAsync(user, "Admin");

            return model;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _userManager.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
