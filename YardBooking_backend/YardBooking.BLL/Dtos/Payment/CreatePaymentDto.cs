using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.enums;

namespace YardBooking.BLL.Dtos.Payment
{
    public class CreatePaymentDto
    {
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
