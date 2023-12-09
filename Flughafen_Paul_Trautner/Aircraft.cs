using PTluggage;
using PTperson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTaircraft;

public abstract class Aircraft
{
    public Aircraft(int fuelCapacity, int maxSpeed, string model, string type)
    {
        Type = type;
        Model = model;
        FuelCapacity = fuelCapacity;
        MaxSpeed = maxSpeed;

        if (type == "jumbojet")
        {
            FuelConsumption = 16000;
            MaxWeight = 380000;
            AircraftWeight = 185000;
        }
        else if (type == "jet")
        {
            FuelConsumption = 7500;
            MaxWeight = 250000;
            AircraftWeight = 110000;
        }
        else if (type == "propeller")
        {
            FuelConsumption = 150;
            MaxWeight = 23000;
            AircraftWeight = 6500;
        }
        else
        {
            FuelConsumption = 0;
            MaxWeight = 0;
            AircraftWeight = 0;
        }
    }
    public double AircraftWeight { get; set; }
    public bool Assigned { get; set; }
    public List<Crew> Crew { get; set; }
    public int FuelCapacity { get; set; }
    public int FuelConsumption { get; set; }
    public double LoadedWeight { get; set; }
    public int MaxSpeed { get; set; }
    public int MaxWeight { get; set; }
    public string Model { get; set; }
    public string Type { get; set; }

    public abstract double CalcFuelConsumption(double flightTimeInH);

    public virtual void UpdateWeight(double weight) { }
}
class CargoAircraft : Aircraft
{
    public CargoAircraft(int fuelCapacity, int maxSpeed, string model, string type) : base(fuelCapacity, maxSpeed, model, type)
    {
        CurrentWeight = AircraftWeight + LoadedWeight;
    }
    public double CurrentWeight { get; set; }
    public override double CalcFuelConsumption(double flightTimeInH)
    {
        return FuelConsumption - (200 * flightTimeInH); 
    }
    public override void UpdateWeight(double addedWeight)
    {
        CurrentWeight += addedWeight;
    }
}
public class PassengerAircraft : Aircraft 
{
    public PassengerAircraft(int fuelCapacity, int maxSpeed, string model, string type) : base(fuelCapacity, maxSpeed, model, type)
    {
        CurrentWeight = AircraftWeight + LoadedWeight;
        if (type == "jumbojet")
        {
            MaxPassengers = 500;
        }
        else if (type == "jet")
        {
            MaxPassengers = 290;
        }
        else if (type == "propeller")
        {
            MaxPassengers = 75;
        }
        else
        {
            MaxPassengers = 0;
        }
    }
    public double CurrentWeight { get; set; }
    public int MaxPassengers { get; set; }
    public override void UpdateWeight(double addedWeight)
    {
        CurrentWeight += addedWeight;
    }
    public void AddLuggage(List<Luggage> luggagesList) 
    {
        foreach (Luggage luggage in luggagesList)
        {
            if (CurrentWeight < MaxWeight)
            {
                LoadedWeight += luggage.Weight;
            }
        }
    }
    public void AssignCrewToAircraft(List<Crew> crewsList)
    {
        foreach (Crew crew in crewsList)
        {
            crew.Assigned = true;
        }
        Crew = crewsList;
    }
    public void WalkAround()
    {
        Console.WriteLine($"Walkaround on Aircraft {this.Model} is complete");
    }
    public int CompareTo(PassengerAircraft other) 
    {
        return other.MaxPassengers.CompareTo(MaxPassengers);
    }
    public override double CalcFuelConsumption(double flightTimeInH)
    {
        return FuelConsumption - (flightTimeInH * 0.97 * MaxPassengers);
    }
    public void SetFuelCapacity(double fuelneeded)
    {
        this.FuelCapacity = (int)fuelneeded;
    }

}

