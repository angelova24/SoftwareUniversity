using System;

namespace SpaceStationRecruitment
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SpaceStation spaceStation = new SpaceStation("Apolo", 10);
            Astronaut astronaut = new Astronaut("Stephen", 40, "Bulgaria");
            Console.WriteLine(astronaut);

            spaceStation.Add(astronaut);
            spaceStation.Remove("Astronaut name");

            Astronaut secondAstronaut = new Astronaut("Mark", 34, "UK");
            spaceStation.Add(secondAstronaut);

            Astronaut oldestAstronaut = spaceStation.GetOldestAstronaut();
            Console.WriteLine(oldestAstronaut);

            Astronaut astronautStephen = spaceStation.GetAstronaut("Stephen");
            Console.WriteLine(astronautStephen);

            Console.WriteLine(spaceStation.Count);

            Console.WriteLine(spaceStation.Report());
        }
    }
}
