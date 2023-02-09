using Microsoft.AspNetCore.Mvc;
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
        private IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public ProductPagination Get([FromQuery]int take = 10,[FromQuery] int skip = 0,[FromQuery] string Description = "")
        {
            ProductPagination pagination = new ProductPagination()
            {
                skip = skip,
                take = take,
                Description = Description,
            };

            return _productRepository.Filter(pagination);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(long id)
        {
            return _productRepository.Find(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] Product value)
        {
            _productRepository.Add(value);
            _productRepository.SaveChanges();
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Product value)
        {
            _productRepository.Edit(value);
            _productRepository.SaveChanges();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _productRepository.Remove(_productRepository.Find(id));
            _productRepository.SaveChanges();
        }

    }
}
