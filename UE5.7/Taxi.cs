using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UE55_Taxi
{
    internal class Taxi
    {
        //attributes
        private string _name;
        private decimal _currentlocation;
        private decimal _distancetocustomer;
        private decimal _fuel;
        private bool _acceptscard;
        private bool _haseenoughfuel;
        //constructor
        public Taxi(string name, decimal currentlocation, decimal fuel, bool acceptscard, decimal distancetocustomer, bool hasenoughfuel)
        {
            this._name = name;
            this._currentlocation = currentlocation;
            this._distancetocustomer = distancetocustomer;
            this._fuel = fuel;
            this._acceptscard = acceptscard;
            this._haseenoughfuel = hasenoughfuel;

        }
        //Methods
        public string GetName()
        { return _name; }
        public decimal GetCurrentLocation()
        { return _currentlocation; }
        public void SetCurrentLocation(int currentlocation)
        { this._currentlocation=currentlocation; }
        public decimal GetDistanceToCustomer()
        { return _distancetocustomer; }
        public void Setdistancetocustomer(decimal distancetocustomer)
        { this._distancetocustomer = distancetocustomer; }
        public decimal GetFuel() 
        { return _fuel; }
        public void SetFuel(int fuel)
        { this._fuel=fuel; }
        public bool GetAcceptsCard()
        { return _acceptscard; }
        public bool GetEnoughFuel()
        { return _haseenoughfuel; }
        public void SetEnoughFuel(bool hasenoughfuel)
        { this._haseenoughfuel = hasenoughfuel; }
    }
}
