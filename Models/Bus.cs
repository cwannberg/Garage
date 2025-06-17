

using Garage.Enum;

namespace Garage.Models;

class Bus : Vehicle
{
    internal int PassangerCapacity { get; }
    public Bus(string registrationNumber, string color, int numberOfWheels, string fuel, int passengerCapacity) : base(registrationNumber, color, numberOfWheels, fuel, VehicleType.Bus)
    {
        PassangerCapacity = passengerCapacity;
    }
}
