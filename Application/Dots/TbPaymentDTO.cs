using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dots
{
    public class TbPaymentDTO : BaseTableDTO
    {
        public int BookingId { get; set; }

        public DateTime? PaymentDate { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; } = null!;//Cash,Card,Paypal,Bank

        public string PaymentStatus { get; set; } = null!;//Paid,Unpaid,Refunded,Failed
    }
}
