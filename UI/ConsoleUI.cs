﻿
using Garage.Enum;
using Garage.Handlers;
using Garage.Models;

namespace Garage.UI;

internal class ConsoleUI
{
    private GarageHandler _garageHandler;

    internal void ShowWelcomeMessage()
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════════════╗");
        Console.WriteLine("║                                              ║");
        Console.WriteLine("║         WELCOME TO CILLAS GARAGE             ║");
        Console.WriteLine("║                                              ║");
        Console.WriteLine("╚══════════════════════════════════════════════╝");
        Console.WriteLine();
        ShowMainMenu();
    }
    private  void ShowMainMenu()
    {
        if (_garageHandler == null)
        {
            _garageHandler = BuildGarageMenu();
        }
        bool continueMenu = true;
        do
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Please select an option by entering the corresponding number:");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("1. View list of parked vehicles");
            Console.WriteLine("2. View vehicle types and their counts");
            Console.WriteLine("3. Add a vehicle");
            Console.WriteLine("4. Remove a vehicle");
            Console.WriteLine("5. Build a new garage");
            Console.WriteLine("6. Find vehicle by registration number");
            Console.WriteLine("7. Search for vehicle by specific characteristics");
            Console.WriteLine("8. Exit application");
            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Your choice: ");

            string userInput = Console.ReadLine();

            if (InputHandler.ValidateIntInput(userInput, out int usersChoice))
            {
                switch (usersChoice)
                {
                    case 1:
                        GetVehicleList();
                        break;
                    case 2:
                        GetVehicleTypesAndCountMenu();
                        break;
                    case 3:
                        AddVehicleMenu();
                        break;
                    case 4:
                        RemoveVehicleMenu();
                        break;
                    case 5:
                        BuildGarageMenu();
                        break;
                    case 6:
                        SearchForRegistrationNumberMenu();
                        break;
                    case 7:
                        SearchForVehicleMenu();
                        break;
                    case 8:
                        continueMenu = false;
                        break;
                    default:
                        break;
                }
            }
        } while (continueMenu);
    }
    public GarageHandler BuildGarageMenu()
    {
        Console.WriteLine("Let's build a new garage!");
        Console.WriteLine("How many parking slots does the garage need?");
        string userInput = Console.ReadLine();

        if(InputHandler.ValidateIntInput(userInput, out int capacity)){
            _garageHandler = new(capacity);
            InputHandler.ValidInputMessage($"The garage is built and has {capacity} parking spots");
            return _garageHandler;
        }
        else
        {
            InputHandler.InvalidInputMessage("The garage must have 1 or more parking spots");
            BuildGarageMenu();
        }

        return _garageHandler;
    }
    private void GetVehicleTypesAndCountMenu()
    {
        if (_garageHandler.VehiclesCount() < 1)
        {
            InputHandler.InvalidInputMessage("The garage is empty");
            return;
        }
        bool continueMenu = true;
        do
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("View vehicle types and their counts");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Please select an option by entering the corresponding number:");
            Console.WriteLine("1. View what types of vehicles that is parked in the garage");
            Console.WriteLine("2. Cars");
            Console.WriteLine("3. Motorycycles");
            Console.WriteLine("4. Buses");
            Console.WriteLine("5. Boats");
            Console.WriteLine("6. Airplanes");
            Console.WriteLine("7. Go back to main menu");
            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Your choice: ");
            string userInput = Console.ReadLine();

            if (InputHandler.ValidateIntInput(userInput, out int vehicle))
            {
                switch (vehicle)
                {
                    case 1:
                        break;
                    case int n when n >= 2 && n <= 6:
                        _garageHandler.GetVehicleTypesAndCount(n);
                        break;
                    case 7:
                        ShowMainMenu();
                        continueMenu = false;
                        break;
                    default:
                        break;
                }
            }
        } while (continueMenu);
    }
    internal void GetVehicleList()
    {
        _garageHandler.GetListOfVehiclesFromGarage();
    }
    public void CreateVehicleMenu(VehicleType vehicleType)
    {
        if (_garageHandler.GarageIsFull())
        {
            return;
        }
        Console.WriteLine("Registration number: ");
        string userInput = Console.ReadLine();
        if (InputHandler.ValidateStringInput(userInput))
        {
            if (_garageHandler.IsRegNoAlreadyInUse(userInput))
            {
                InputHandler.InvalidInputMessage("A vehicle with this registration number is already parked in the garage.");
                AddVehicleMenu();
            }
            Console.WriteLine("Color of vehicle: ");
            string color = Console.ReadLine().ToLower();
            if (InputHandler.ValidateStringInput(color))
            {
                Console.WriteLine("Number of wheels: ");
                string numberOfWheelsInput = Console.ReadLine();

                if (InputHandler.ValidateIntInput(numberOfWheelsInput, out int numberOfWheels))
                {
                    Console.WriteLine("Type of fuel: ");
                    string fuel = Console.ReadLine();

                    if (InputHandler.ValidateStringInput(fuel))
                    {
                        _garageHandler.CreateVehicle(userInput, color, numberOfWheels, fuel, vehicleType);
                    }
                }
            }
        }
    }
    private  void RemoveVehicleMenu()
    {
        throw new NotImplementedException();
    }
    private static void SearchForVehicleMenu()
    {

    }

    public void AddVehicleMenu()
    {
        if (_garageHandler.GarageIsFull())
        {
            return;
        }
        bool continueMenu = true;
        do
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("What type of vehicle would you like to add to the garage?");
            Console.WriteLine("Please select an option by entering the corresponding number:");
            Console.WriteLine("1. Car");
            Console.WriteLine("2. Motorcycle");
            Console.WriteLine("3. Bus");
            Console.WriteLine("4. Boat");
            Console.WriteLine("5. Airplane");
            Console.WriteLine("6. Go back to main menu");
            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Your choice: ");

            string userInput = Console.ReadLine();
            if (InputHandler.ValidateIntInput(userInput, out int vehicle))
            {
                switch (vehicle)
                {
                    case 1:
                        CreateVehicleMenu(VehicleType.Car);
                        break;
                    case 2:
                        CreateVehicleMenu(VehicleType.Motorcycle);
                        break;
                    case 3:
                        CreateVehicleMenu(VehicleType.Bus);
                        break;
                    case 4:
                        CreateVehicleMenu(VehicleType.Boat);
                        break;
                    case 5:
                        CreateVehicleMenu(VehicleType.Airplane);
                        break;
                    case 6:
                        ShowMainMenu();
                        continueMenu = false;
                        break;
                    default:
                        break;
                }
            }
        } while (continueMenu);
    }

    private void SearchForRegistrationNumberMenu()
    {
        bool continueMenu = true;
        do
        {
            Console.WriteLine("Search for car by registration number");
            Console.WriteLine("Go back to mainmenu by pressing 0");
            Console.WriteLine("Enter registration number: ");
            string registrationNumber = Console.ReadLine().ToLower();
            if (InputHandler.ValidateStringInput(registrationNumber))
            {
                if (registrationNumber.Equals("0"))
                {
                    BackToMainMenu();
                }
                else
                {
                    Vehicle vehicle = _garageHandler.SearchForVehicleWithRegNumber(registrationNumber);
                    InputHandler.ValidInputMessage($"Found vehicle with registration number: {registrationNumber}");
                    Console.WriteLine(vehicle.ToString());
                }
            }
        } while (continueMenu);
    }

    private void BackToMainMenu()
    {
        Console.WriteLine("Go back to mainmenu by pressing 0");
        string userInput = Console.ReadLine();
        if (InputHandler.ValidateStringInput(userInput)){
            if (userInput.Equals("0")){
                ShowMainMenu();
            }
        }
    }  
}
