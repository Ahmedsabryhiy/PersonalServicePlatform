﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dots
{
    public  class TbCategoryDTO : BaseTableDTO
    {
        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
