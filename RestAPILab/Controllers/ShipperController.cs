using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPILab.Models;

namespace RestAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        public NorthwindContext northwindContext = new NorthwindContext();

        [HttpGet("GetAllShippers")]
        public List<Shipper> GetAll()
        {
            return northwindContext.Shippers.ToList();
        }

        [HttpGet("GetShippersByID")]
        public Shipper GetShippersByID(int id)
        {
            return northwindContext.Shippers.FirstOrDefault(s => s.ShipperId == id);
        }

        [HttpPost("AddShipper")]
        public Shipper AddShipper(int ShipperId, string CompanyName, string Phone)
        {
            Shipper newShipper = new Shipper()
            {
                ShipperId = ShipperId,
                CompanyName = CompanyName,
                Phone = Phone,
            };
        northwindContext.Shippers.Add(newShipper);
        northwindContext.SaveChanges();
        return newShipper;
        }

        [HttpDelete("RemoveShipper")]
        public Shipper RemoveShipper(int ShipperId)
        {
            Shipper removed = northwindContext.Shippers.FirstOrDefault(s => s.ShipperId == ShipperId);
            northwindContext.Shippers.Remove(removed);
            northwindContext.SaveChanges();
            return removed;
        }

    }
}
