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
        public async Task<IActionResult> GetCustomersFromZipCode(string zipcode)
        {
            var customers = await _unitOfWork.Customers.GetCustomersFromZipCode(zipcode);

            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerModel customerModel)
        {
            var customer = new Customer() { 
                Name = customerModel.Name,
                Zipcode = customerModel.Zipcode
            };

            try
            {
                _unitOfWork.Customers.Add(customer);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Ok(customer);
        }
    }
}
