using ProductApp.Domain.Models;
using System.Collections.Generic;

namespace ProductApp.Application.Models
{
    public class FilterProductDTO
    {
        public int skip { get; set; }
        public int take { get; set; }
        public int count { get; set; }
        public ICollection<ProductDTO> rows { get; set; }
    }
}
