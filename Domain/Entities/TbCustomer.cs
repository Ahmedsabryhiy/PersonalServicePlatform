using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

 namespace Domain.Entities;

public  class TbCustomer :BaseTable 
{
   

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public string ?Address { get; set; }
    public string Email { get; set; } = null!;



    [ValidateNever]
    public virtual ICollection<TbBooking> TbBookings { get; set; } = new List<TbBooking>();
    [ValidateNever]
    public virtual ICollection<TbReview> TbReviews { get; set; } = new List<TbReview>();
    [ValidateNever]
    public virtual ICollection<TbNotification > Notifications { get; set; }= new List<TbNotification>();
}
