namespace IOCContainerSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }



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