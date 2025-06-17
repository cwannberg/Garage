
using Garage.Enum;

namespace Garage.Models;

class Car : Vehicle
{
    public int NumberOfSeats { get; set; }
    public Car(string registrationNumber, string color, int numberOfWheels, string fuel, int numberOfSeats) : base(registrationNumber, color, numberOfWheels, fuel, VehicleType.Car)
    {
        NumberOfSeats = numberOfSeats;
    }
}
