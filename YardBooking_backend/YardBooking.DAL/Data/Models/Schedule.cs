using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.DAL.Data.Models
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int YardId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; set; }

        // Navigation property
        public virtual Yard Yard { get; set; }
    }
}
