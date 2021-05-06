using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }
        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public double Rating
        {
            get
            {
                if (players.Count == 0)
                {
                    return 0;
                }

                return Math.Round(this.players.Average(p => p.SkillLevel));
            }
        }

        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string teamName, string playerName)
        {
            var player = players.FirstOrDefault(p => p.Name == playerName);

            if (player == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {teamName} team.");
            }

            players.Remove(player);
        }
    }
}
