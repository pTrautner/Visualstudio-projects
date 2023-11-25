using PTluggage;
using PTtricket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTperson
{
    abstract class Person
    {
        public Person(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
        public int Age { get; set; }
        public string Name { get; set; }
    }
    class Passenger : Person
    {
        Passenger(int age, string name, Ticket ticket, Luggage luggage) : base(age, name) 
        { 
            this.Ticket = ticket;
            this.Luggage = luggage;
        }
        Ticket Ticket { get; set; }
        Luggage Luggage { get; set; }
    }
}
