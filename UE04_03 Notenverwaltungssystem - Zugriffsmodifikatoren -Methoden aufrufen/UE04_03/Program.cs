namespace UE04_03 // Notenverwaltungssystem
{
    internal class Program // Für Instanzen (Studenten) einer Klasse benutzen
    {
        static void Main(string[] args)
        {
            // Arrays von 3 Studenden
            Student[] studentenArray = new Student[3]; // Ein einzelnes Array, das drei Student-Objekte halten kann

            int[] noten1 = {1, 3, 4};
            studentenArray[0] = new Student("Kafka", noten1); // Plaziert die Name und noten1 Array an der 0. Stelle der studentenArray (oben definiert)
                                                             // Zugriff zu diesen Variablen durch GetName und GetNoten durch Student.cs Klasse
            int[] noten2 = {2, 3, 5};
            studentenArray[1] = new Student("Gogolj", noten2);

            int[] noten3 = {1, 1, 3};
            studentenArray[2] = new Student("Camus", noten3);

            // Print
            for (int i = 0; i < studentenArray.Length; i++)
            {
                Console.WriteLine($"Student: {studentenArray[i].GetName()}"); 
                Console.WriteLine($"Noten: {string.Join(" / ", studentenArray[i].GetNoten())}");
                Console.WriteLine($"Durchschnitt: {studentenArray[i].BerechneNotendurchschnitt()}");
                Console.WriteLine();
            }
        }
    }
}