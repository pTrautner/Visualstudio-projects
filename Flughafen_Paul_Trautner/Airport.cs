using PTaircraft;
using PTflightstatus;
using PTluggage;
using PTperson;
using PTtricket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flughafen_Paul_Trautner
{
    public class Airport
    {
        public Airport(string path)
        {
            Path = path;
            Name = "MBI Airport";
            Location = "Graz";
            LatCoordinate = 46.99;
            LongCoordinate = 15.43;
        }

        public List<PassengerAircraft> Aircrafts { get; set; }
        public bool CompletedImport { get; set; }
        public bool CompletedSimulation { get; set; }
        public List<Crew> Crews { get; set; }
        public List<Flight> Flights { get; set; }
        public double LatCoordinate { get; set; }
        public double LongCoordinate { get; set; }
        public string Location { get; set; }
        public List<Luggage> Luggages { get; set; }
        public string Name { get; set; }
        public List<Passenger> Passengers { get; set; }
        public string Path { get; set; }
        public void ReadInputFiles(string path)
        {
            Flights = ReadFlights(path + @"\03 Large case files\Flights.csv");
            Aircrafts = ReadAircrafts(path + @"\03 Large case files\Aircrafts.csv");
            Crews = ReadCrews(path + @"\03 Large case files\Crew.csv");
            Passengers = ReadPassengers(path + @"\03 Large case files\Passengers.csv");
        }
        public string CalcTimetoClock(int time)
        {
            TimeSpan result = TimeSpan.FromMinutes(time);
            return result.ToString("hh':'mm");
        }
        public void DoSimulation()
        {
            int time = 0;
            int counter = Flights.Count;
            SortAircraftsBySeats();
            SortFlightsByDepartureTime();
            Console.WriteLine($"Welcome to {Name}! Let's check out todays Schedule:");
            foreach (Flight flight in Flights)
            {
                Console.WriteLine($"Flight {flight.FlightNumber.PadLeft(5)} is scheduled for departure from {Location} to {flight.Destination.PadLeft(15)} at {CalcTimetoClock(flight.DepartureTime)}");
            }
            Console.WriteLine("------------------------------------------------------------------------------------------");
            int departedFlights = 0;
            int flightCount = Flights.Count;

            while (departedFlights < flightCount)
            {
                time++;
                foreach (Flight flight in Flights)
                {
                    if (time == flight.DepartureTime - 90)
                    {
                        flight.CurrentTime = time;
                        while (true)
                        {
                            switch (flight.FlightStatus)
                            {
                                case FlightStatus.Standby:
                                    Console.WriteLine("\n\n");
                                    PassengerAircraft passengerAircraft = flight.CheckAvailableAircraft(Aircrafts);
                                    flight.AssignAircraft(passengerAircraft);
                                    List<Crew> flightCrew = flight.AssignCrewToFlight(Crews);
                                    flight.Aircraft.AssignCrewToAircraft(flightCrew);
                                    Console.WriteLine($"{CalcTimetoClock(flight.CurrentTime)}: Flight {flight.FlightNumber} is preparing the flights with following crew scheduled at {CalcTimetoClock(flight.DepartureTime)}");
                                    foreach (Crew crew in flight.Crew)
                                    {
                                        Console.WriteLine(crew.GetInformation());
                                    }
                                    flight.FlightStatus = FlightStatus.Briefing;
                                    Console.WriteLine($"\tUsing the {flight.Aircraft.Model} with approximatly {flight.SoldTickets} passengers and the Destination {flight.Destination}");
                                    Console.WriteLine("\n\n");
                                    time++;
                                    continue;

                                case FlightStatus.Briefing:
                                    flight.CurrentTime = time;
                                    flight.FlightBriefing(LatCoordinate, LongCoordinate);
                                    Console.WriteLine($"{CalcTimetoClock(flight.CurrentTime)}: Flight {flight.FlightNumber}");
                                    foreach (Crew crew in flight.Crew)
                                    {
                                        Console.WriteLine($"\t\tCrew member {crew.Name.PadLeft(10)} ({crew.Role.PadLeft(15)}) is at the briefing");
                                    }
                                    time++;
                                    continue;

                                case FlightStatus.Preparing:
                                    time += 25;
                                    flight.CurrentTime = time;
                                    flight.PrepareFlight();
                                    Console.WriteLine($"{CalcTimetoClock(flight.CurrentTime)}: Flight {flight.FlightNumber}");
                                    Console.WriteLine($"\t\tWalkaround on Aircraft {flight.Aircraft.Model} is completed");
                                    continue;

                                case FlightStatus.Boarding:
                                    time += flight.GetWalkAroundTime();
                                    flight.CurrentTime = time;
                                    foreach (Passenger passenger in Passengers)
                                    {
                                        if (passenger.Ticket.FlightNumber == flight.FlightNumber)
                                        {
                                            flight.Passengers.Add(passenger);
                                        }
                                    }
                                    Console.WriteLine($"{CalcTimetoClock(flight.CurrentTime)}: Flight {flight.FlightNumber} has started boarding");
                                    flight.BoardAllPassengers(flight.Passengers);
                                    List<Luggage> luggages = new List<Luggage>();
                                    foreach (Passenger passanger in flight.Passengers)
                                    {
                                        luggages.Add(passanger.Luggage);
                                        flight.Aircraft.UpdateWeight(passanger.Luggage.Weight);
                                    }
                                    flight.BoardLuggage(luggages);
                                    Console.WriteLine($"\t\t{flight.Aircraft.Model}: current weight: {flight.Aircraft.CurrentWeight.ToString("0.0")} kg (weight:maxTakeoffRatio: {((flight.Aircraft.CurrentWeight / flight.Aircraft.MaxWeight) * 100).ToString("0.00")} %)");
                                    time += flight.BoardingTime;
                                    flight.CurrentTime = time;
                                    Console.WriteLine($"{CalcTimetoClock(flight.CurrentTime)}: Flight {flight.FlightNumber} has finished boarding the {flight.Passengers.Count} Passengers and waits for departure");
                                    flight.FlightStatus = FlightStatus.TakeOff;
                                    continue;

                                case FlightStatus.TakeOff:
                                    do
                                    {
                                        time++;
                                    } while (time < flight.DepartureTime);
                                    flight.CurrentTime = time;
                                    if (time == flight.DepartureTime)
                                    {
                                        flight.GetClearance();
                                        Console.WriteLine($"{CalcTimetoClock(flight.CurrentTime)}: Flight {flight.FlightNumber} is on the taxiway and on its way to take off");

                                    }
                                    if (flight.Clearance)
                                    {
                                        flight.FlightStatus = FlightStatus.Airborne;
                                    }
                                    continue;
                                case FlightStatus.Airborne:
                                    departedFlights++;
                                    var random = new Random();
                                    flight.ActualDepartureTime = flight.CurrentTime + random.Next(1, 10);
                                    Console.WriteLine($"{CalcTimetoClock(flight.ActualDepartureTime)}: Flight {flight.FlightNumber} is in the air with {flight.Passengers.Count} passengers on board, flying from {Location} to {flight.Destination} ({flight.CalcDistance(LatCoordinate, LongCoordinate).ToString("0.00")} km) with flighttime: {CalcTimetoClock((int)flight.CalcFlightTime(flight.CalcDistance(LatCoordinate, LongCoordinate)))} h");
                                    break;
                                default:
                                    break;
                            }
                            break;
                        }
                        Console.WriteLine("------------------------------------------------------------------------------------------");
                    }
                }
            }
            Console.WriteLine($"Todays schedule at {Name} in {Location} is finished! Thank you!");
        }
        private List<Flight> ReadFlights(string path)
        {
            List<Flight> flights = new List<Flight>();
            using (var reader = new StreamReader(path))
            {
                string headerLine = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    var flightNumber = values[0];
                    var departureTime = Int32.Parse(values[1]);
                    var soldTickets = Int32.Parse(values[2]);
                    var destination = values[3];
                    var latitude = Double.Parse(values[4]);
                    var longitude = Double.Parse(values[5]);
                    Flight flight = new Flight(flightNumber, departureTime, soldTickets, destination, latitude, longitude);
                    flights.Add(flight);
                }
            }
            return flights;
        }
        private List<PassengerAircraft> ReadAircrafts(string path)
        {
            List<PassengerAircraft> aircrafts = new List<PassengerAircraft>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    var type = values[0];
                    var model = values[1];
                    var fuelCapacity = Int32.Parse(values[2]);
                    var maxSpeed = Int32.Parse(values[3]);
                    PassengerAircraft aircraft = new PassengerAircraft(fuelCapacity, maxSpeed, model, type);
                    aircrafts.Add(aircraft);
                }
            }
            return aircrafts;
        }
        private List<Crew> ReadCrews(string path)
        {
            List<Crew> crews = new List<Crew>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    var name = values[0];
                    var age = Int32.Parse(values[1]);
                    var role = values[2];
                    Crew crew = new Crew(age, name, role);
                    crews.Add(crew);
                }
            }
            return crews;
        }
        private List<Passenger> ReadPassengers(string path)
        {
            List<Passenger> passengers = new List<Passenger>();
            using (var reader = new StreamReader(path))
            {
                string headerLine = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    var name = values[0];
                    var age = Int32.Parse(values[1]);
                    var flightNumber = values[2];
                    var seat = values[3];
                    var ticketClass = values[4];
                    var luggageWeight = Double.Parse(values[5]);
                    Ticket ticket = new Ticket(flightNumber, seat, ticketClass);
                    Luggage luggage = new Luggage(name, flightNumber, luggageWeight);
                    Passenger passenger = new Passenger(age, name, ticket, luggage);
                    passengers.Add(passenger);
                }
            }
            return passengers;
        }
        private void SortAircraftsBySeats()
        {
            Aircrafts.Sort((a, b) => a.MaxPassengers.CompareTo(b.MaxPassengers));
            Aircrafts.Reverse();
        }

        private void SortFlightsByDepartureTime()
        {
            Flights.Sort((a, b) => a.DepartureTime.CompareTo(b.DepartureTime));
        }

    }
}
