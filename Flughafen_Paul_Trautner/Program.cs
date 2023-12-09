using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flughafen_Paul_Trautner;
using PTflightstatus;
//using PTtricket;
using PTluggage;
using PTperson;
class Program
{
    static void Main(string[] args)
    {
        Airport airport = new Airport(@"C:\Users\Paul Trautner\Desktop\Ingenieurinformatik 2\Visualstudio-projects\Flughafen_Paul_Trautner\Basisprojekt_WS23_Studentfiles_v3\");
        airport.ReadInputFiles(@"C:\Users\Paul Trautner\Desktop\Ingenieurinformatik 2\Visualstudio-projects\Flughafen_Paul_Trautner\Basisprojekt_WS23_Studentfiles_v3\");
        airport.DoSimulation();
    }
}
