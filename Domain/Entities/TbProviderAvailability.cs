using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public partial class TbProviderAvailability :BaseTable 
{


    public int ProviderId { get; set; }

    public int ServiceId { get; set; }
    
    public DateOnly AvailableDate { get; set; }
    [Required]
    public TimeOnly StartTime { get; set; }
    [Required]
    public TimeOnly EndTime { get; set; }
    
    public bool IsBooked { get; set; }
    [ValidateNever]
    public virtual TbProvider Provider { get; set; } = null!;
    [ValidateNever]

    public virtual TbService Service { get; set; } = null!;
}
