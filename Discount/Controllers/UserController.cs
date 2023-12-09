
using Discount.BLL.BASE;
using Discount.BLL.DTO.User;
using Discount.Data.ORM.Context;
using Discount.Security;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Discount.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;
        protected EntityConnection _db;
        private readonly ServicesProvider servicesProvider;

        public UserController( EntityConnection entityConnection,ILogger<UserController> logger, IConfiguration configuration)
        {
            _db = entityConnection;
            _logger = logger;
            _configuration = configuration;
            servicesProvider = new ServicesProvider(_db);
        }


        // GET: api/values
        [HttpGet]
        [Route("login/username={userName}&password={password}")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            try
            {
                UserDTO user = await servicesProvider.UserServices.Login(userName, password);


                if (user.Code == "200")
                {
                    Token token = TokenHandler.CreateToken(_configuration);
                    token.Name = userName;
                    token.Role = "User";
                    return Ok(token);
                }
                else
                {
                    return new ObjectResult("Forbidden") { StatusCode = 403 };
                }
            }
            catch (Exception ex)
            {
                return Ok(ex.ToString());
            }


        }



    }
}

