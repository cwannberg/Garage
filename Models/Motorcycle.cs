

namespace Garage.Models;

class Motorcycle : Vehicle
{
    internal bool HasSideCar { get; }
    public Motorcycle(string registrationNumber, string color, int numberOfWheels, string fuel, bool hasSidecar) : base(registrationNumber, color, numberOfWheels, fuel)
    {
        HasSideCar = hasSidecar;
    }
}
