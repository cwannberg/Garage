
using Garage.Enum;
using Garage.Handlers;
using Garage.Models;

namespace Garage.UI;

internal class ConsoleUI
{
    private GarageHandler _garageHandler;
    private CreateVehicleHandler _createVehicleHandler;

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
            bool successfulInput = int.TryParse(userInput, out int usersChoice);

            if (InputHandler.ValidateInput(userInput, successfulInput, usersChoice))
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

            if (capacity > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                _garageHandler = new(capacity);

                Console.WriteLine($"The garage is built and has {capacity} parking spots");
                Console.ForegroundColor = ConsoleColor.White;
                return _garageHandler;
            }
            else
            {
                Console.WriteLine("The garage must have 1 or more parking spots");
                BuildGarageMenu();
            }
        }
        else
        {
            BuildGarageMenu();
        }
        return _garageHandler;
    }
    private void GetVehicleTypesAndCountMenu()
    {
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
                        ShowWelcomeMessage();
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
        Console.WriteLine("Registration number: ");
        string regNo = Console.ReadLine().ToLower();
        if (_garageHandler.IsRegNoAlreadyInUse(regNo))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A vehicle with this registration number is already parked in the garage.");
            Console.ForegroundColor = ConsoleColor.White;
            AddVehicleMenu();
        }
        Console.WriteLine("Color of vehicle: ");
        string color = Console.ReadLine().ToLower();
        Console.WriteLine("Number of wheels: ");
        int numberOfWheels = int.Parse(Console.ReadLine());
        Console.WriteLine("Type of fuel: ");
        string fuel = Console.ReadLine();

        _createVehicleHandler.CreateVehicle(regNo, color, numberOfWheels, fuel, vehicleType);
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
                        ShowWelcomeMessage();
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
            if (registrationNumber.Equals("0"))
            {
                BackToMainMenu();
            }
            if (InputHandler.ValidateBoolInput(registrationNumber))
            {
                Vehicle vehicle = _garageHandler.SearchForVehicleWithRegNumber(registrationNumber);
                Console.WriteLine($"Found vehicle with registration number: {registrationNumber}");
                Console.WriteLine(vehicle.ToString());
            }
        } while (continueMenu);
    }

    private void BackToMainMenu()
    {
        Console.WriteLine("Go back to main menu? y/n");
        string userInput = Console.ReadLine().ToLower();
        if (InputHandler.ValidateBoolInput(userInput)){
            if (userInput.Equals("y")){
                ShowWelcomeMessage();
            }
        }
    }  
}
