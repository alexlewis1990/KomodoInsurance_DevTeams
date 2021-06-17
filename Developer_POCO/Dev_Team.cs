using System;
using System.Collections.Generic;
using System.Text;

namespace Developer_POCO
{
    public class Dev_Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public List<Developer> Developers { get; set; } = new List<Developer>();

        public Dev_Team()
        {

        }
        public Dev_Team(string teamname,List<Developer> developers)
        {
            TeamName = teamname;
            Developers = developers;

        }

        public Dev_Team(string userInputDevTeamName)
        {
        }
    }
}
