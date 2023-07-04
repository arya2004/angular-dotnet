using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public class Product 
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        
        public string Description { get; set; }
        [Required]
        [Range(1, 1000)]
        public decimal Price { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        public int ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; }

        public int ProductBrandId { get; set; }
        [ForeignKey("ProductBrandId")]
        public ProductBrand ProductBrand { get; set; }
        
    }
}
