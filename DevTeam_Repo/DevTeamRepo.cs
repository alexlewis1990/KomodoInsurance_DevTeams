using Developer_POCO;
using System;
using System.Collections.Generic;

namespace DevTeam_Repo
{
    public class DevTeamRepo
    {
        private readonly List<Dev_Team> _DevTeamRepo = new List<Dev_Team>();
       
        private int _Count = 0;

        public bool AddDev_Team(Dev_Team dev_team)
        {
            if (dev_team != null)
            {
                _Count++;
                dev_team.TeamID = _Count;
                _DevTeamRepo.Add(dev_team);
                return true;
            }
            return false;
        }

        public IEnumerable<Dev_Team> GetDev_Teams()
        {
            return _DevTeamRepo;
        }

        public Dev_Team GetDev_TeamByID(int teamid)
        {

            foreach (Dev_Team dev_team in _DevTeamRepo)
            {
                if (dev_team.TeamID==teamid)
                {
                    return dev_team;
                }
            }
            return null;
        }

        public bool UpdateDev_Team (int teamid, Dev_Team updatedev_teamvalue)
        {
            Dev_Team oldDev_Team = GetDev_TeamByID(teamid);
            if(oldDev_Team == null)
            {
                return false;
            }

            oldDev_Team.TeamID = teamid;
            oldDev_Team.TeamName = updatedev_teamvalue.TeamName;
            oldDev_Team.Developers = updatedev_teamvalue.Developers;
            return true;
        }

        public bool DeleteDev_Team(int teamid)
        {
            Dev_Team dev_team = GetDev_TeamByID(teamid);
            if (dev_team != null)
            {
                _DevTeamRepo.Remove(dev_team);
                return true;
            }
            return false;
        }


    }
}
