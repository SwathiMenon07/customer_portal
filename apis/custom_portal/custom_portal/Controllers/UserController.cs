using custom_portal.Data;
using custom_portal.models;
using custom_portal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace custom_portal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly AppDbContext userDbContext;
        public UserController(AppDbContext userDbContext) 
        { 
            this.userDbContext = userDbContext;
        }
       
        [HttpGet]
        [Route("username:string;password:string")]
        public async Task<IActionResult>GetUser( string username, string password)
        {
            var user = await userDbContext.portal_userinfo.FirstOrDefaultAsync(x => x.Username == username && x.Password == password) ;
            
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound("Record not found");
        }

        [HttpPost("register")]
        public async Task<IActionResult>AddUser([FromBody] User user)
        {
            user.Id = Guid.NewGuid();
            await userDbContext.portal_userinfo.AddAsync(user);
            await userDbContext.SaveChangesAsync();
           return Ok(new
            {
                Message = "User Registered Successfully"
            });
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Log user)
        {
            if (user.Username == null)
                return BadRequest();
            if(user.Password == null)
                return BadRequest();

            var login= await userDbContext.portal_userinfo.FirstOrDefaultAsync(x => x.Username == user.Username && x.Password == user.Password);
            if (login == null) 
            {
                return NotFound(new {Message="User not found"});
            }

            return Ok(new
            {
                Message = "Login Successful"
            });
        }
       
    }
}