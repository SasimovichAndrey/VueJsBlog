using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using VueBlog.Database;
using VueBlog.Models;

namespace VueBlog.Controllers
{
    public class AuthController : ApiController
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController()
        {
            var ctx = new BlogDbContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(ctx));
        }

        public async Task<IHttpActionResult> Register(RegisterModel registerModel)
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
