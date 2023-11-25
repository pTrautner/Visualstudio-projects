using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTflightstatus;

public class FlightstatusEnum
{
    //Funktion:
    //Um die Lesbarkeit und das Verständis zu erleichtern wird mit Enums gearbeitet, um nicht Abfragen nach Status 2 zu machen,
    //ohne zu wissen, welche Bedeutung Status 2 bedeutet(hat im Hintergrund eine int-Repräsentation)

    public enum Flightstatus { None = 0, Standby = 1, Preparing = 2, Boarding = 3, TakeOff = 4, Airborne = 5};
}
