using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class Hero
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public Item Item { get; set; }

        public Hero(string name, int level, Item item)
        {
            Name = name;
            Level = level;
            Item = item;
        }

        public override string ToString()
        {
            string result = $"Hero: {Name} - {Level}lvl" +
                            Environment.NewLine +
                            "Item:" +
                            Environment.NewLine +
                            $"  * Strength: {Item.Strength}" +
                            Environment.NewLine +
                            $"  * Ability: {Item.Ability}" +
                            Environment.NewLine +
                            $"  * Intelligence: {Item.Intelligence}";
            return result;
        }
    }
}
