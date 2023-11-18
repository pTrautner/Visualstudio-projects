using System.Text;

namespace UE06_05_Datenverwaltung_für_Olympia
{
    internal class Program
    {
        static void Main()
        {
            // Path wählen
            string path = "C:\\Luka_Pinturic\\TUG\\3. Semestar\\Informatik II\\UE06_05 Datenverwaltung für Olympia\\UE06-BSP05_Olympia2020.csv";

            // Alle Zeilen aus der CSV-Datei mit expliziter Codierung lesen
            string[] lines = File.ReadAllLines(path, Encoding.Default);

            int errorCount = 0;

            List<Land> landList = new List<Land>(); // generische Liste, die Elem. von Typ Land halten kann
                                                   // new List<Land>() -> eine neue Instanz der Liste wird erstellt und landList wird auf diese neue Instanz gesetzt
            for (int i = 1; i < lines.Length; i++)
            {
                string[] lineContent = lines[i].Split(';'); // teilt den Inhalt der aktuellen Zeile der CSV-Datei anhand des ';' und speichert die Teile in einem Array

                // Errors finden
                if (lineContent.Length < 4 || !int.TryParse(lineContent[1], out _) || !int.TryParse(lineContent[2], out _) || !int.TryParse(lineContent[3], out _))
                {
                    errorCount++;
                    continue;
                }

                // Falls der Land-Name leer ist
                if (string.IsNullOrWhiteSpace(lineContent[0]))
                {
                    errorCount++;
                    continue;
                }

                // Land-Objekt erstellen und mit Daten aus der aktuellen Zeile der CSV-Datei initialisieren
                Land land = new Land
                {
                    Name = lineContent[0],               // Name des Landes aus dem ersten Element der Spalte extrahieren
                    Gold = ParseMedal(lineContent[1]),   // Anzahl der Goldmedaillen wird durch Aufrufen der ParseMedal-Methode aus dem 2. Element der Spalte extrahieren
                    Silver = ParseMedal(lineContent[2]),               // ParseMedal versucht, den übergebenen Text in eine Ganzzahl umzuwandeln
                    Bronze = ParseMedal(lineContent[3])               // ParseMedal unten definiert
                };

                // Das erstellte Land-Objekt wird der Liste 'landList' hinzugefügt.
                landList.Add(land);
            }

            // Errors ausdrucken
            Console.WriteLine($"Number of invalid entries: {errorCount}");

            // Unsorted list
            Console.WriteLine("\nUnsorted List:");
            DisplayLandList(landList, 5);

            // Sorted List mit IComparable
            landList.Sort();
            Console.WriteLine("\nSorted by IComparable:");
            DisplayLandList(landList, 5);

            // Sorted List mit IComparer
            landList.Sort(new TotalMedalsComparer());
            Console.WriteLine("\nSorted by IComparer:");
            DisplayLandList(landList, 5);
        }

        static void DisplayLandList(List<Land> landList, int maxCount) // Druckt Länder und deren Medaillen aus
        {
            int count = 0;
            foreach (var land in landList)
            {
                if (count < maxCount)
                {
                    Console.WriteLine($" {land.Name} : Gold: {land.Gold} | Silber: {land.Silver} | Bronze: {land.Bronze}");
                    count++;
                }
                else
                {
                    Console.WriteLine("...");
                    break;
                }
            }
            Console.WriteLine(new string('.', 3)); // Three dots in a new line
        }

        static int ParseMedal(string medal)
        {
            if (int.TryParse(medal, out int result))
            {
                return result;
            }
            return 0; // Default to 0 if parsing fails
        }
    }
}