using Garage.Enum;
using Garage.Models;
using Garage.UI;

namespace Garage.Handlers;

internal class GarageHandler

{
 //   public Garage<Vehicle> _garage = new();
    public Garage<Vehicle> CreateGarage(int capacity)
    {
        Garage<Vehicle> garage = new(capacity);
        return garage;
    }

    public void RemoveVehicle(Vehicle vehicle, Garage<Vehicle> garage)
    {
        garage.Remove(vehicle);
    }

    //TODO: Funkar??
    internal void SearchForVehicleWithRegNumber(string registrationNumber, Garage<Vehicle> garage)
    {
        Vehicle vehicle = garage.FirstOrDefault(v => v.RegistrationNumber == registrationNumber);
    }

    public static bool IsRegNoAlreadyUsed(string regNo)
    {
        return Vehicle.IsRegistrationUsed(regNo);
    }
    internal void GetVehicleList(Garage<Vehicle> garage)
    {
        if(garage.Count() > 0)
            foreach (var vehicle in garage)
            {
                Console.WriteLine($"{vehicle.GetType().Name} - {vehicle.RegistrationNumber} - {vehicle.Color}");
            }
        else
        {
            Console.WriteLine("The garage is empty");
        }
    }
    public void CreateVehicleMenu(VehicleType vehicleType, Garage<Vehicle> garage)
    {

        Console.WriteLine("Registration number: ");
        string regNo = Console.ReadLine().ToLower();
        if (IsRegNoAlreadyUsed(regNo))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Registreringsnumret finns redan");
            Console.ForegroundColor = ConsoleColor.White;
            ConsoleUI.AddVehicleMenu(garage);
        }
        Console.WriteLine("Color of vehicle: ");
        string color = Console.ReadLine().ToLower();
        Console.WriteLine("Number of wheels: ");
        int numberOfWheels = int.Parse(Console.ReadLine());
        Console.WriteLine("Type of fuel: ");
        string fuel = Console.ReadLine();

        CreateVehicle(regNo, color, numberOfWheels, fuel, vehicleType);
    }
    internal void GetVehicleTypesAndCount(int n, Garage<Vehicle> garage)
    {
        if(garage.Count() == 0)
        {
            Console.WriteLine("You dont have a garage, please build one.");
            ConsoleUI.BuildGarageMenu();
        }
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

    }
    private static void CreateMotorcycle(string regNo, string color, int numberOfWheels, string fuel)
    {
        Console.WriteLine("Does the motorcycle have a sidecar? y/n");

        //TODO: Lägg till input validering här.
        string userInput = Console.ReadLine();
        if (userInput.Equals("y"))
        {
            Motorcycle sidecarMc = new(regNo, color, numberOfWheels, fuel, true);
        }
        else
        {
            Motorcycle newMc = new(regNo, color, numberOfWheels, fuel, false);
        }
    }
    private static void CreateBus(string regNo, string color, int numberOfWheels, string fuel)
    {
        //TODO: Lägg till input validering här.//TODO: Lägg till input validering här.
        Console.WriteLine("Number of passengers alowed on bus: ");
        int passengerCapacity = int.Parse(Console.ReadLine());
        Bus newBus = new(regNo, color, numberOfWheels, fuel, passengerCapacity);
    }
    private static void CreateBoat(string regNo, string color, int numberOfWheels, string fuel)
    {
        //TODO: Lägg till input validering här.
        Console.WriteLine("Boat's horsepower: ");
        int horsepower = int.Parse(Console.ReadLine());
        Boat newBoat = new(regNo, color, numberOfWheels, fuel, horsepower);
    }
    private static void CreateAirplane(string regNo, string color, int numberOfWheels, string fuel)
    {
        //TODO: Lägg till input validering här.
        Console.WriteLine("Wingspan in meters: ");
        int wingspan = int.Parse(Console.ReadLine());
        Airplane newAirplane = new(regNo, color, numberOfWheels, fuel, wingspan);
    }
}
