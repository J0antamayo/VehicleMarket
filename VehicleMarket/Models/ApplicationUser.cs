using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleMarket.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [NotMapped]
        public bool IsAdmin { get; set; }

    }
}
