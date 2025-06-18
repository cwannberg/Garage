using Garage.Enum;
using Garage.Models;

namespace Garage.Handlers;

internal class GarageHandler
{
    public int Capacity { get; }
    private Garage<Vehicle> garage;

    public GarageHandler(int capacity)
    {
        Capacity = capacity;
        garage = new(capacity);
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        garage.Remove(vehicle);
    }

    public void GetListOfVehiclesFromGarage()
    {
        if (garage == null || !garage.Any())
        {
            InputHandler.InvalidInputMessage("The garage is empty.");
            return;
        }

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
    public int VehiclesCount()
    {
        return garage.Count();
    }
    public bool GarageIsFull()
    {
        if(garage.Count() >= Capacity)
        {
            InputHandler.InvalidInputMessage("The garage is full");
        }
        return false;
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
        string userInput = Console.ReadLine();
        if (InputHandler.ValidateIntInput(userInput, out int numberOfSeats))
        {
            Car newCar = new(regNo, color, numberOfWheels, fuel, numberOfSeats);

            InputHandler.ValidInputMessage(
                @$"You added a car: 
                Registration number: {newCar.RegistrationNumber} 
                Color:               {newCar.Color} 
                Number of wheels:    {newCar.NumberOfWheels}
                Fueled by:           {newCar.Fuel}
                Number of seats:     {newCar.NumberOfSeats}" 
            );
            garage.Add(newCar);
        }
    }
    private void CreateMotorcycle(string regNo, string color, int numberOfWheels, string fuel)
    {
        Console.WriteLine("Does the motorcycle have a sidecar? y/n");

        string userInput = Console.ReadLine();
        if (InputHandler.ValidateStringInput(userInput)){
            string sideCar = "No";
            if (userInput.Equals("y"))
            {
                Motorcycle NewMcWithSideCar = new(regNo, color, numberOfWheels, fuel, true);
                
                if (NewMcWithSideCar.HasSideCar)
                {
                    sideCar = "Yes";
                }

                InputHandler.ValidInputMessage(
                @$"You added a motorcycle: 
                Registration number: {NewMcWithSideCar.RegistrationNumber} 
                Color:               {NewMcWithSideCar.Color} 
                Number of wheels:    {NewMcWithSideCar.NumberOfWheels} wheels 
                Fueled by:           {NewMcWithSideCar.Fuel}
                Has a sidecar:       {sideCar}"
                );
                garage.Add(NewMcWithSideCar);
            }
            else
            {
                Motorcycle newMc = new(regNo, color, numberOfWheels, fuel, false);
                InputHandler.ValidInputMessage(
                @$"You added a motorcycle: 
                Registration number: {newMc.RegistrationNumber} 
                Color:               {newMc.Color} 
                Number of wheels:    {newMc.NumberOfWheels}
                Fueled by:           {newMc.Fuel}
                Has a sidecar:       {sideCar}"
            );
                garage.Add(newMc);
            }
        }
    }
    private void CreateBus(string regNo, string color, int numberOfWheels, string fuel)
    {
        Console.WriteLine("Number of passengers allowed on bus: ");
        string userInput = Console.ReadLine();
        if (InputHandler.ValidateIntInput(userInput, out int passengerCapacity))
        {
            Bus newBus = new(regNo, color, numberOfWheels, fuel, passengerCapacity);
            InputHandler.ValidInputMessage(
                @$"You added a bus: 
                Registration number: {newBus.RegistrationNumber} 
                Color:               {newBus.Color} 
                Number of wheels:    {newBus.NumberOfWheels}
                Fueled by:           {newBus.Fuel}
                Passenger capacity:  {newBus.PassangerCapacity}"
            );
            garage.Add(newBus);
        }
    }
    private void CreateBoat(string regNo, string color, int numberOfWheels, string fuel)
    {
        Console.WriteLine("Boat's horsepower: ");
        string userInput = Console.ReadLine();
        if (InputHandler.ValidateIntInput(userInput, out int horsepower))
        {
            Boat newBoat = new(regNo, color, numberOfWheels, fuel, horsepower);
            InputHandler.ValidInputMessage(
                @$"You added a boat: 
                Registration number: {newBoat.RegistrationNumber} 
                Color:               {newBoat.Color} 
                Number of wheels:    {newBoat.NumberOfWheels} 
                Fueled by:           {newBoat.Fuel}
                Horsepower:          {newBoat.Horsepower}"
                );
            garage.Add(newBoat);
        }
    }
    private void CreateAirplane(string regNo, string color, int numberOfWheels, string fuel)
    {
        Console.WriteLine("Wingspan in meters: ");
        string userInput = Console.ReadLine();
        if (InputHandler.ValidateIntInput(userInput, out int wingspan))
        {
            Airplane newAirplane = new(regNo, color, numberOfWheels, fuel, wingspan);
            InputHandler.ValidInputMessage(
                @$"You added an airplane: 
                Registration number: {newAirplane.RegistrationNumber} 
                Color:               {newAirplane.Color} 
                Number of wheels:    {newAirplane.NumberOfWheels} 
                Fueled by:           {newAirplane.Fuel}
                Wingspan:            {newAirplane.Wingspan}"
            );
            garage.Add(newAirplane);
        }
    }

}
