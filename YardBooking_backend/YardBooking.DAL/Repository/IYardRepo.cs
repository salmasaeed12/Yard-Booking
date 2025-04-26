using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.Repository
{
    public interface IYardRepo
    {
        void AddYard(Yard yard);
    }
}
