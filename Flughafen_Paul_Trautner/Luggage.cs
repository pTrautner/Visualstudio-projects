using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTluggage;

class Luggage
{
    //Constructor
    public Luggage(string name, string flightnumber, double weight)
    {
        this.Name = name;
        this.Flightnumber = flightnumber;
        this.Weight = weight;
    }
    public string Name { get; set; }
    public string Flightnumber { get; set;}
    public double Weight { get; set; }
}

class Handluggage : Luggage
{
    Handluggage(string name, string flightnumber, double weight) : base(name, flightnumber, weight)
    {
        this.Weight = 8;
    }
}
