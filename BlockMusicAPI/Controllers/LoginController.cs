using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
//Old DLL - Emergency Only !
//using BlockMusicAPI.Models;
using BlockMusicAPI.FreshDbC;
using BlockMusicAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlockMusicAPI.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("AllowCors"), Route("api/[controller]/[action]")]
    [Consumes("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //Old Context - Emergency Only !
        //private readonly BMContext _context;

        private readonly BMContext _context;

        public LoginController(BMContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<Login> LoginVal([FromBody]Login objLogin)
        {
            if (!string.IsNullOrEmpty(objLogin.UserName) && !string.IsNullOrEmpty(objLogin.Password))
            {
                var users = _context.Users.ToList();

                var userToLogin = users.Where(_ => _.UserName == objLogin.UserName).FirstOrDefault();

                if (userToLogin.Password == objLogin.Password)
                    return new Login(userToLogin.UserId, userToLogin.UserName);
                else
                    return NotFound();  
            }
            return BadRequest();
        }

        [HttpGet]
        public ActionResult GetLogins()
        {
            return Ok(_context.Users.ToList());
        }
    }
}