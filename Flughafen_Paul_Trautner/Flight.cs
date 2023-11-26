using PTaircraft;
using PTluggage;
using PTperson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flughafen_Paul_Trautner
{
    internal class Flight
    {
    }
}
actualDepartureTime wirkliche TakeOff Zeit - (int)
addLuggage Variable, die angibt, ob das Gepäck schon fertig geladen ist - (bool)
aircraft Flugzeug, welches dem Flug zugeordnet wird vom Typ PassengerAircraft
boardingTime benötigte Zeit für das Boarden der Passagiere - (int)
boardPassengers Variable, die angibt, ob die Passagiere schon fertig geboardet sind - (bool)
briefing Variable, die angibt, ob die Crew schon den Flug besprochen hat - (bool)
briefingTime benötigte Zeit für das Briefen der Crew - (int)
clearance Variable, die angibt, ob das Flugzeug abheben darf - (bool)
crew List vom Typ „Crew“, die dem Flug zugeteilt worden sind
currentTime aktueller Zeitpunkt - (int)
departureTime geplante TakeOff Zeit des Fluges als - (int)
destination Zielflughafen - (string)
destinationLat Latitude des Zielflughafens - (double)
destinationLong Longitude des Zielflughafens - (double)
flightNumber Flugnummer - (string)
passengers zugehörige Passagiere als Liste vom Typ Passager
soldTickets Anzahl der verkauften Tickets des Flugzugs - (int)
status Flugstatus als Enum vom Typ FlightStatus
walkAround Variable, die angibt, ob der Walkaround schon durchgeführt worden ist - (bool)
walkAroundTime benötigte Zeit für den walkAround (abhängig vom Flugzeugtyp) -(int)

