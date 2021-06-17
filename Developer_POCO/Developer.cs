using Developer_POCO.ENUMS;
using System;

namespace Developer_POCO
{
    public class Developer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DeveloperType DeveloperType { get; set; }

        public bool PluralSight { get; set; }


        public Developer ()
            {

            }


        public Developer(string name,DeveloperType developertype,bool pluralsight)
        {
            Name = name;
            DeveloperType = developertype;
            PluralSight = PluralSight;
        }


    }
}
