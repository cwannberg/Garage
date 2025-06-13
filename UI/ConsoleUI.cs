

using Garage.Enum;
using Garage.Handlers;
using Garage.Models;
using System.ComponentModel.Design;

namespace Garage.UI;

static class ConsoleUI
{
    internal static void ShowWelcomeMessage()
    {
        Console.Clear();
        Console.WriteLine("╔══════════════════════════════════════════════╗");
        Console.WriteLine("║                                              ║");
        Console.WriteLine("║         WELCOME TO CILLAS' GARAGE            ║");
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
                        GarageHandler.GetVehicleList();
                        break;
                    case 2:
                        GarageHandler.GetVehicleTypesAndCount();
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

    private static void BuildGarageMenu()
    {
        throw new NotImplementedException();
    }

    private static void RemoveVehicleMenu()
    {
        throw new NotImplementedException();
    }

    public static void AddVehicleMenu()
    {
        bool continueMenu = true;
        do
        {
            Console.WriteLine("What type of vehicle would you like to add to the garage?\n\n");
            Console.WriteLine("Please select an option by entering the corresponding number:");
            Console.WriteLine("-------------------------------------------------------------");
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
                        GarageHandler.AddVehicle(VehicleType.Car);
                        break;
                    case 2:
                        GarageHandler.AddVehicle(VehicleType.Motorcycle);
                        break;
                    case 3:
                        GarageHandler.AddVehicle(VehicleType.Bus);
                        break;
                    case 4:
                        GarageHandler.AddVehicle(VehicleType.Boat);
                        break;
                    case 5:
                        GarageHandler.AddVehicle(VehicleType.Airplane);
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

    private static void SearchForRegistrationNumberMenu()
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
                GarageHandler.SearchForRegistrationNumber(registrationNumber);
            }
        } while (continueMenu);
    }

    private static void SearchForVehicleMenu()
    {

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
