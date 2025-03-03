﻿using FratSCWeb_Business.Repository.IRepository;
using FratSCWeb_Models;
using Microsoft.AspNetCore.Mvc;

namespace FratSCWeb_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productRepository.GetAll());
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(int? productId)
        {
            if (productId == null || productId == 0)
            {
                return BadRequest(new ErrorModelDTO() { ErrorMessage = "Invalid Id", StatusCode = StatusCodes.Status400BadRequest });
            }
            var product = await _productRepository.Get(productId.Value);
            if (product == null)
            {
                return BadRequest(new ErrorModelDTO() { ErrorMessage = "Invalid Id", StatusCode = StatusCodes.Status404NotFound });
            }
            return Ok(product);
        }

    }
}
