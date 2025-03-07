using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public partial class TbPayment :BaseTable 
{
   
    public int BookingId { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; } = null!;//Cash,Card,Paypal,Bank

    public string PaymentStatus { get; set; } = null!;//Paid,Unpaid,Refunded,Failed
    [ForeignKey("BookingId")]
    [ValidateNever]
    public virtual TbBooking Booking { get; set; } = null!;
}
