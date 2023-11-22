using UE5_3water;
using UE5_3wind;
using UE53;

namespace UE5._3
{
    internal class Program
    {
        static void Main(string[] args) //main program, does not return value and only handles in/out puts
        {
            double speed;     //speed variable for formula input
            int runtime = 10; //total speed steps to run through
            WaterTurbine t1 = new WaterTurbine("superturb400W", 0.2, 0.8 , 202222, 4); //creating instances of turbine
            WaterTurbine t2 = new WaterTurbine("turbineam200W", 0.4, 0.71, 0.5, 8);
            WindTurbine  t3 = new  WindTurbine("superturb400W", 0.4, 0.2, 0.1);
            WindTurbine  t4 = new  WindTurbine("batawinbus00W", 0.2, 0.54, 0.1);
            Turbine[] TurbArray1 = { t1, t2 , t3, t4 }; //creating array of turbine instances
            for (int i = 1; i < runtime + 1; i++) //using "for" loop to set initial speed = 1, stop when 
            {
                Console.WriteLine($"speed: {i} m/s"); //display speed step
                speed = Convert.ToDouble(i); //convert speed step to double to be used in Turbine.CalculatePower
                foreach (Turbine t in TurbArray1) //repeat once for every t instance in array
                {
                    Console.WriteLine($"Turbine named: {t.GetName()} produces {t.CalculatePower(i)} Watts of power"); //display name/power by calling methods
                }
            }
        }
    }
}
