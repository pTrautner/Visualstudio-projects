using UE_64student;
using System.Text;
using System.Collections;

namespace UE64main;

class Program
{
    static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Paul Trautner\Desktop\Ingenieurinformatik 2\Visualstudio-projects\UE_6.4\UE06-BSP04_Students.csv");
        var students = new List<Student>();

        for (int i = 1; i < lines.Length; i++)
        {
            Student student = new Student(lines[i]);
            students.Add(student);
        }
        Console.WriteLine("Sortierte Liste:");
        students.Sort();
        decimal amountof1 = 0;
        decimal amountof2 = 0;
        decimal amountof3 = 0;
        decimal amountof4 = 0;
        decimal amountof5 = 0;
        decimal studentamount = 0;
        double addedpoints = 0;
        Console.WriteLine("{0,-10}|{1,-10}|{2,-20}|{3,-10}", "student", "note", "name", "matrikelnummer");
        foreach (Student student in students)
        {
            ;
            int note = student.NotenBerechnung(student._punktezahl);
            Console.WriteLine("{0,-10}|{1,-10}|{2,-20}|{3,-10}", student._punktezahl, note, student._nachname+","+student._vorname,student._matrikelnummer);
            studentamount++;
            addedpoints += student._punktezahl;
            switch(note)
            {
                case 1:  
                    amountof1++;
                    continue; 
                case 2:  
                    amountof2++;
                    continue;
                case 3: 
                    amountof3++;
                    continue;
                case 4: 
                    amountof4++;
                    continue;
                case 5: 
                    amountof5++;
                    continue;
            }
        }
        decimal totalnote = amountof1*1+amountof2*2+amountof3*3+amountof4*4+amountof5*5;
        Console.WriteLine(@$"Noten:
1: {amountof1} - {Decimal.Round(amountof1 / studentamount * 100, 2)} %
2: {amountof2} - {Decimal.Round(amountof2 / studentamount * 100, 2)} %
3: {amountof3} - {Decimal.Round(amountof3 / studentamount * 100, 2)} %
4: {amountof4} - {Decimal.Round(amountof4 / studentamount * 100, 2)} %
5: {amountof5} - {Decimal.Round(amountof5 / studentamount * 100, 2)} %");
        Console.WriteLine($"Notendurchschnitt: {Decimal.Round(totalnote / studentamount, 2)}");
        Console.WriteLine($"Notendurchschnitt: {addedpoints / Convert.ToDouble(studentamount)}");

    }
}