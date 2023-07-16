using System.ComponentModel.DataAnnotations;

namespace Core.Models.Identity
{
    public class Address
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        //below auto gives 1-1 relationship
        [Required]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}