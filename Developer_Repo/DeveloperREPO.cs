using Developer_POCO;
using System;
using System.Collections.Generic;

namespace Developer_Repo
{
    public class DeveloperREPO
    {
        private readonly List<Developer> _developerRepo = new List<Developer>();

        private int _Count = 0;

        public bool AddDeveloper(Developer developer)
        {
            if (developer != null)
            {

                _Count++;
                developer.ID = _Count;
                _developerRepo.Add(developer);
                return true;
            }
            return false;
        }

        public IEnumerable<Developer> GetDevelopers()
        {
            return _developerRepo;
        }


        public Developer GetDeveloperByID(int id)
        {

            foreach (Developer developer in _developerRepo)
            {
                if (developer.ID==id)
                {
                    return developer;
                }
            }
            return null;
        }

        public bool UpdateDeveloper(int id, Developer updateddevelopervalue)
        {
            Developer oldDeveloper = GetDeveloperByID(id);
            if(oldDeveloper ==null)
            {
                return false;
            }

            oldDeveloper.ID = id;
            oldDeveloper.Name = updateddevelopervalue.Name;
            oldDeveloper.DeveloperType = updateddevelopervalue.DeveloperType;
            oldDeveloper.PluralSight = updateddevelopervalue.PluralSight;

            return true;
        }

        public bool DeleteDeveloper(int id)
        {

            Developer developer = GetDeveloperByID(id);
            if (developer!=null)
            {
                _developerRepo.Remove(developer);
                return true;
            }
            return false;
        }
    }
}
