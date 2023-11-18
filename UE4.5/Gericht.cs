
namespace Gericht_UE45
{
    internal class Gericht
    {
        //Attributes
        private string _name;
        private decimal _preis;
        private int _zubereitungszeit;
        public string _sonderwunschName = "Keiner";
        //Constructor ohne sonderwunsch da dieser gaendert wird, sonst haette jedes gericht einen standart wunsch
        public Gericht(string name, decimal preis, int zubereitungszeit /*string sonderwunschName*/)
        {
        this._name = name;
        this._preis = preis;
        this._zubereitungszeit = zubereitungszeit;
        //this._sonderwunschName = sonderwunschName;
        }
        //Methods for name, preis, zb.zeit
        public string GetName()
        { return _name; }
        public void SetName(string name)
        { this._name = name; }
        public decimal GetPreis()
        { return _preis; }
        public void SetPreis(decimal preis)
        { this._preis = preis; }
        public int GetZbZeit()
        { return _zubereitungszeit; }
        public void SetZbZeit(int zubereitungszeit)
        { this._zubereitungszeit = zubereitungszeit; }

        public void SonderWunsch(/*bool sonderwunsch, int zubereitungszeit, decimal preis, */string sonderwunschName)
        {
            //string _sonderwunschName;
            decimal preis_erh = 1.1M;
            _zubereitungszeit = GetZbZeit() + 5;
            this._preis = GetPreis() * preis_erh;
           _sonderwunschName = sonderwunschName;

        }

        public Gericht MakeCopy()
        {
           return (Gericht)this.MemberwiseClone();
            //memberwise clone, kopie des gerichtes um zu aendern fuer einen sonderwunsch
        }
        public override string ToString()
        {
            //tostring mit abrundrundung auf 2 stellen hinter komma
            _preis = decimal.Round(_preis, 2);
            return $" Name {_name} Preis {_preis} Zub. zeit {_zubereitungszeit} Sonderwunsch {_sonderwunschName} ";
        }

    }
}
