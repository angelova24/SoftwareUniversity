using System;
using System.Collections.Generic;

namespace _05.FootballTeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = new Dictionary<string, Team>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var line = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var command = line[0];
                var teamName = line[1];

                try
                {
                    if (command == "Team")
                    {
                        var team = new Team(teamName);
                        teams.Add(teamName, team);
                    }
                    else if (command == "Add")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        var playerName = line[2];
                        var endurance = int.Parse(line[3]);
                        var sprint = int.Parse(line[4]);
                        var dribble = int.Parse(line[5]);
                        var passing = int.Parse(line[6]);
                        var shooting = int.Parse(line[7]);

                        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        teams[teamName].AddPlayer(player);
                    }
                    else if (command == "Remove")
                    {
                        var playerName = line[2];
                        teams[teamName].RemovePlayer(teamName, playerName);
                    }
                    else if (command == "Rating")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                            continue;
                        }

                        Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}

