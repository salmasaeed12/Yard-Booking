using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.Repository
{
    public interface IPaymentRepo
    {
        Payment GetById(int paymentId);
        IEnumerable<Payment> GetByBookingId(int bookingId);
        Payment Create(Payment payment);
        bool Update(Payment payment);
        bool Delete(int paymentId);
        bool UpdateStatus(int paymentId, string newStatus);
    }
}
