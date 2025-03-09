using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dots
{
    public  class TbNotificattionDTO : BaseTableDTO
    {
        [ValidateNever]
        public int CustomerId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Message { get; set; } = string.Empty;

        [Required(ErrorMessage = "Notification type is required")]
        [MaxLength(50)]
        public string NotificationType { get; set; } = string.Empty; // e.g., "New Booking", "Reminder", "Cancellation"

        public bool IsRead { get; set; } = false;

    }
}
