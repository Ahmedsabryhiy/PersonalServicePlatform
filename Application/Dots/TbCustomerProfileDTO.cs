using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dots
{
    public  class TbCustomerProfileDTO :BaseTableDTO
    {
        [Required (ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = null!;
        [Required (ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = null!;

        [Required (ErrorMessage = "Phone number is required")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }
        [Required (ErrorMessage = "Email is required")]
        [EmailAddress (ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}".Trim();
    }
}
