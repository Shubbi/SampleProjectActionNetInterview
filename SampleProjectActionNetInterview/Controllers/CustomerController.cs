using BusinessDomain.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProjectActionNetInterview.Models;

namespace SampleProjectActionNetInterview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        ILogger<CustomerController> _logger;

        public CustomerController(IUnitOfWork unitOfWork, ILogger<CustomerController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public List<Customer> GetCustomersFromZipCode(string zipcode)
        {
            return _unitOfWork.Customers.GetCustomersFromZipCode(zipcode).ToList();

        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerModel customerModel)
        {
            var customer = new Customer() { 
                Name = customerModel.Name,
                Zipcode = customerModel.Zipcode
            };

            try
            {
                _unitOfWork.Customers.Add(customer);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Ok(customer);
        }
    }
}
