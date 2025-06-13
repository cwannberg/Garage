using Garage.Interfaces;

namespace Garage.Models;

public class Vehicle : IVehicle
{
    public string RegistrationNumber { get; set; }
    public string Color { get; set; }
    public int NumberOfWheels { get; set; }
    public string Fuel { get; set; }
    public Vehicle(string registrationNumber, string color, int numberOfWheels, string fuel)
    {
        RegistrationNumber = registrationNumber;
        Color = color;
        NumberOfWheels = numberOfWheels;
        Fuel = fuel;
    }
}
