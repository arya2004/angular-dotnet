using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace API.Dto
{
    public class CustomerBasketDto
    {
        [Required]   
        
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();

    }
}
