using PTluggage;
using PTperson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTaircraft;

abstract class Aircraft
{
    public Aircraft(double aircraftWeight, bool assigned, Crew crew, int fuelCapacity, int fuelConsumption, 
        double loadedWeight, int maxSpeed, double maxWeight, string model, string type)
    {
        this.Type = type;
        this.Model = model;
        this.FuelCapacity = fuelCapacity;
        this.MaxSpeed = maxSpeed;

        switch (type.ToLower())
        {
            case "jumbojet":
                this.FuelConsumption = 16000;
                this.MaxWeight = 380000;
                this.AircraftWeight = 185000;
                this.MaxPassengers = 500;
                break;
            case "jet":
                this.FuelConsumption = 7500;
                this.MaxWeight = 250000;
                this.AircraftWeight = 110000;
                this.MaxPassengers = 290;
                break;
            case "propeller":
                this.FuelConsumption = 150;
                this.MaxWeight = 23000;
                this.AircraftWeight = 6500;
                this.MaxPassengers = 75;
                break;
        }
    }
    public double AircraftWeight { get; set; }
    public bool Assigned { get; set; }
    public Crew? Crew { get; set; }
    public int FuelCapacity { get; set; }
    public int FuelConsumption { get; set; }
    public int LoadedWeight { get; set; }
    public int MaxSpeed { get; set; }
    public int MaxWeight { get; set; }
    public string Model { get; set; }
    public string Type { get; set; }
    public int MaxPassengers { get; set; }

    public abstract int CalcFuelConsumption();

    public virtual void UpdateWeight(double addedWeight)
    {
        //                                              !THIS IS NOT FINISHED! maybe?
        //double updatedWeight;
        //updatedWeight = addedWeight + AircraftWeight;
        //return updatedWeight;                             WHat the fuck goes here
    }
}
class CargoAircraft : Aircraft
{
    int flightTimeInHours; //PLACEHOLDER
    public CargoAircraft(double aircraftWeight, bool assigned, Crew crew, int fuelCapacity, int fuelConsumption, 
        double loadedWeight, int maxSpeed, double maxWeight, string model, string type, double currentWeight)
        : base(aircraftWeight, assigned, crew, fuelCapacity, fuelConsumption, loadedWeight, maxSpeed, maxWeight, model, type)
    {
        this.CurrentWeight = base.AircraftWeight + this.LoadedWeight; //not sure if base. and this. shit is correct
    }
    public double CurrentWeight { get; set; }
    public override int CalcFuelConsumption()
    {
        return FuelConsumption - (200 * flightTimeInHours); //Maybe this gets declared or some shit later
    }
    public override void UpdateWeight(double addedWeight)
    {
        //return base.UpdateWeight(addedWeight);
        //urrentWeight += addedWeight;
        base.UpdateWeight(addedWeight);  //not sure
    }
}
class PassengerAircraft : Aircraft 
{
    public PassengerAircraft(double aircraftWeight, bool assigned, Crew crew, int fuelCapacity, int fuelConsumption, 
        double loadedWeight, int maxSpeed, double maxWeight, string model, string type, double currentweight, int maxpassengers)
        : base(aircraftWeight, assigned, crew, fuelCapacity, fuelConsumption, loadedWeight, maxSpeed, maxWeight, model, type)
    {
        this.Type = type;
        this.CurrentWeight = base.AircraftWeight + this.LoadedWeight; //not sure if base. and this. shit is correct
        this.MaxPassengers = base.MaxPassengers; //not sure if this works
    }
    public double CurrentWeight { get; set; }
    public int Maxpassengers { get; set; }
    //METHODS
    public override void UpdateWeight(double addedWeight)
    {
        base.UpdateWeight(addedWeight); //not sure
    }
    public void AddLuggage(List<Luggage> listname)  //IN PROGRESS
    {
        foreach (Luggage luggage in listname)
        {
            if (this.CurrentWeight < this.MaxWeight)
            {
                this.CurrentWeight += luggage.Weight;
            }
            else return;
        }
    }
    public void AssignCrewToAircraft(List<Crew> listname)
    {
        foreach (Crew crew in listname)
        {
            crew.Assigned = true;
        }
    }
    public void WalkAround()
    {
        Console.WriteLine($"Walkaround on Aircraft {this.Model} is complete");
    }
    public int CompareTo(PassengerAircraft other)
    {
        int passengercomparison = this.MaxPassengers.CompareTo(other.MaxPassengers); //low to high <= "sortiere geringere max zahl nach vorne"
        return passengercomparison;
    }
    public override int CalcFuelConsumption()
    {
        return FuelConsumption - (flightTimeInHours * 0.97 * Maxpassengers); //Maybe flighttime gets declared or some shit later // IN PROGRESS
    }
    public void SetFuelCapacity(int fuelneeded)
    {
        this.FuelCapacity = fuelneeded; //NOT SURE IF CORRECT
    }

}

