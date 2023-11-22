using System;

class Program
{
    static void Main()
    {
        // 10x10 Array erstellen
        int[,] multiplTabelle = new int[10, 10];

        // Je Position im Array wird eine Wert zugewiesen
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                multiplTabelle[i, j] = (i + 1) * (j + 1);
            }
        }

        Console.WriteLine("Multiplikationstabelle von 1 bis 10:");

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                // Tabelle mit Rechtsbündigem Formatieren, 4 Spaces inzwischen (0 -> unübersichtlich, 4+ -> ideal für Angabe)
                Console.Write(multiplTabelle[i, j].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
    }
}
