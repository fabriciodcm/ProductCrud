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
        public ProductPagination Get([FromQuery]int take = 10,[FromQuery] int skip = 0,[FromQuery] string Description = "")
        {
            return _productService.Filter(take,skip,Description);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ProductDTO Get(long id)
        {
            return _productService.Find(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] PostProductDTO productDTO)
        {
            _productService.Add(productDTO);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] PutProductDTO productDTO)
        {
            _productService.Edit(productDTO);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _productService.Remove(id);
        }

    }
}
