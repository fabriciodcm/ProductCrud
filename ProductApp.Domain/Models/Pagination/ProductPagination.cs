using ProductApp.Domain.Interfaces.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ProductApp.Domain.Models.Pagination
{
    public class ProductPagination : IPagination<Product>
    {
        public int skip { get; set; }
        public int take { get; set; }
        public int count { get; set; }
        public ICollection<Product> rows { get; set; }
        [JsonIgnore]
        public string Description { get; set; }
        [JsonIgnore]
        public DateTime? FabricationDate { get; set; }
        [JsonIgnore]
        public DateTime? ValidateDate { get; set; }
    }
}
