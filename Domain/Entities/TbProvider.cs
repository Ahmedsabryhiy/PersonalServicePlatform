using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TbProvider :BaseTable 
{

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public string? Specialty { get; set; }

    public decimal? AverageRating { get; set; }

    [ValidateNever]

    public virtual ICollection<TbBooking> TbBookings { get; set; } = new List<TbBooking>();
    [ValidateNever]
    public virtual ICollection<TbProviderAvailability> TbProviderAvailabilities { get; set; } = new List<TbProviderAvailability>();
    [ValidateNever]
    public virtual ICollection<TbService> TbServices { get; set; } = new List<TbService>();
}
