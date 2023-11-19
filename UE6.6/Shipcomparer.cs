using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UE66_ship;

namespace UE6._6;

public class ShipComparer : IComparer<Ship>
{
    //Icomparer method; additional comparer is required because class Ship is icomparable, has one compareto method.
    //Therefore this additional class with teh icomparer interface/Schnitstelle is needed.
    int IComparer<Ship>.Compare(Ship x, Ship y)
    {

        int agerecomparison = x.Baujahr.CompareTo(y.Baujahr);
        return agerecomparison;
    }

}
