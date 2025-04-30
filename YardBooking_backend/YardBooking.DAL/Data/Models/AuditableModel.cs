using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YardBooking.DAL.Data.Models
{
    public abstract class AuditableModel : BaseModel
    {
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
