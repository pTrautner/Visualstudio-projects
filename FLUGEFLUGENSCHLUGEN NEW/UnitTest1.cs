namespace FLUGEFLUGENSCHLUGEN_NEW;
using PTluggage;
using PTtricket;
[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethodForTickety()
    {
        //Console.WriteLine("test commenced");
        //Ticket t = new Ticket("sd1ds", "sdd2ds", "sd3ds");
        //Console.Write(t.ToString());

        //bad test, written by bad programmer
        string flightNumber = "1232";
        string seat = "3A";
        string ticketClass = "Economy";

        Ticket t = new Ticket(flightNumber, seat, ticketClass);

        Assert.AreEqual(flightNumber, t.FlightNumber, true);
        Assert.AreEqual(seat, t.Seat, true);
        Assert.AreEqual(ticketClass, t.TicketClass, true);
    }
}