using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] membersData = Console.ReadLine().Split();

                string memberName = membersData[0];
                int memberAge = int.Parse(membersData[1]);

                Person member = new Person(memberName,memberAge);

                family.AddMember(member);
            }

            var membersOver30 = family.GetMembersOver30();

            foreach (var person in membersOver30.OrderBy(x=> x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
