using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dots
{
    public  class TbProviderProfileDTO : BaseTableDTO
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? ProfilePictureUrl { get; set; }


        public string ?Specialty { get; set; }
        [MemberNotNull]
        [Required (ErrorMessage = "Rating is required.")]
        public decimal AverageRating { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}".Trim();

    }
}
