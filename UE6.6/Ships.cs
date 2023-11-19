using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace UE66_ship
{
    internal class Ship : IComparable<Ship>
    {
        //Constructor
        public Ship(string name, int baujahr, decimal laenge)
        {
            this.Name = name;
            this.Baujahr = baujahr;
            this.Laenge = laenge;
        }
        //Getters and setters
        public string? Name { get; set; }
        public int Baujahr { get; set; }
        public decimal Laenge { get; set; }
        //ToString
        public override string ToString()
        {
            return $"Name: {Name}, Year built: {Baujahr}, Length: {Laenge}";
        }
        //Compareto method sorting age from low to high
        public int CompareTo(Ship other)
        {

            int lengthComparison = this.Laenge.CompareTo(other.Laenge);
            return lengthComparison;
        }
    }
}
