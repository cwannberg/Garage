

namespace Garage.Models;

class Boat : Vehicle
{
    internal int Horsepower { get;  }
    public Boat(string registrationNumber, string color, int numberOfWheels, string fuel, int horsepower) : base(registrationNumber, color, numberOfWheels, fuel)
    {
        Horsepower = horsepower;
    }
}
