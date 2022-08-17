using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWebAPI.Shared.MockObjects
{
    public interface ICar
    {
        int Id { get; set; }
        string Brand { get; set; }
        string Model { get; set; }
    }

    public class Car : ICar
    {
        public int Id { get; set; }  
        public string Brand { get; set; }
        public string Model { get; set; }
    }

    public class MockCar : ICar
    {
        public int Id { get; set; } = 123;
        public string Brand { get; set; } = "VW";
        public string Model { get; set; } = "Polo";
    }
}
