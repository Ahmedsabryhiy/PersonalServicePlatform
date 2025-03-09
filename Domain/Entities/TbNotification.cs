using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Domain.Entities
{
    public class TbNotification : BaseTable
    {




        public int CustomerId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Message { get; set; } = string.Empty;

        [Required(ErrorMessage = "Notification type is required")]
        [MaxLength(50)]
        public string NotificationType { get; set; } = string.Empty; // e.g., "New Booking", "Reminder", "Cancellation"

        public bool IsRead { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Key Relationship
        [ValidateNever]
        [ForeignKey("CustomerId")]
        public virtual TbCustomer Customer { get; set; } = null!;
    }
}
