using PTluggage;
using PTtricket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTperson
{
    public abstract class Person
    {
        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
        public int Age { get; set; }
        public string Name { get; set; }
    }
    public class Passenger : Person
    {
        public Passenger(int age, string name, Ticket ticket, Luggage luggage) : base(age, name)
        {
            this.Ticket = ticket;
            this.Luggage = luggage;
        }
        public Ticket Ticket { get; set; }
        public Luggage Luggage { get; set; }
    }
    public class Crew : Person
    {
        public Crew(int age, string name, int skill, string role, bool assigned) : base(age, name) //maybe use if instead of switch
        {
            this.Role = role;
            this.Assigned = false;
            switch (role.ToLower())
            {
                case "pilot": 
                    this.Skill = 1; 
                    break;
                case "fo": 
                    this.Skill = 2; 
                    break;
                case "flightattendant": 
                    this.Skill = 3; 
                    break;
                default: this.Skill = 0; 
                    break;
            }

        }
        public int Skill { get; set; }
        public string Role { get; set; }
        public bool Assigned { get; set; }

        public string GetInformation()
        {
            return "\t" + Role.PadLeft(15) + ":" + Name.PadLeft(15) + " " + "age" + " " + Age.ToString().PadRight(25);
        }
    }
}
