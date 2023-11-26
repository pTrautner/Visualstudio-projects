namespace UE07_04_Taschenrechner
{
    internal class Program
    {
        static void Main()
        {
            try    // Der Code innerhalb des try-Blocks enthält den potenziell fehleranfälligen Code
            {     // Wenn eine Exception auftritt, wird die normale Ausführung des Codes abgebrochen und die Kontrolle wird zum entsprechenden catch-Block weitergeleitet
                // Benutzereingabe
                Console.Write("Geben Sie die erste Zahl ein: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.Write("Geben Sie die zweite Zahl ein: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

                // Operator wählen
                Console.Write("Geben Sie einen der Grundoperatoren (+, -, *, /) ein: ");
                char operation = Convert.ToChar(Console.ReadLine());

                // Funktion aufrufen und Berechnen
                double result = PerformOperation(num1, num2, operation);
                Console.WriteLine($"Ergebnis der Berechnung: {result}");
            }
            catch (FormatException ex) // FormatException ist eine vordefinierte Exception-Klasse in C#
            {
                // Fehler bei der Konvertierung der Eingabe zu Double
                Console.WriteLine($"Fehler: Ungültige Eingabe. {ex.Message}");
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
                Console.WriteLine("Vielen Dank für die Nutzung des Taschenrechners!");
            }
        }

        // Zwischen vershiedenen Operationen wählen
        static double PerformOperation(double num1, double num2, char operation)
        {
            // Mathematische Operationen als statische Methoden
            switch (operation)
            {
                case '+':
                    return Add(num1, num2);
                case '-':
                    return Subtract(num1, num2);
                case '*':
                    return Multiply(num1, num2);
                case '/':
                    return Divide(num1, num2);
                default:
                    throw new InvalidOperationException("Ungültiger Operator");
            }
        }

        static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        static double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException("Division durch Null ist nicht erlaubt.");
            }
            return num1 / num2;
        }
    }
}