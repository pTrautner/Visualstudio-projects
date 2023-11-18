using UE53;

namespace UE5_3water;

    internal class WaterTurbine : Turbine //derived from Turbine class   //internal: acces only within files in same assembly
    {
        private double fallHeight; //new attribute specific to this class
        

        public WaterTurbine(string name, double diameter, double efficiency, double density, double fallHeight) : base(name, diameter, efficiency, density) //inherited traits from base class, with new attribute fallheight
        {
            this.fallHeight = fallHeight;
            this._density = WATER_DENSITY; //applying water density constant to density in base constructor(which has the variable set to public)?? maybe doesnt work
        //needs Setdensity(waterdensity)
        }
    public override string CalculatePower(double speed) //uses abstract method from base class by overwriting it with the relevant formula
    {
        double power;
        power = GetEfficiency() * GetDensity() * G * ( ( GetDiameter() * GetDiameter() * Math.PI ) /  4 ) * speed * fallHeight; //calculation using base class getters
        string powerstring = Convert.ToString(power);
        return powerstring; //convert to string and return
    }
}

