using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dots
{
    public  class TbProviderAvailabilityDTO : BaseTableDTO
    {
        public int ProviderId { get; set; }

        public int ServiceId { get; set; }
        [Required]
        public DateOnly AvailableDate { get; set; }
        [Required]
        public TimeOnly StartTime { get; set; }
        [Required]
        public TimeOnly EndTime { get; set; }

        public bool IsBooked { get; set; }

    }
   
  
}
