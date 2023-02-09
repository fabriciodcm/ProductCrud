using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Interfaces.Services;
using ProductApp.Application.Models;
using ProductApp.Domain.Interfaces.Pagination;
using ProductApp.Domain.Interfaces.Repository;
using ProductApp.Domain.Models;
using ProductApp.Domain.Models.Pagination;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApp.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productService) 
        {
            _productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public ActionResult<ProductPagination> Get([FromQuery]int take = 10,[FromQuery] int skip = 0,[FromQuery] string Description = "")
        {
            return Ok(_productService.Filter(take,skip,Description));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ProductDTO> Get(long id)
        {
            if (id <= 0)
                return BadRequest("Invalid argument");

            var product = _productService.Find(id);
            
            if(product != null)
                return Ok(product);

            return NotFound();
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] PostProductDTO productDTO)
        {
            if (productDTO.FabricationDate.HasValue && productDTO.ValidateDate.HasValue 
                    && productDTO.FabricationDate.Value.Date >= productDTO.ValidateDate.Value.Date)
                return BadRequest("Invalid argument - Invalid ValidateDate");

            var Id = _productService.Add(productDTO);
            
            if (Id > 0) {
                var product = _productService.Find(Id);
                return CreatedAtRoute("GetProductById", new { Id = Id }, product);
            }

            return BadRequest("Product not inserted");

        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] PutProductDTO productDTO)
        {
            if (id <= 0 || id != productDTO.Id)
                return BadRequest("Invalid argument - Invalid Id");

            if (productDTO.FabricationDate.HasValue && productDTO.ValidateDate.HasValue
                    && productDTO.FabricationDate.Value.Date >= productDTO.ValidateDate.Value.Date)
                return BadRequest("Invalid argument - Invalid ValidateDate");

            if(_productService.Edit(productDTO))
                return NoContent();

            return BadRequest("Register not updated");
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (id <= 0)
                return BadRequest("Invalid argument - Invalid Id");

            if (_productService.Remove(id))
                return NoContent();

            return BadRequest("Register not deleted");
        }

    }
}
