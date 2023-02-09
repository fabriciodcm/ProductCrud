using System.ComponentModel.DataAnnotations;

namespace ProductApp.Application.Models
{
    public class SupplierDTO
    {
        public long Id { get; set; }
        [Required]
        public string Description { get; set; }
        public string CNPJ { get; set; }
    }
}
