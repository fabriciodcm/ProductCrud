using Microsoft.AspNetCore.Mvc;
using ProductApp.Domain.Interfaces.Repository;
using ProductApp.Domain.Models;
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
        public IEnumerable<Product> Get()
        {
            return _productRepository.Filter(null,null,null);
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
