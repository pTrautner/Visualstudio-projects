using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UE04_03
{
    internal class Student
    {
        // Atribute
        private string Name; // Private; man kann die Werte nur innerhalb Student.cs Klasse initialisieren
        private int[] Noten;

        // Konstruktor; initialisiert diese Werten
        public Student(string name, int[] noten)
        {
            Name = name;
            Noten = noten;
        }

        // Getter (Setter für Angabe nicht nötig), aufgeruft in Program.cs
        public string GetName()
        {
            return Name;
        }

        public int[] GetNoten()
        {
            return Noten;
        }

        // Durchschnitt berechnen und bekannt machen
        public double BerechneNotendurchschnitt() // Da Noten private Att. sind, haben Programme nur innerhalb einer Klasse Zugriff
        {
            double sum = 0;
            foreach (int note in Noten)
            {
                sum += note;
            }
            return Math.Round(sum / Noten.Length, 2); // Nach 2 Nachkommastellen berechnen
        }
    }
}
