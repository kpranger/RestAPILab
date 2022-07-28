using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPILab.Models;

namespace RestAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public NorthwindContext northwindContext = new NorthwindContext();

        [HttpGet("GetAllCustomers")]
        public List<Customer> GetAll()
        {
            return northwindContext.Customers.ToList();
        }

        [HttpGet("GetCustomerByCompanyName")]
        public Customer GetCustomerByCompanyName(string CompanyName)
        {
            return northwindContext.Customers.FirstOrDefault(c => c.CompanyName == CompanyName);
        }


        [HttpPost("AddCustomer")]
        public Customer AddCustomer(string CompanyName, string ContactName, string ContactTitle, string Address, string City, string Region, string PostalCode, string Country, string Phone, string Fax)
        {
            Customer newCustomer = new Customer()
            {
                CompanyName = CompanyName,
                ContactName = ContactName,
                ContactTitle = ContactTitle,
                Address = Address,
                City = City,
                Region = Region,
                PostalCode = PostalCode,
                Country = Country,
                Phone = Phone,
                Fax = Fax
            };
            northwindContext.Customers.Add(newCustomer);
            northwindContext.SaveChanges();
            return newCustomer;
        }

    }
}
