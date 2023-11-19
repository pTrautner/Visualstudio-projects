using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UE_64student;

public class Student : IComparable<Student>
{
    public string? _vorname;
    public string? _nachname;
    public string? _email;
    public double _matrikelnummer;
    public double _punktezahl;
    public Student(string csvRowData)
    {
        string[] stData = csvRowData.Split(',');
        this._vorname = stData[0];
        this._nachname  = stData[1];
        this._email = stData[3];
        this._matrikelnummer = Convert.ToDouble(stData[2]);
        this._punktezahl = Convert.ToDouble(stData[4]);
    }
    //Calculated grade based on point range (can also be done with switch case)
    public int NotenBerechnung(double Punktezahl)
    {
        int note = 0;
        if (0 <= Punktezahl && Punktezahl <= 49)
        {
            note = 5;
        }
        else if (50 <= Punktezahl && Punktezahl <= 63)
        {
            note = 4;
        }
        else if (64 <= Punktezahl && Punktezahl <= 77)
        {
            note = 3;
        }
        else if (78 <= Punktezahl && Punktezahl <= 89)
        {
            note = 2;
        }
        else if (90 <= Punktezahl && Punktezahl <= 100)
        {
            note = 1;
        }
        else { note  = 0; }
        return note;
    }
    //Comparing student based on different criteria:
    //When the compared students are equal in the current criteria, the next comparison is made
    public int CompareTo(Student other)
    {
        int punktevergleich = other._punktezahl.CompareTo(this._punktezahl); //absteigend: falls this > other: -1 (hohe punktezahl am anfang im array)
        if (punktevergleich != 0)
        {
            return punktevergleich;
        }
        int nachnamenvergleich = this._nachname.CompareTo(other._nachname); //aufsteigend
        if (nachnamenvergleich != 0)
        {
            return nachnamenvergleich;
        }
        int vornamenvergleich = this._vorname.CompareTo(other._vorname);
        if (vornamenvergleich != 0)
        {
            return vornamenvergleich;
        }
        return this._matrikelnummer.CompareTo(other._matrikelnummer);

    }
}

