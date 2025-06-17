

using Garage.Enum;

namespace Garage.Models;

class Airplane : Vehicle
{
    internal int Wingspan { get; }
    
    public Airplane(string registrationNumber, string color, int numberOfWheels, string fuel, int wingspan) : base(registrationNumber, color, numberOfWheels, fuel, VehicleType.Airplane)
    {
        Wingspan = wingspan;
    }
}
