using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YardBooking.DAL.Data.Models;

namespace YardBooking.DAL.Repository
{
    public interface ITeamRepo
    {
        Team GetTeamById(int teamId);
        void CreateTeam(Team team);
        bool UpdateTeam(Team team);
        bool DeleteTeam(int teamId);
        IQueryable<Team> GetAllTeams();

    }
}
