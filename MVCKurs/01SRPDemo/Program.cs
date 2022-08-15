namespace _01SRPDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    #region BadCode
    public class BadEmployee
    {
        //Employee - Auto-Properties 
        //Employee - Datensatz
        public int Id { get; set; }
        public string Name { get; set; }

        //Eine Methode die eigentlich im DataAccess - Layer zu finden ist (schreibt Employee in DB) 
        public void SaveToDB (Employee employee)
        {
            //Speichere Datensatz in eine DB
        }


        public void GenerateReport(Employee employee)
        {
            //Erstelle ein Report 
        }
    }
    #endregion


    #region Bessere Variante

    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
    }


    //Repository Design Pattern kümmert sich um das manipulieren gegenüber einer Tabelle ( CRUD = Create, Read, Update, Delete) 
    public class EmployeeRepository
    {
        public void Insert(Employee em)
        {
            //Speichere Employee in DB
        }
    }

    public class GenerateReport
    {
        public void Generate(Employee em)
        {
            Console.WriteLine("Erstelle ein Report");
        }
    }
    #endregion
}