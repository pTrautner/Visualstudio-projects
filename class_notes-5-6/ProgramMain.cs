using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vorbild;

//vererben:
//internal class Rennauto:Auto(decimal ssd)

//abstract classes: gotta redefine every method
//just google elel
//protected int x      => other same methods can acces it.
//abstract methods need sbs class
//casting: convert class to other class

namespace class_5_notes
{
    internal class ProgramMain
    {
        static void Main(string[] args)
        {
            Auto a1 = new Auto(1,1,1,1)    

            Console.Write(a1.ToString());
            a1.Fahren(34)
        }
    }
}
