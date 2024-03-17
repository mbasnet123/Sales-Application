﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using sales_API.data;

namespace sales_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product model)
        {
            await _productRepository.AddProductAsync(model);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetProductList()
        {
            var productList = await _productRepository.GetAllProductAsync();
            return Ok(productList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct([FromRoute] int id, [FromBody] Product model)
        {
            await _productRepository.UpdateProductAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productRepository.DeleteProductAsync(id);
            return Ok();
        }
    }
}
