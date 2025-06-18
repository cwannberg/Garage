using Garage.Enum;
using Garage.Interfaces;
using System.Text.RegularExpressions;

namespace Garage.Models;

public class Vehicle : IVehicle
{
    public string RegistrationNumber { get; set; }
    public string Color { get; set; }
    public int NumberOfWheels { get; set; }
    public string Fuel { get; set; }
    public VehicleType VehicleType { get; set; }

    private static readonly HashSet<string> usedRegistrationNumbers = new();

    public Vehicle(string registrationNumber, string color, int numberOfWheels, string fuel, VehicleType vehicleType)
    {
        RegistrationNumber = registrationNumber;
        Color = color;
        NumberOfWheels = numberOfWheels;
        Fuel = fuel;
        VehicleType = vehicleType;
    }
    public override string ToString()
    {
        return $@"---------------------------------
        Vehicle Info
        Type:               {VehicleType}
        Reg.nr:             {RegistrationNumber}
        Color:              {Color}
        Number of wheels:   {NumberOfWheels}
        Fuel Type:          {Fuel}";
    }
}

