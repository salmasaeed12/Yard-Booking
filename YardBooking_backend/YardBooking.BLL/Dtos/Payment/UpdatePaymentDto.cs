using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.enums;

namespace YardBooking.BLL.Dtos.Payment
{
    public class UpdatePaymentDto
    {
        public PaymentStatus Status { get; set; }
        public string TransactionId { get; set; }
    }
}
