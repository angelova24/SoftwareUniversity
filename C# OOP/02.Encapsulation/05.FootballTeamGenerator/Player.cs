using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private const int minValue = 0;
        private const int maxValue = 100;
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint,
            int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                Validator.ThrowIfNumberNotInRange(
                    minValue, maxValue, value,
                    $"{nameof(this.Endurance)} should be between {minValue} and {maxValue}.");

                this.endurance = value;
            }
        }
        public int Sprint
        {
            get => this.sprint;
            private set
            {
                Validator.ThrowIfNumberNotInRange(
                    minValue, maxValue, value,
                    $"{nameof(this.Sprint)} be between {minValue} and {maxValue}.");

                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            private set
            {
                Validator.ThrowIfNumberNotInRange(
                    minValue, maxValue, value,
                    $"{nameof(this.Dribble)} should be between {minValue} and {maxValue}.");

                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            private set
            {
                Validator.ThrowIfNumberNotInRange(
                    minValue, maxValue, value,
                    $"{nameof(this.Passing)} should be between {minValue} and {maxValue}.");

                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            private set
            {
                Validator.ThrowIfNumberNotInRange
                    (minValue, maxValue, value,
                    $"{nameof(this.Shooting)} should be between {minValue} and {maxValue}.");

                this.shooting = value;
            }
        }

        public double SkillLevel
         => Math.Round(
             (this.Endurance + this.Sprint + this.Dribble + this.Shooting + this.Passing) / 5.0);
           

    }
}
