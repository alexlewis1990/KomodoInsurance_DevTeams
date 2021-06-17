using Developer_POCO;
using Developer_POCO.ENUMS;
using Developer_Repo;
using DevTeam_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KomodoInsurance.UI
{
    class Program_UI
    {

        private readonly DeveloperREPO _dRepo = new DeveloperREPO();
        private readonly DevTeamRepo _dTRepo = new DevTeamRepo();

        public void Run()
        {
            seed();
            RunApplication();
        }

        private void RunApplication()
        {

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to the Komodo Insurance Team Management Application!\n" +
                                  "1.Add A Developer\n" +
                                  "2.View All Developers\n" +
                                  "3.View Developer by ID\n" +
                                  "4.Update Existing Developer\n" +
                                  "5.Delete Existing Developer\n" +
                                  "--------------------------------\n" +
                                  "6.Create Dev Team\n" +
                                  "7. View All Dev Teams\n" +
                                  "8. View Dev Team By ID\n" +
                                  "9. Update Existing Dev Team\n" +
                                  "10. Delete Existing Dev Team\n\n" +
                                  "50. Close Application\n");

                string userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        AddDeveloper();
                        break;
                    case "2":
                        ViewAllDevelopers();
                        break;
                    case "3":
                        ViewDeveloperByID();
                        break;
                    case "4":
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                        DeleteExistingDeveloper();
                        break;
                    case "6":
                        CreateDevTeam();
                        break;
                    case "7":
                        ViewAllDevTeams();
                        break;
                    case "8":
                        ViewDevTeamByID();
                        break;
                    case "9":
                        UpdateExistingDevTeam();
                        break;
                    case "10":
                        DeleteExistingDevTeam();
                        break;
                    case "50":
                        Console.Clear();
                        isRunning = false;
                        Console.WriteLine("Thank you for using our app. Press any key to continue.");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Console.Clear();
            }
        }

        private void DeleteExistingDevTeam()
        {
            Console.Clear();
            Console.WriteLine("Please input existing team ID:");
            int userInputID = int.Parse(Console.ReadLine());

            bool isSuccessful = _dTRepo.DeleteDev_Team(userInputID);
            if(isSuccessful)
            {
                Console.WriteLine("Dev team is deleted");
            }
            else
            {
                Console.WriteLine("dev team not deleted");
            }
        }

        private void UpdateExistingDevTeam()
        {
            Console.Clear();
            Console.WriteLine("Please Input existing Dev Team ID:");
            int userInputID = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Please Input Dev Team Name");
            string userInputDevTeamName = Console.ReadLine();

            Dev_Team dev_team = new Dev_Team(userInputDevTeamName);
            bool isSuccessful = _dTRepo.UpdateDev_Team(userInputID, dev_team);

            if(isSuccessful)
            {
                Console.WriteLine("Dev Team has been updated.");
            }
            else
            {
                Console.WriteLine("Dev Team has failed to update.");
            }
        }

        private void ViewDevTeamByID()
        {
            Console.Clear();
            Console.WriteLine("Please input existing team ID:");
            int userInputID = int.Parse(Console.ReadLine());

            Dev_Team dev_team = _dTRepo.GetDev_TeamByID(userInputID);

            if (dev_team == null)
            {
                Console.WriteLine("Dev Team does not exist.");
            }
            Console.Clear();
            DisplayDevTeamDetails(dev_team);
            Console.ReadKey();
        }

        private void ViewAllDevTeams()
        {
            Console.Clear();
            List<Dev_Team> dev_teams = _dTRepo.GetDev_Teams().ToList();
            foreach (Dev_Team dev_team in dev_teams)
            {
                DisplayDevTeamDetails(dev_team);
            }
            Console.ReadKey();
        }

        private void DisplayDevTeamDetails(Dev_Team dev_team)
        {
            Console.WriteLine($"{dev_team.TeamID}\n" +
                              $"{dev_team.TeamName}\n");
            Console.WriteLine("******************************************");

        }

        private void CreateDevTeam()
        {
            Console.Clear();
            Console.WriteLine("Please Input a Dev Team Name");
            string userInputTeamName = Console.ReadLine();

            // want local list of developers
            List<Developer> developers = new List<Developer>();
            //Create bool to start a while loop
            bool hasFilledPositions = false;

            while (hasFilledPositions == false)
            {
                Console.WriteLine("Do you want to add members to your team y/n");
                string userInputhasFilledPositions = Console.ReadLine();

                if (userInputhasFilledPositions == "Y".ToLower())
                {
                    Console.Clear();
                    ViewAllDevelopers();
                    Console.WriteLine("Please choose Developer by ID.");
                    int userInputDevID = int.Parse(Console.ReadLine());
                    Developer developer = _dRepo.GetDeveloperByID(userInputDevID);

                    // assign developer to developers
                    developers.Add(developer);


                }
                else
                {
                    hasFilledPositions = true;
                }
            }
            Dev_Team team = new Dev_Team(userInputTeamName, developers);
            bool success = _dTRepo.AddDev_Team(team);

            if (success)
            {
                Console.WriteLine("Dev Team Successfully Created");
            }
            else
            {
                Console.WriteLine("Dev Team Creation Failed");
            }
        }

        private void AddDeveloper()
        {
            Console.Clear();

            Console.WriteLine("Please input Developer Name:");
            string userInputDeveloperName = Console.ReadLine();

            Console.WriteLine("Please input Developer Type:\n" +
                              "1.Head_Developer\n" +
                              "2.Body_Developer\n" +
                              "3.Assistant_Developer\n");
            int userInputDeveloperType = int.Parse(Console.ReadLine());

            DeveloperType developertype = (DeveloperType)userInputDeveloperType;

            Console.WriteLine("Does Developer have PluralSight? y/n");
            bool PluralSight = false;
            string userInputPluralSight = Console.ReadLine();

            if (userInputPluralSight == "Y".ToLower())
            {
                PluralSight = true;
            }
            else
            {
                PluralSight = false;
            }

            Developer developer = new Developer(userInputDeveloperName, developertype, PluralSight);

            bool isSuccessful = _dRepo.AddDeveloper(developer);
            if (isSuccessful)
            {
                Console.WriteLine($"{developer.Name}was added to the repository!");
            }
            else
            {
                Console.WriteLine($"{developer.Name}was not added to the repository.");
            }
        }

        private void ViewAllDevelopers()
        {
            Console.Clear();
            List<Developer> developers = _dRepo.GetDevelopers().ToList();
            foreach (Developer developer in developers)
            {
                DisplayDeveloperDetails(developer);
            }
            Console.ReadKey();
        }

        private void DisplayDeveloperDetails(Developer developer)
        {
            Console.WriteLine($"{developer.ID}\n" +
                              $"{developer.Name}\n" +
                              $"{developer.DeveloperType}\n" +
                              $"{developer.PluralSight}\n");
            Console.WriteLine("*******************************************");
        }

        private void ViewDeveloperByID()
        {
            Console.Clear();
            Console.WriteLine("Please input existing Developer ID:");
            int userInputID = int.Parse(Console.ReadLine());

            Developer developer = _dRepo.GetDeveloperByID(userInputID);

            if (developer==null)
            {
                Console.WriteLine("Developer does not exist.");
            }
            Console.Clear();
            DisplayDeveloperDetails(developer);
            Console.ReadKey();
        }

        private void UpdateExistingDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Please input existing Developer ID");
            int userInputID = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Please input a Developer Name");
            string userInputDeveloperName = Console.ReadLine();

            Console.WriteLine("Please input Developer type\n" +
                              "1.Head_Developer\n" +
                              "2.Body_Developer\n" +
                              "3.Assistant_developer\n");

            int userInputDeveloperType = int.Parse(Console.ReadLine());
            DeveloperType developertype = (DeveloperType)userInputDeveloperType;

            Console.WriteLine("Does Developer have PluralSight y/n");
            bool PluralSight = false;
            string userInputPluralSight = Console.ReadLine();

            if (userInputPluralSight == "Y".ToLower())
            {
                PluralSight = true;
            }
            else
            {
                PluralSight = false;
            }

            Developer developer = new Developer(userInputDeveloperName, developertype, PluralSight);

            bool isSuccessful = _dRepo.UpdateDeveloper(userInputID, developer);

            if (isSuccessful)
            {
                Console.WriteLine("Developer has been updated.");
            }
            else
            {
                Console.WriteLine("Developer has failed to update.");
            }
        }

        private void DeleteExistingDeveloper()
        {
            Console.Clear();
            Console.WriteLine("Please input an existing Developer ID");
            int userInputID = int.Parse(Console.ReadLine());

            bool isSuccessful = _dRepo.DeleteDeveloper(userInputID);
            if (isSuccessful)
            {
                Console.WriteLine("Developer Deleted");
            }
            else
            {
                Console.WriteLine("Developer not Deleted");
            }
        }

        private void seed()
        {

            Dev_Team dev_teamA = new Dev_Team("calico");

            Developer developerA = new Developer("Joshua_Briggs", DeveloperType.Head_Developer, false);
            Developer developerB = new Developer("James_Anderson", DeveloperType.Body_Developer, false);
            Developer developerC = new Developer("Frederick_Barns", DeveloperType.Body_Developer, false);
            Developer developerD = new Developer("Patrick_Holmes", DeveloperType.Assistant_Developer, true);

            _dRepo.AddDeveloper(developerA);
            _dRepo.AddDeveloper(developerB);
            _dRepo.AddDeveloper(developerC);
            _dRepo.AddDeveloper(developerD);

            _dTRepo.AddDev_Team(dev_teamA);
        }
    }
}
