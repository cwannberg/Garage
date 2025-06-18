

using Garage.Enum;

namespace Garage.Models;

class Boat : Vehicle
{
    internal int Horsepower { get;  }
    public Boat(string registrationNumber, string color, int numberOfWheels, string fuel, int horsepower) : base(registrationNumber, color, numberOfWheels, fuel, VehicleType.Boat)
    {
        Horsepower = horsepower;
    }
    public override string ToString()
    {
        return base.ToString() + $"\n        Horsepower:         {Horsepower}";
    }
}
