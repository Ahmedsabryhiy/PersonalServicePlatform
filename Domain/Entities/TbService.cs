using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TbService :BaseTable 
{


    public int ProviderId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Location { get; set; }



    public DateTime? ModifiedDate { get; set; }
    [ValidateNever]
    public virtual TbCategory Category { get; set; } = null!;
    [ValidateNever]
    public virtual TbProvider Provider { get; set; } = null!;
    [ValidateNever]
    public virtual ICollection<TbBooking> TbBookings { get; set; } = new List<TbBooking>();
    [ValidateNever]
    public virtual ICollection<TbProviderAvailability> TbProviderAvailabilities { get; set; } = new List<TbProviderAvailability>();
}
