using System;
using System.Collections.Generic;

namespace Domain.Entities;

public class TbBooking :BaseTable  
{
   

    public int ServiceId { get; set; }

    public int CustomerId { get; set; }

    public int ProviderId { get; set; }

    public DateTime BookingDate { get; set; }

    public DateTime ScheduledStart { get; set; }

    public DateTime ScheduledEnd { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalPrice { get; set; }



    public virtual TbCustomer Customer { get; set; } = null!;

    public virtual TbProvider Provider { get; set; } = null!;

    public virtual TbService Service { get; set; } = null!;

    public virtual ICollection<TbPayment> TbPayments { get; set; } = new List<TbPayment>();

    public virtual ICollection<TbReview> TbReviews { get; set; } = new List<TbReview>();
}
