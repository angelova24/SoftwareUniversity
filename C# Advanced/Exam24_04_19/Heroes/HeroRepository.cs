using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> repository;

        public int Count => repository.Count;

        public HeroRepository()
        {
            repository=new List<Hero>();
        }
        public void Add(Hero hero)
        {
            repository.Add(hero);
        }

        public void Remove(string name)
        {
            Hero hero = repository.Find(x => x.Name == name);
            repository.Remove(hero);
        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero hero = repository.OrderBy(x => x.Item.Strength).LastOrDefault();

            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero hero = repository.OrderBy(x => x.Item.Ability).LastOrDefault();

            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero hero = repository.OrderBy(x => x.Item.Intelligence).LastOrDefault();

            return hero;
        }

       
    }
}
