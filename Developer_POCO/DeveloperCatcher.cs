using System;
using System.Collections.Generic;
using System.Text;

namespace Developer_POCO
{
    public class DeveloperCatcher
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public List<Developer> CapturedDevelopers { get; set; } = new List<Developer>();

        public decimal Earnings
        {
            get
            {

                decimal totalEarnings = 0;


                foreach (Developer developer in CapturedDevelopers)
                {
                    totalEarnings += CalculateDeveloperEarnings(developer);
                }
                return totalEarnings;
            }
        }


        private decimal CalculateDeveloperEarnings(Developer developer)
        {
            switch (developer.DeveloperType)
            {
                case ENUMS.DeveloperType.Head_Developer:
                    return 50000.00m;
                case ENUMS.DeveloperType.Body_Developer:
                    return 25000.00m;
                case ENUMS.DeveloperType.Assistant_Developer:
                    return 10000.00m;
                default:
                    Console.WriteLine("Invalid Developer Option");
                    return 0;
            }
        }

        public DeveloperCatcher()
        {

        }

        public DeveloperCatcher(string name, List<Developer> capturedDevelopers)
        {
            Name = name;
            CapturedDevelopers = capturedDevelopers;
        }
    }
}
