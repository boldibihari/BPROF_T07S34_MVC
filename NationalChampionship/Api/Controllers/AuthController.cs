using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NationalChampionship.Data.Models;
using NationalChampionship.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class AuthController : Controller
    {
        IAuthLogic authLogic;

        public AuthController(IAuthLogic authLogic)
        {
            this.authLogic = authLogic;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterViewModel model)
        {
            string result = await authLogic.RegisterUser(model);
            return Ok(new { UserName = result });
        }

        [HttpGet]
        public IEnumerable<IdentityUser> GetAllUser()
        {
            return authLogic.GetAllUser();
        }

        [HttpPut]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                return Ok(await authLogic.LoginUser(model));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
