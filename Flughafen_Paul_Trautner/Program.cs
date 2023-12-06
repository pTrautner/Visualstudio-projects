using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PTflightstatus;
//using PTtricket;
using PTluggage;
using PTperson;
//Tip from david: changes requested will probably be making a new method do something, Make sure you understand Icompare/IComparer perfectly
//Notes from final uebung session
//possible on test: difference between runtime error/syntax error/
//CHECK NEW VERSION OF BASISPROJECT
//GO ANMELDEN FOR 12 DECEMBER,
//take projektangabe with you, own keyboard,
//not sure about unittesting stuff
class Program
{
    static void Main(string[] args)
    {
        //HandLuggage l1 = new HandLuggage("ddsss","23", 1);
        //Console.Write(l1.Name);
        Crew c1 = new Crew(12, "Paul",0, "pilot", true);
        Crew c2 = new Crew(12, "Paul", 0, "flightattendant", true);
        c1.GetInformation();
        c2.GetInformation();
    }
}
