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
        this.Type = type;
        this.Model = model;
        this.FuelCapacity = fuelCapacity;
        this.MaxSpeed = maxSpeed;

        switch (type.ToLower()) //maybe use if instead of switch
        {
            case "jumbojet":
                this.FuelConsumption = 16000;
                this.MaxWeight = 380000;
                this.AircraftWeight = 185000;
                break;
            case "jet":
                this.FuelConsumption = 7500;
                this.MaxWeight = 250000;
                this.AircraftWeight = 110000;
                break;
            case "propeller":
                this.FuelConsumption = 150;
                this.MaxWeight = 23000;
                this.AircraftWeight = 6500;
                break;
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
    //public int MaxPassengers { get; set; }

    public abstract double CalcFuelConsumption(double flightTimeInH);

    public virtual void UpdateWeight(double weight) { }
}
class CargoAircraft : Aircraft
{
    public CargoAircraft(int fuelCapacity, int maxSpeed, string model, string type) : base(fuelCapacity, maxSpeed, model, type)
    {
        CurrentWeight = AircraftWeight + LoadedWeight; //not sure if base. and this. shit is correct
    }
    public double CurrentWeight { get; set; }
    public override double CalcFuelConsumption(double flightTimeInH)
    {
        return FuelConsumption - (200 * flightTimeInH); //Maybe this gets declared or some shit later
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
    public void AddLuggage(List<Luggage> luggagesList)  //IN PROGRESS
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
    public int CompareTo(PassengerAircraft other) //sortiert geringere maximalzahl nach vorne
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

