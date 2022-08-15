namespace _04ISPDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    #region Bad-Code
    public interface IVehicle
    {
        void Drive();
        void Fly();
        void Swimm(); 
    }

    public class MultiVehicle : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Fahren");
        }

        public void Fly()
        {
            Console.WriteLine("Fly");
        }

        public void Swimm()
        {
            Console.WriteLine("Swim");
        }
    }

    public class BadAmphibischeFahrzeug : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Fahren");
        }

        public void Swimm()
        {
            Console.WriteLine("Swim");
        }

        //Hängt leer in der Luft herum!!! 
        public void Fly()
        {
            throw new NotImplementedException();
        }
    }
    #endregion


    #region Besser

    public interface ISwim
    {
        void Swimm();   
    }

    public interface IFly
    {
        void Fly();
    }

    public interface IDrive
    {
        void Drive();
    }


    public class BetterMultivehicle : ISwim, IFly, IDrive
    {
        public void Drive()
        {
            Console.WriteLine("Drive");
        }

        public void Fly()
        {
            Console.WriteLine("Fly");
        }

        public void Swimm()
        {
            Console.WriteLine("Swimm");
        }
    }

    public class BetterAmphibischeFahrzeug : ISwim, IDrive
    {
        public void Drive()
        {
            Console.WriteLine("Drive");
        }

        public void Swimm()
        {
            Console.WriteLine("Swimm");

        }
    }
    #endregion
}