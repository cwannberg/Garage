using Garage.Enum;
using Garage.Models;

namespace Garage.Handlers;

internal class GarageHandler

{
    private int capacity;
    private Garage<Vehicle> garage;

    public GarageHandler(int capacity)
    {
         garage = new(capacity);
    }

    public void AddVehicle(Vehicle vehicle)
    {
        garage.Add(vehicle);
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        garage.Remove(vehicle);
    }

    public void GetListOfVehiclesFromGarage()
    {
        garage.ToList().Select((g, index) => new { g, index })
            .ToList()
            .ForEach(x =>
    {
        Console.WriteLine($"[{x.index + 1}] {x.g}");
    });
    }

    internal Vehicle SearchForVehicleWithRegNumber(string registrationNumber)
    {
        return garage.FirstOrDefault(v => v.RegistrationNumber == registrationNumber);
    }

    internal bool IsRegNoAlreadyInUse(string regNo)
    {
        return garage.Any(v => v.RegistrationNumber.Equals(regNo, StringComparison.OrdinalIgnoreCase));
    }

    internal void GetVehicleTypesAndCount(int n)
    {
        VehicleType vehicleType;
        switch (n)
        {
            case 2:
                vehicleType = VehicleType.Car;
                break;
            case 3:
                vehicleType = VehicleType.Motorcycle;
                break;
            case 4:
                vehicleType = VehicleType.Bus;
                break;
            case 5:
                vehicleType = VehicleType.Boat;
                break;
            case 6:
                vehicleType = VehicleType.Airplane;
                break;
            default:
                vehicleType = VehicleType.Car;
                break;
        }
        int count = garage.Count(v => v.VehicleType == vehicleType);

        Console.WriteLine($"There are {count} {vehicleType}s in the garage");
    }

    internal void CreateVehicle(string regNo, string color, int numberOfWheels, string fuel, VehicleType vehicleType)
    {
        switch (vehicleType)
        {
            case VehicleType.Car:
                CreateCar(regNo, color, numberOfWheels, fuel);
                break;
            case VehicleType.Motorcycle:
                CreateMotorcycle(regNo, color, numberOfWheels, fuel);
                break;
            case VehicleType.Bus:
                CreateBus(regNo, color, numberOfWheels, fuel);
                break;
            case VehicleType.Boat:
                CreateBoat(regNo, color, numberOfWheels, fuel);
                break;
            case VehicleType.Airplane:
                CreateAirplane(regNo, color, numberOfWheels, fuel);
                break;
        }
    }
    private void CreateCar(string regNo, string color, int numberOfWheels, string fuel)
    {
        Console.WriteLine("Number of seats: ");
        int numberOfSeats = int.Parse(Console.ReadLine());
        Car car = new(regNo, color, numberOfWheels, fuel, numberOfSeats);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"You added a car.\n" +
            $"Registration number {car.RegistrationNumber}\n" +
            $"Color: {car.Color}.\n" +
            $"Number of wheels: {car.NumberOfWheels} wheels\n" +
            $"{car.NumberOfSeats} seats\n" +
            $"fueled by {car.Fuel}");
        Console.ForegroundColor = ConsoleColor.White;
        garage.Add(car);
    }
    private void CreateMotorcycle(string regNo, string color, int numberOfWheels, string fuel)
    {
        Console.WriteLine("Does the motorcycle have a sidecar? y/n");

        //TODO: Lägg till input validering här.
        string userInput = Console.ReadLine();
        if (userInput.Equals("y"))
        {
            Motorcycle sidecarMc = new(regNo, color, numberOfWheels, fuel, true);
            garage.Add(sidecarMc);
        }
        else
        {
            Motorcycle newMc = new(regNo, color, numberOfWheels, fuel, false);
            garage.Add(newMc);
        }
    }
    private void CreateBus(string regNo, string color, int numberOfWheels, string fuel)
    {
        //TODO: Lägg till input validering här.//TODO: Lägg till input validering här.
        Console.WriteLine("Number of passengers alowed on bus: ");
        int passengerCapacity = int.Parse(Console.ReadLine());
        Bus newBus = new(regNo, color, numberOfWheels, fuel, passengerCapacity);
        garage.Add(newBus);
    }
    private void CreateBoat(string regNo, string color, int numberOfWheels, string fuel)
    {
        //TODO: Lägg till input validering här.
        Console.WriteLine("Boat's horsepower: ");
        int horsepower = int.Parse(Console.ReadLine());
        Boat newBoat = new(regNo, color, numberOfWheels, fuel, horsepower);
        garage.Add(newBoat);
    }
    private void CreateAirplane(string regNo, string color, int numberOfWheels, string fuel)
    {
        //TODO: Lägg till input validering här.
        Console.WriteLine("Wingspan in meters: ");
        int wingspan = int.Parse(Console.ReadLine());
        Airplane newAirplane = new(regNo, color, numberOfWheels, fuel, wingspan);
        garage.Add(newAirplane);
    }
}
