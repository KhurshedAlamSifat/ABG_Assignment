using BLL.DTOs;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost("Add")]
        public async Task<IActionResult> CreateProduct(ProductDTO product)
        {
            try
            {
                var data = await ProductService.CreateProductAsync(product);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var data = await ProductService.GetAllProductsAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await ProductService.GetProductByIdAsync(id);
                if (data == null) return NotFound();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpPost("{id}/Update")]
        public async Task<IActionResult> UpdateProduct(ProductDTO product)
        {
            try
            {
                var data = await ProductService.UpdateProductAsync(product);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/Delete")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var result = await ProductService.DeleteProductAsync(id);
                if (!result) return NotFound();
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
