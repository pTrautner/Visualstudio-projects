using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PTluggage;

public class Luggage
{
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

public class HandLuggage : Luggage
{
    public HandLuggage(string name, string flightnumber, double weight) : base(name, flightnumber, weight)
    {
        this.Weight = 8;
    }
}
public class CheckInLuggage : Luggage
{
    public CheckInLuggage(string name, string flightnumber, double weight) : base(name, flightnumber, weight)
    {
    }
}
