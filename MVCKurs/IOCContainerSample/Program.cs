using Microsoft.Extensions.DependencyInjection;

namespace IOCContainerSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //IOC Container im Einsatz

            //Was ist eine ServiceCollection: 

            //In der Service-Collection legen w
            IServiceCollection collection = new ServiceCollection();
            
            collection.AddSingleton<ICar, DummyCar>();


            //kritische Stelle im IOC ist folgende: -> Car überschreibt DummyCar
            collection.AddSingleton<ICar, Car>();

            //Egal ob wir Scope/Transient oder Singleton verwenden, es kann überschrieben werden. 
            collection.AddScoped<ICar, Car>();

            collection.AddFootballLiveTickerService();

            //Weitere Variaten -> LifeCycles
            //collection.AddScoped<ICar, DummyCar>();
            //collection.AddTransient<ICar, DummyCar>();

            //Initialisierung-Phase ist für den IOC Container zuende. 
            //Es soll geachtet werden, DAVOR alle Dienste in den IOC Container zu legen
            IServiceProvider provider = collection.BuildServiceProvider(); //Buid()

            //Wenn wir irgendwie, eine Instance von ICar benötigen, fragen wir den IOC Container nach ICar
            //Unterschied zwischen GetService und GetRequiredService

            //Wenn ein Service nicht gefunden wird, gibt GetService NULL zurück
            ICar? car = provider.GetService<ICar>();

            //Wenn ein Service nicht gefunden wird, wird eine Exception geworfen.
            ICar car2 = provider.GetRequiredService<ICar>();

            #region Weiteres Beispiel für eine Erweiterungs-Methoden
            Person person = new Person();

            person.SavePersonToXML("Person.xml");
            #endregion

        }
    }

    //Diese Erweitungsmethode funktioniert nur, wenn das Namespace als using registriert
    public static class MyFootballLiveTickerServiceExtention
    {
        public static void AddFootballLiveTickerService(this IServiceCollection collection)
        {
            //Als einfache Pseudo-Implementierung
            collection.AddScoped<ICar, DummyCar>();
        }

        public static void SavePersonToXML(this Person p, string SavePath)
        {
            //Speichere in Datei ... 

            Console.WriteLine(p.Id);
            Console.WriteLine(p.Name);

        }
    }

    #region Person
    public class Person
    { 
        public int Id { get; set; }
        public string Name { get; set; }
    }
    #endregion


    #region Interfaces kann man auf Grundlage einer guten Spezifikation erstellen 
    // Meeting von 30-45 Minuten 
    public interface ICar
    {
        int Id { get; set; }
        string Brand { get; set; }
        string Model { get; set; }
        int ConstructionYear { get; set; }
    }

    public interface ICarV2 : ICar
    {
        string Color { get; set; }
    }

    public interface ICarService
    {
        void RepairCar(ICar car);
    }



    //Programmierer A -> 5 Tage immer noch
    public class Car : ICar
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ConstructionYear { get; set; }
    }

    //Programmierer B -> Immer noch 3 Tage
    public class CarService : ICarService
    {
        public void RepairCar(ICar car) //Loose Kopplung 
        {
            //repariere Auto 
        }
    }

    //Programmierer B -> hat 2 Tage noch übrig (bevor Programmierer A fertig ist), und baut sich ein Dummy - Object 

    public class DummyCar : ICar
    {
        public int Id { get; set; } = 123;
        public string Brand { get; set; } = "VW";
        public string Model { get; set; } = "POLO";
        public int ConstructionYear { get; set; } = 2020;
    }
    #endregion

}