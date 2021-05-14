using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> familyMembers;

        public Family()
        {
            familyMembers=new List<Person>();
        }


        public void AddMember(Person member)
        {
            familyMembers.Add(member);
        }

        public List<Person> GetMembersOver30()
        {
            List<Person> persons = familyMembers.Where(p => p.Age>30).ToList();

            return persons;
        }
    }
}
