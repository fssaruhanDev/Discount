using Discount.BLL.BASE;
using Discount.BLL.DTO.User;
using Discount.Data.ORM.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.Controllers
{
    [Route("api/basket")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        protected EntityConnection _db;
        private readonly ServicesProvider servicesProvider;

        public BasketController(EntityConnection entityConnection, ILogger<UserController> logger)
        {
            _db = entityConnection;
            _logger = logger;
            servicesProvider = new ServicesProvider(_db);
        }


        [HttpGet]
        [Authorize]
        [Route("getbasket/{id}")]
        public async Task<IActionResult> GetBasket(int id)
        {
            try
            {
                var _basket = await servicesProvider.BasketService.GetBasket(id);
                if (_basket.Code == "200")
                {

                    return Ok(_basket.Basket);
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
