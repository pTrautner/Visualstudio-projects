using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Gericht_UE45;
using Main_Program_UE45;

namespace Bestellung_UE45
{
    internal class Bestellung
    {
        //attributes
        private Gericht[] _gerichtarray;
        //private Gericht[] _gerichtarray2;
        //enum und andere objekjte deklarieren
        public enum Bestellart
        {
            Restaurant, Takeaway, Lieferung
        }
        private Bestellart _bestellart;
        private int currentarraylength = 1;
        private decimal _maxpreis;
        private int _maxzeit;

        //Constructor
        public Bestellung(decimal maxpreis, int maxzeit)
        {
            _gerichtarray = new Gericht[currentarraylength];
            _maxpreis = maxpreis;
            _maxzeit = maxzeit;
        }

        public void AddBestellungToArray(Gericht g, int _bestellungamount)
        {
            //Console.WriteLine(_bestellungamount);
            if (_bestellungamount > currentarraylength)
            {
                currentarraylength = currentarraylength * 2;
                //arraygroesse andern zu der neuen laenge
                Array.Resize<Gericht>(ref _gerichtarray, currentarraylength);
            }
        //amount -1 wegen zero index des arrays (viel programier probleme deswegen)
            _gerichtarray[_bestellungamount - 1] = g;
        }
        //bestellart setter
        public void SetBestellArt(Bestellart value)
        {
            _bestellart = value;
        }
        //getter
        public Bestellart GetBestellArt()
        { return _bestellart; }

        //shwogerichte mit tostring methode fuer jedes gericht im array, bis null/ende
        public void ShowGerichte()
        {

            foreach (Gericht g in _gerichtarray)
            {
                if (g != null)
                {
                    Console.WriteLine(g.ToString());
                }
            }
        }
        //bestimmen von max. zahlen (nicht sehr effizient) siehe unten fuer verbesserte version durch einen freund
/*
* public decimal MaxPreis() 
{
decimal maxPreis = 0;
foreach (Gericht g in _gerichtarray) 
  {
    if (g == null) continue;
  
    decimal preis = g.GetPreis();
    if (preis > maxPreis) maxPreis = preis;  
  }

return maxPreis;
} 
         */
        public decimal MaxPreis()
        {
            decimal preis = 0;
            foreach (Gericht g in _gerichtarray)
            {
               

                if (g != null)
                    _maxpreis = g.GetPreis();
                if (_maxpreis > preis)
                    preis = _maxpreis;
            }
            return preis;
        }
        public int MaxZeit()
        {
            int zeit = 0;
            foreach (Gericht g in _gerichtarray)
            {


                if (g != null)
                    _maxzeit = g.GetZbZeit();
                if (_maxzeit > zeit)
                    zeit = _maxzeit;
            }
            return zeit;
        }
    }
}

