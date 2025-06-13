

namespace Garage.Models;

class Car : Vehicle
{
    internal int NumberOfSeats { get; }
    public Car(string registrationNumber, string color, int numberOfWheels, string fuel, int numberOfSeats) : base(registrationNumber, color, numberOfWheels, fuel)
    {
        NumberOfSeats = numberOfSeats;
    }
}
