using ProductApp.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProductApp.Application.Models
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime? FabricationDate { get; set; }
        public DateTime? ValidateDate { get; set; }
        public long SupplierId { get; set; }
    }
}
