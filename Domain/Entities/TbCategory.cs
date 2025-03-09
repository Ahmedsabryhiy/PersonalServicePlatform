using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public  class TbCategory :BaseTable 
{

    [Required ]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }
    [ValidateNever]
    public virtual ICollection<TbService> TbServices { get; set; } = new List<TbService>();
}
