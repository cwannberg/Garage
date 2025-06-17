using Garage.Enum;
using Garage.Interfaces;

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
        if (usedRegistrationNumbers.Contains(registrationNumber))
        {
            Console.WriteLine($"Ett fordon med registreringsnumnber {registrationNumber} finns redan i garaget.");
            throw new ArgumentException($"Registreringsnumret '{registrationNumber}' används redan.");
        }
        else
        {
            usedRegistrationNumbers.Add(registrationNumber);
        }
        RegistrationNumber = registrationNumber;
        Color = color;
        NumberOfWheels = numberOfWheels;
        Fuel = fuel;
        VehicleType = vehicleType;
    }

    public static bool IsRegistrationUsed(string regNo)
    {
        return usedRegistrationNumbers.Contains(regNo);
    }
}
