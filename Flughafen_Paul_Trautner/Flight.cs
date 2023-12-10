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
        public FlightStatus FlightStatus { get; set; }
        public bool WalkAround { get; set; }
        public int WalkAroundTime { get; set; }
        public void AssignAircraft(PassengerAircraft passengerAircraft)
        {
            Aircraft = passengerAircraft;
        }
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
            if (assignmentIsPossible == true)
            {
                foreach (Crew crewMember in allCrew)
                {
                    if (crewMember.Assigned == false)
                    {
                        switch (crewMember.Role)
                        {
                            case "pilot":
                                if (pilotNeeded > 0)
                                {
                                    crew.Add(crewMember);
                                    crewMember.Assigned = true;
                                    pilotNeeded--;
                                }
                                break;
                            case "FO":
                                if (fONeeded > 0)
                                {
                                    crew.Add(crewMember);
                                    crewMember.Assigned = true;
                                    fONeeded--;
                                }
                                break;
                            case "flightattendant":
                                if (flightAttendantsNeeded > 0)
                                {
                                    crew.Add(crewMember);
                                    crewMember.Assigned = true;
                                    flightAttendantsNeeded--;
                                }
                                break;
                            default:
                                break;

                        }
                    }
                }
                Crew = crew;
            }
            return Crew;
        }
        public void BoardAllPassengers(List<Passenger> passengers)
        {
            BoardPassengers = true;
            if (Aircraft.Type == "jumbojet")
            {
                BoardingTime = (int)( (passengers.Count * 0.1 + 2 ) / 2);
                return;
            }
            BoardingTime = (int)(passengers.Count * 0.1 + 2);
        }
        public void BoardLuggage(List<Luggage> luggages)
        {
            Aircraft.AddLuggage(luggages);
            AddLuggage = true;
        }
        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        public double CalcDistance(double latitude, double longitude)
        {
            double r = 6371;

            double lat1 = DegreesToRadians(latitude);
            double long1 = DegreesToRadians(longitude);
            double lat2 = DegreesToRadians(DestinationLat);
            double long2 = DegreesToRadians(DestinationLong);

            double dlat = lat2 - lat1;
            double dlong = long2 - long1;

            double a = Math.Sin(dlat / 2) * Math.Sin(dlat / 2) +
                   Math.Cos(lat1) * Math.Cos(lat2) *
                   Math.Sin(dlong / 2) * Math.Sin(dlong / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return r * c;
        }
        public PassengerAircraft CheckAvailableAircraft(List<PassengerAircraft> aircraftList)
        {
            aircraftList.Sort((a,b) => a.CompareTo(b));
            aircraftList.Reverse();
            for (int i = 0; i < aircraftList.Count; i++) 
            {
                if (SoldTickets <= aircraftList[i].MaxPassengers) 
                {
                    return aircraftList[i]; 
                }
            }
            return aircraftList.Last(); 
        }
        public void CheckBriefing()
        {
            if (BriefingTime <= 25)
            {
                FlightStatus = FlightStatus.Preparing;
            }
        }
        public int CompareTo(Flight other) 
        {
            return other.DepartureTime.CompareTo(DepartureTime);
        }
        public void FlightBriefing(double latitude, double longitude)
        {
            double distance = CalcDistance(latitude, longitude);
            Aircraft.SetFuelCapacity(distance);
            CheckBriefing();
            WalkAround = true;
        }
        public void PrepareFlight()
        {
            if (WalkAround == true)
            {
                FlightStatus = FlightStatus.Boarding;
            }
        }
        public void GetClearance()
        {
            if (AddLuggage && BoardPassengers)
            {
                Clearance = true;
            }
        }
        public int GetWalkAroundTime()
        {
            if (Aircraft.Type == "jumbojet")
            {
                return 15;
            }
            else if (Aircraft.Type == "jet")
            {
                return 10;
            }
            else if (Aircraft.Type == "propeller")
            {
                return 5;
            }
            else return 0;
        }
        public double CalcFlightTime(double distance)
        {
            return 60 * (distance / (Aircraft.MaxSpeed * 0.8));
        }
        public double CalcFuelNeeded(double distance)
        {
            double flightTime = CalcFlightTime(distance) / 60;
            return (flightTime + 2.5) * Aircraft.CalcFuelConsumption(flightTime);
        }
        static string CalcTimetoClock(int time)
        {
            TimeSpan result = TimeSpan.FromMinutes(time);
            return result.ToString("hh':'mm");
        }
    }
    
}
