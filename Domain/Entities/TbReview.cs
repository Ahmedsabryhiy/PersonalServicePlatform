using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public partial class TbReview :BaseTable 
{
    

    public int BookingId { get; set; }

    public int CustomerId { get; set; }
    [Required (ErrorMessage = "Rating is required")]
    public int Rating { get; set; }

    public string? Comment { get; set; }


    [ValidateNever]
    public virtual TbBooking Booking { get; set; } = null!;

    public virtual TbCustomer Customer { get; set; } = null!;
}
