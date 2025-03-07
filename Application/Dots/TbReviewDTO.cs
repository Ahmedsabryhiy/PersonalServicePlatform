using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dots
{   public  class TbReviewDTO : BaseTableDTO
    {

        public int BookingId { get; set; }

        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        public int Rating { get; set; }

        public string? Comment { get; set; }

    }
}
