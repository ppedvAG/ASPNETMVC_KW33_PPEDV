using System.Linq;

namespace LinqLambdaSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://linqsamples.com/
            //https://docs.microsoft.com/en-us/samples/dotnet/try-samples/101-linq-samples/ 
            Console.WriteLine("Hello, World!");

            IList<Person> persons = new List<Person>();

            if (persons.Any(p => p.Age > 200))
                Console.WriteLine("Es gibt Personen die Älter als 200 Jahre sind");

            if (persons.Average(xyz => xyz.Age) > 100)
            {
                Console.WriteLine("Durschnittsalter ist über 100");
            }

            IList<Person> persons2 = persons.Where(p => p.Name.Contains("Alf")).ToList();


        }
    }

    public class Person
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
    }
}