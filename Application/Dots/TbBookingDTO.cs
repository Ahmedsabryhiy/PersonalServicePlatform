using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dots
{
    public class TbBookingDTO : BaseTableDTO
    {
        public int ServiceId { get; set; }

        public int CustomerId { get; set; }

        public int ProviderId { get; set; }

        public DateTime BookingDate { get; set; }

        public DateTime ScheduledStart { get; set; }

        public DateTime ScheduledEnd { get; set; }

        public string Status { get; set; } = null!;

        public decimal TotalPrice { get; set; }

    }
}
