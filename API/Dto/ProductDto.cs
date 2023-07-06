using Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Dto
{
    public class ProductDto
    {
        
        public int ProductId { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        
        public string ProductType { get; set; }

        
        public string ProductBrand { get; set; }

    }
}
