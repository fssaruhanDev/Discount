using Discount.BLL.BASE;
using Discount.BLL.DTO.User;
using Discount.Data.ORM.Context;
using Discount.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Discount.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;
        protected EntityConnection _db;
        private readonly ServicesProvider servicesProvider;

        public ProductController(EntityConnection entityConnection, ILogger<UserController> logger, IConfiguration configuration)
        {
            _db = entityConnection;
            _logger = logger;
            _configuration = configuration;
            servicesProvider = new ServicesProvider(_db);
        }

        [HttpGet]
        [Authorize]
        [Route("getproducts")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var data = await servicesProvider.ProductService.GetAll();
                if (data.Code == "200")
                {
                   
                    return Ok(data.Product);
                }
                else
                {
                    return new ObjectResult("Forbidden") { StatusCode = 403 };
                }
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.ToString()) { StatusCode = 404 };
            }


        }

        [HttpGet]
        [Authorize]
        [Route("detail/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var data = await servicesProvider.ProductService.GetProduct(id);
                if (data.Code == "200")
                {
                    return Ok(data.Product[0]);
                }
                else
                {
                    return new ObjectResult("Forbidden") { StatusCode = 403 };
                }
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.ToString()) { StatusCode = 404 };
            }


        }

    }

}
