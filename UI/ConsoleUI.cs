
using Garage.Enum;
using Garage.Handlers;
using Garage.Models;

namespace Garage.UI;

static class ConsoleUI
{
    internal static void ShowWelcomeMessage()
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
    private static void ShowMainMenu()
    {
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
            Garage<Vehicle> garage = new Garage<Vehicle>(10);
            GarageHandler garageHandler = new GarageHandler();
            if (InputHandler.ValidateInput(userInput, successfulInput, usersChoice))
            {
                switch (usersChoice)
                {
                    case 1:
                        garageHandler.GetVehicleList(garage);
                        break;
                    case 2:
                        GetVehicleTypesAndCountMenu(garage);
                        break;
                    case 3:
                        AddVehicleMenu(garage);
                        break;
                    case 4:
                        RemoveVehicleMenu();
                        break;
                    case 5:
                        BuildGarageMenu();
                        break;
                    case 6:
                        SearchForRegistrationNumberMenu(garage);
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

    private static void GetVehicleTypesAndCountMenu(Garage<Vehicle> garage)
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
            GarageHandler garageHandler = new GarageHandler();

            if (InputHandler.ValidateIntInput(userInput, out int vehicle))
            {
                switch (vehicle)
                {
                    case 1:
                        break;
                    case int n when n >= 2 && n <= 6:
                        garageHandler.GetVehicleTypesAndCount(n, garage);
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

    public static Garage<Vehicle> BuildGarageMenu()
    {
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine("Let's build a new garage!");
        Console.WriteLine("-------------------------------------------------------------");
        Console.WriteLine("How many parking slots does the garage need?");
        int capacity = int.Parse(Console.ReadLine());
        Console.ForegroundColor = ConsoleColor.Green;
        GarageHandler garageHandler = new();
        Garage<Vehicle> garage = garageHandler.CreateGarage(capacity);
        Console.WriteLine($"The garage is built and has {capacity} parking spots");
        Console.ForegroundColor = ConsoleColor.White;
        return garage;
       // ShowMainMenu();
    }

    private static void RemoveVehicleMenu()
    {
        throw new NotImplementedException();
    }
    private static void SearchForVehicleMenu()
    {

    }

    public static void AddVehicleMenu(Garage<Vehicle> garage)
    {
        GarageHandler garageHandler = new();

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
                        garageHandler.CreateVehicleMenu(VehicleType.Car, garage);
                        break;
                    case 2:
                        garageHandler.CreateVehicleMenu(VehicleType.Motorcycle, garage);
                        break;
                    case 3:
                        garageHandler.CreateVehicleMenu(VehicleType.Bus, garage);
                        break;
                    case 4:
                        garageHandler.CreateVehicleMenu(VehicleType.Boat, garage);
                        break;
                    case 5:
                        garageHandler.CreateVehicleMenu(VehicleType.Airplane, garage);
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

    private static void SearchForRegistrationNumberMenu(Garage<Vehicle> garage)
    {
        GarageHandler garageHandler = new GarageHandler();
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
                garageHandler.SearchForVehicleWithRegNumber(registrationNumber, garage);
            }
        } while (continueMenu);
    }

    private static void BackToMainMenu()
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
