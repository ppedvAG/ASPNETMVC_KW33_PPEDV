namespace _03LSPDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    #region Very Bad Code

    public class BadErdbeere
    {
        public string GetColor()
            => "rot";
    }

    public class BadKirsche : BadErdbeere 
    {
        public string GetColor()
            => base.GetColor();
    }
    #endregion

    #region Better
    public abstract class Fruits
    {
        public abstract string GetColor();

        public int ReifeZeit { get; set; } = 30; 

    }
    public class Erdbeere : Fruits
    {
        public override string GetColor()
        {
            return "Rot";
        }
    }
    public class Kirsche : Fruits
    {
        public override string GetColor()
        {
            return "Rot";
        }
    }

    #endregion
}