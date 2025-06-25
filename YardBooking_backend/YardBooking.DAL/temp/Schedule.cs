using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.temp
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }

        [ForeignKey("Yard")]
        public int YardID { get; set; }

        public string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; set; }

        // Navigation Properties
        public Yard Yard { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
