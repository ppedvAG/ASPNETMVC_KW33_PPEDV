namespace RazorSyntaxSample.Models
{
    public class Person : IDisposable
    {
        public int Id { get; set; }

        public string FirstName { get; set; } 
        public string LastName { get; set; }

        public void Dispose()
        {
            Console.WriteLine("Hier kann man das Objekte Abbauen");
        }
    }
}
