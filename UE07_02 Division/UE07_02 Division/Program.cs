namespace UE07_02_Division
{
    internal class Program //asdkjdsahd
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try     // Der Code innerhalb des try-Blocks enthält den potenziell fehleranfälligen Code
                {      // Wenn eine Exception auftritt, wird die normale Ausführung des Codes abgebrochen und die Kontrolle wird zum entsprechenden catch-Block weitergeleitet
                       // Benutzereingabe
                    Console.Write("Geben Sie die erste Ganzzahl ein: ");
                    int zahl1 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Geben Sie die zweite Ganzzahl ein: ");
                    int zahl2 = Convert.ToInt32(Console.ReadLine());

                    // Division mittels Funktion durchführen
                    int ergebnis = Divide(zahl1, zahl2);

                    // Ergebnis ausgeben
                    Console.WriteLine($"Ergebnis der Division: {ergebnis}");
                }
                catch (FormatException ex) // FormatException ist eine vordefinierte Exception-Klasse in C#
                {
                    // Fehler bei der Konvertierung der Eingabe zu Int
                    Console.WriteLine($"Fehler: Ungültige Eingabe. {ex.Message}"); // Dem System schon bekannte Nachricht wird geschrieben
                }
                catch (DivideByZeroException ex) // vordefinierte Exception-Klasse
                {
                    // Fehler bei Division durch Null
                    Console.WriteLine($"Fehler: Division durch Null ist nicht erlaubt. {ex.Message}");
                }
                catch (Exception ex) // Allgemeiner Ausnahmefall
                {
                    Console.WriteLine($"Ein Fehler ist aufgetreten. {ex.Message}");
                }
                finally // Diser Code wird immer ausgeführt
                {
                    Console.WriteLine("Vielen Dank für die Nutzung des Divisionsrechners!");
                }
            }
            
        }
        static int Divide(int zähler, int nenner) // Statische Funktion können durch ihre Name referenziert werden
        {
            return zähler / nenner;
        }
    } // Wenn sich der Datentyp der eingegebenen Zahlen ändert: Wenn der Datentyp nicht mit der erwarteten Konvertierung übereinstimmt, wird eine FormatException ausgelöst
}    // Dies kann geschehen, wenn der Benutzer Buchstaben oder Sonderzeichen anstelle von Zahlen eingibt
