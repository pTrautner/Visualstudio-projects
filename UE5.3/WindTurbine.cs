using UE53;

namespace UE5_3wind;

    internal class WindTurbine : Turbine //same setup as WaterTurbine
    {
        public WindTurbine(string name, double diameter, double efficiency, double density) : base(name, diameter, efficiency, density)
        {
            this._density = AIR_DENSITY;
        }

        public override string CalculatePower(double speed)
        {
            double power;
            power = GetEfficiency() * GetDensity() * G * ((GetDiameter() * GetDiameter() * Math.PI) / 4) * Math.Pow(speed, 3);
            string powerstring = Convert.ToString(power);
            return powerstring;
        }
    }
