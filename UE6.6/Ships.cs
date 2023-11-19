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
        public string _name;
        public int _baujahr;
        public decimal _laenge;
        public Ship(string name, int baujahr, decimal laenge)
        {
            this._name = name;
            this._baujahr = baujahr;
            this._laenge = laenge;
        }
        public string? Name { get; set; }
        //public int Baujahr { get; set; }
        public int GetBaujahr() { return _baujahr; }
        public void SetBaujahr(int baujahr) { _baujahr=baujahr; }
        public decimal Laenge { get; set; }
        public int CompareTo(Ship other)
        {

            int lengthComparison = this._laenge.CompareTo(other._laenge);
            return lengthComparison;
        }
    }
}
