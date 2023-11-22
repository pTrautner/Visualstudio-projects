using UE55_FishingBoat;
using UE55_SailYacht;

namespace UE55_BasedShip;

class Ship
{
    private string _name;
    private int _crew;
    static int _allShips = 0; //declare staic: create single copy and share along other objects(in this case including yacht/fishingboat)
    public Ship(string name, int crew)//base class ship
    {
        this._name = name;
        this._crew = crew;
        _allShips++; //increase static int
    }
    public Ship(string name)//ship instance requiring only one parameter
    {
        this._name = name;
        _allShips++;
    }
    // getters and setters
    public string GetName()
    {
        return _name;
    }
    public int GetCrew()
    {
        return _crew;
    }
    public void SetCrew(int crew)
    {
        _crew += crew;
    }
    public int GetAllShips()
    {
        return _allShips;
    }
    public void ChangeAllShips(int ships)
    {
        _allShips -= ships;
    }
    //virtual void listing total ships and included fishboats/yachts
    public virtual void GetShipInfo() //virtual method calls overriding member in the most derived class
    {
        string totalfishboats = Convert.ToString(FishingBoat.GetAllFishingBoats());
        string totalsailyacht = Convert.ToString(SailYacht.GetAllSailYachts());
        Console.WriteLine($"Total number of ships registered:({Convert.ToString(_allShips)})   Including   ({totalfishboats}) FishBoats and  ({totalsailyacht}) SailYachts:");
    }

}