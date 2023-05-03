using BusinessDomain.Entities;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProjectActionNetInterview.Models;

namespace SampleProjectActionNetInterview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        ILogger<ProductController> _logger;

        public ProductController(IUnitOfWork unitOfWork, ILogger<ProductController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Products more than $100 are being called as Expensive
        /// I am being lazy and hardcoded that in the Repo itself
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetExpensiveProducts()
        {
            var products = await _unitOfWork.Products.GetExpensiveProducts();

            return Ok(products);            
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductModel productModel)
        {
            var product = new Product()
            {
                Name = productModel.Name,
                Price = productModel.Price
            };

            try {
                _unitOfWork.Products.Add(product);
                await _unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Ok(product);
        }
    }
}
