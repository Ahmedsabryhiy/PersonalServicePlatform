using Application.Dots;
using System;
using System.Collections.Generic;
using UI.Models; 

namespace UI.Models
{
    public class BookingViewModel
    {
        public BookingViewModel()
        {
          AvailableSlots = new List<AvailableSlot>();
            Service  = new TbServiceDTO();
        }
        public TbServiceDTO Service { get; set; }
        public List<AvailableSlot> AvailableSlots { get; set; }
    }

    public class AvailableSlot
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}

