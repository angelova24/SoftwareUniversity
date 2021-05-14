using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> astronauts;

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => astronauts.Count;

        public SpaceStation(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            astronauts = new List<Astronaut>();
        }

        public void Add(Astronaut astronaut)
        {
            if (astronauts.Count < Capacity && !astronauts.Exists(x=>x.Name==astronaut.Name))
            {
                astronauts.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            if (astronauts.Exists(x => x.Name == name))
            {
                Astronaut astronaut = astronauts.Find(x => x.Name == name);
                astronauts.Remove(astronaut);
                return true;
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut astronaut = astronauts.OrderBy(x => x.Age).LastOrDefault();
            return astronaut;
        }

        public Astronaut GetAstronaut(string name)
        {
            if (astronauts.Exists(x=>x.Name==name))
            {
                Astronaut astronaut = astronauts.Find(x => x.Name == name);
                return astronaut;
            }

            return null;
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Astronauts working at Space Station {Name}:");
            result.Append(Environment.NewLine);
            result.Append($"{string.Join("\n", astronauts)}");
            return result.ToString().TrimEnd();
        }
    }
}
