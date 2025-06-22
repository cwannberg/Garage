using Garage.Enum;

namespace Garage.Interfaces
{
    public interface IVehicle
    {
        string Color { get; set; }
        string Fuel { get; set; }
        int NumberOfWheels { get; set; }
        string RegistrationNumber { get; set; }
        VehicleType VehicleType { get; set; }
    }
}