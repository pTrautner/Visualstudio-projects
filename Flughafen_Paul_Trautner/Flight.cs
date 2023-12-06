using PTaircraft;
using PTluggage;
using PTperson;
using PTflightstatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flughafen_Paul_Trautner
{
    public class Flight
    {
        public Flight(string flightNumber, int departureTime, int soldTickets, string destination, double destinationLat, double destinationLong)
        {
            DepartureTime = departureTime;
            Destination = destination;
            DestinationLat = destinationLat;
            DestinationLong = destinationLong;
            FlightNumber = flightNumber;
            SoldTickets = soldTickets;

            Briefing = false;
            WalkAround = false;
            Clearance = false;
            BoardPassengers = false;
            AddLuggage = false;

            Passengers = new List<Passenger>();
        }
        public int ActualDepartureTime { get; set; }
        public bool AddLuggage { get; set; }
        public PassengerAircraft Aircraft { get; set; }
        public int BoardingTime { get; set; }
        public bool BoardPassengers { get; set; }
        public bool Briefing { get; set; }
        public int BriefingTime { get; set; }
        public bool Clearance { get; set; }
        public List<Crew> Crew { get; set; }
        public int CurrentTime { get; set; }
        public int DepartureTime { get; set; }
        public string Destination { get; set; }
        public double DestinationLat { get; set; }
        public double DestinationLong { get; set; }
        public string FlightNumber { get; set; }
        public List<Passenger> Passengers { get; set; }
        public int SoldTickets { get; set; }
        public FlightStatusEnum FlightStatus { get; set; }
        public bool WalkAround { get; set; }
        public int WalkAroundTime { get; set; }
        public List<Crew> AssignCrewToFlight(List<Crew> allCrew)
        {
            int pilotNeeded;
            int fONeeded;
            int flightAttendantsNeeded;
            int pilot = 0;
            int fO = 0;
            int flightAttendants = 0;
            bool assignmentIsPossible = false;
            List<Crew> crew = new List<Crew>();
            string type = Aircraft.Type;
            switch(type)
            {
                case "jumbojet":
                    pilotNeeded = 2;
                    fONeeded = 1;
                    flightAttendantsNeeded = 9;
                    break;
                case "jet":
                    pilotNeeded = 1;
                    fONeeded = 1;
                    flightAttendantsNeeded = 5;
                    break;
                case "propeller":
                    pilotNeeded = 1;
                    fONeeded = 1;
                    flightAttendantsNeeded = 2;
                    break;
                default:
                    pilotNeeded = 0;
                    fONeeded = 0;
                    flightAttendantsNeeded = 0;
                    break;
            }
            foreach(Crew crewMember in allCrew)
            {
                if (crewMember.Skill == 1)
                {
                    pilot++;
                }
                else if (crewMember.Skill == 2)
                {
                    fO++;
                }
                else if (crewMember.Skill == 3)
                {
                    flightAttendants++;
                }
            }
            if (pilot >= pilotNeeded && fO >= fONeeded && flightAttendants >= flightAttendantsNeeded)
            {
                assignmentIsPossible = true;
            }
            else
            {
                Console.WriteLine("Assignment not possible due to lack of crew!");
            }

        }
    }
    
}
