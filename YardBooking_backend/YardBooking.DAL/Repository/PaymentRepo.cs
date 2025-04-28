//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using YardBooking.DAL.Data;
//using YardBooking.DAL.temp;

//namespace YardBooking.DAL.Repository
//{
//    public class PaymentRepo : IPaymentRepo
//    {
//        private readonly YardBookingContext _context;

//        public PaymentRepo(YardBookingContext context)
//        {
//            _context = context;
//        }

//        public Payment GetById(int paymentId)
//        {
//            return _context.Payments
//                           .Include(p => p.Booking)
//                           .FirstOrDefault(p => p.PaymentID == paymentId);
//        }

//        public IEnumerable<Payment> GetByBookingId(int bookingId)
//        {
//            return _context.Payments
//                           .Where(p => p.BookingID == bookingId)
//                           .ToList();
//        }

//        public Payment Create(Payment payment)
//        {
//            payment.PaymentDate = DateTime.UtcNow;
//            _context.Payments.Add(payment);
//            _context.SaveChanges();
//            return payment;
//        }
//        public bool Delete(int paymentId)
//        {
//            var payment = _context.Payments.Find(paymentId);
//            if (payment == null)
//                return false;

//            _context.Payments.Remove(payment);
//            return _context.SaveChanges() > 0;
//        }

//        public bool UpdateStatus(int paymentId, string newStatus)
//        {
//            var payment = _context.Payments.Find(paymentId);
//            if (payment == null)
//                return false;

//            payment.Status = newStatus;
//            _context.Payments.Update(payment);
//            return _context.SaveChanges() > 0;
//        }

//        public bool Update(Payment payment)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
