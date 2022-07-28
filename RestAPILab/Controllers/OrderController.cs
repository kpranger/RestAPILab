using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPILab.Models;

namespace RestAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public NorthwindContext northwindContext = new NorthwindContext();

        [HttpGet("GetOrderByShipVia")]
        public Order GetOrderByShipVia(int shipVia)
        {
            return northwindContext.Orders.FirstOrDefault(s => s.ShipVia == shipVia);
        }

        [HttpGet("GetOrderByShipCountry")]
        public Order GetOrderByShipCountry(string shipCountry)
        {
            return northwindContext.Orders.FirstOrDefault(s => s.ShipCountry == shipCountry);
        }
    }
}
