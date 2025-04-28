//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using YardBooking.DAL.Data;
//using YardBooking.DAL.temp;

//namespace YardBooking.DAL.Repository
//{
//    public class TeamRepo : ITeamRepo
//    {
//        private readonly YardBookingContext _context;

//        public TeamRepo(YardBookingContext context)
//        {
//            _context = context;
//        }

//        public void CreateTeam(Team team)
//        {
//            if (team == null)
//            {
//                throw new ArgumentNullException(nameof(team));
//            }
//            _context.Teams.Add(team);
//            _context.SaveChanges();
//        }

//        public bool DeleteTeam(int teamId)
//        {
//            var team = _context.Teams.Find(teamId);
//            if (team == null)
//            {
//                return false;
//            }
//            _context.Teams.Remove(team);
//            _context.SaveChanges();
//            return true;
//        }

//        public IQueryable<Team> GetAllTeams()
//        {
//            return _context.Teams.AsQueryable();
//        }

//        public Team GetTeamById(int teamId)
//        {
//            throw new NotImplementedException();
//        }

//        public bool UpdateTeam(Team team)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
