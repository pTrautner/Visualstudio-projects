using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using UE55_BasedShip;
using UE55_FishingBoat;
using UE55_SailYacht;

namespace UE5._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //declaring vars/creating instances
            Ship[] shiparray = new Ship[1]; //initial array: size 1
            int userselection = 0;
            int userselection2;
            int shipcount = 0;
            try
            {
                while (userselection != 5) //switch case for exit option
                {
                    Ship newship; //defining new variable of type Ship
                    Console.WriteLine("Enter any number to register a new ship. Or If you would like to exit enter [0]");
                    userselection = ReadNumberInput(); //input check method is called(this is its own method since it must be repeatedly done)
                    switch (userselection)
                    {
                        case 0:
                            Environment.Exit(0);
                            break;

                        case 1:
                            break;

                    }
                    Console.WriteLine("Enter the corresponding number to select a Ship type: Ship[1] FishBoat[2] SailYacht[3]");
                    userselection2 = ReadNumberInput();
                    switch (userselection2) //second switch case for ship choice
                    {
                        // 3cases per ship with array size checks for GrowArray() and creating new instances
                        // with different inputs for the corresponding ship
                        // This code can be improved by making seperate methods for the repeated code in each case.
                        case 1:
                            
                            Console.Write("enter boat name: ");
                            string newName = Console.ReadLine();
                            Console.Write("enter crew size: ");
                            int newCrew = ReadNumberInput();
                            newship = new Ship(newName, newCrew);
                            shiparray[shipcount] = newship;
                            shiparray[shipcount].GetShipInfo();
                            if (shiparray[shipcount].GetAllShips() > shiparray.Length) 
                            {
                                GrowArray();
                            }
                            break;
                        case 2:

                            Console.Write("enter boat name: ");
                            string newName2 = Console.ReadLine();
                            Console.Write("enter crew size: ");
                            int newCrew2 = ReadNumberInput();
                            Console.Write("enter amount of fishes: ");
                            int newFishamount = ReadNumberInput();
                            newship = new FishingBoat(newName2, newCrew2, newFishamount);
                            shiparray[shipcount] = newship;
                            shiparray[shipcount].GetShipInfo();
                            if (shiparray[shipcount].GetAllShips() > shiparray.Length)
                            {
                                GrowArray();
                            }
                            break;
                        case 3:
                            Console.Write("enter boat name: ");
                            string newName3 = Console.ReadLine();
                            Console.Write("enter crew size: ");
                            int newCrew3 = ReadNumberInput();
                            Console.Write("enter passenger amount: ");
                            int newPassengeramount = ReadNumberInput();
                            newship = new SailYacht(newName3, newCrew3, newPassengeramount);
                            shiparray[shipcount] = newship;
                            shiparray[shipcount].GetShipInfo();
                            if (shiparray[shipcount].GetAllShips() > shiparray.Length)
                            {
                                GrowArray();
                            }
                            break;

                    }
                    
                }

            }
            catch (Exception ex)// exception for unexpected inputs etc.
            {
                Console.WriteLine("Invalid input");
                return;
            }
        void GrowArray() //method doubling array: new array instance double the size
            {
                var newArray = new Ship[shiparray.Length * 2];
                for (int i = 0; i < shiparray.Length; i++)
                {
                    newArray[i] = shiparray[i]; //transfering ships to new array
                }
                shiparray = newArray; //replacing the array
            }
            static int ReadNumberInput() //method for checking integer inputs, instead of reusing same code.
            {
                while (true)
                {
                    var input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input)) Console.WriteLine("Invalid input! Please try again."); 

                    try
                    {
                        return int.Parse(input);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Invalid input! Please try again.");
                    }
                }
            }
        }
        
    }
    
}
