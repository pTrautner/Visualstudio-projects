using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTtricket;

internal class Ticket
{
    //constructor
    public Ticket(string flightNumber, string seat, string ticketClass)
        {
        this.FlightNumber = flightNumber;
        this.Seat = seat;
        this.TicketClass = ticketClass;
        }
    //getter and setters
    public string FlightNumber { get; set;}
    public string Seat { get; set;}
    public string TicketClass { get; set;}

}
