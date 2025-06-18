using Garage.Enum;

namespace Garage.Models;

class Motorcycle : Vehicle
{
    internal bool HasSideCar { get; }
    public Motorcycle(string registrationNumber, string color, int numberOfWheels, string fuel, bool hasSidecar) : base(registrationNumber, color, numberOfWheels, fuel, VehicleType.Motorcycle)
    {
        HasSideCar = hasSidecar;
    }
    public override string ToString()
    {
        return base.ToString() + $"\n        Has sidecar:        {HasSideCar}";
    }
}
