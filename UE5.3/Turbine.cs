namespace UE53;
abstract class Turbine
{
    private string _name; //acces modifier private: only accesible within Turbine class
    private double _diameter;
    private double _efficiency;
    public double _density;
    internal protected const double AIR_DENSITY = 1.293; //access modifier internal: restricts acces to class and derived classes
    internal protected const double WATER_DENSITY = 998; //const declaration: not a variable and may not be modified
    internal protected const double G = 9.81;            //acces mod. internal: only accesible within files in same assembly

    public abstract string CalculatePower(double speed); //abstract modifier indicates that this class is only intented to serve as an base class of other classes
//constructor
    public Turbine(string name, double diameter, double efficiency, double density)
    {
        this._name = name;
        this._diameter = diameter;
        this._efficiency = efficiency;
        this._density = density;
    }
//getters vor variables
    public string GetName()
    {
        return _name;
    }
    public double GetDiameter()
    {
        return _diameter;
    }
    public double GetEfficiency()
    {
        return _efficiency;
    }
    public double GetDensity()
    {
        return _density;
    }
}