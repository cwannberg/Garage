

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
            Console.WriteLine("5. Set capacity for a new garage");
            Console.WriteLine("6. Find vehicle by registration number");
            Console.WriteLine("7. Search for vehicle by specific characteristics");
            Console.WriteLine("8. Exit application");
            Console.WriteLine("-------------------------------------------------------------");
            Console.Write("Your choice: ");

            string userInput = Console.ReadLine();

            bool successfulInput = int.TryParse(userInput, out int usersChoice);

            if (ValidateInput(userInput, successfulInput, usersChoice))
            {
                switch (usersChoice)
                {
                    case 1:
                        //View list of parked vehicles
                        break;
                    case 2:
                        //View vehicle types and their counts
                        break;
                    case 3:
                        //Add a vehicle
                        break;
                    case 4:
                        //Remove a vehicle
                        break;
                    case 5:
                        //Set capacity for a new garage
                        break;
                    case 6:
                        //Find vehicle by registration number
                        SearchForRegistrationNumberMenu();
                        break;
                    case 7:
                        SearchForVehicleMenu();
                        //Search for a vehicle by a specific characteristic
                        break;
                    case 8:
                        //Exit application
                        continueMenu = false;
                        break;
                    default:
                        break;
                }
            }
        } while (continueMenu);
    }


    private static bool ValidateInput(string userInput, bool successfulInput, int usersChoice)
    {
        if (string.IsNullOrEmpty(userInput) || !successfulInput || usersChoice > 8)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter a valid number");
            Console.WriteLine(" ");
            Console.ResetColor();
            return false;
        }
        else
        {
            return true;
        }
    }private static bool ValidateInput(string userInput)
    {
        if (string.IsNullOrEmpty(userInput))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Input not valid. Try again");
            Console.WriteLine(" ");
            Console.ResetColor();
            return false;
        }
        else
        {
            return true;
        }
    }
    private static void SearchForRegistrationNumberMenu()
    {
        bool continueMenu = true;

        do
        {
            Console.WriteLine("6. Search for car by registration number");
            Console.WriteLine("Go back to mainmenu by pressing 0");
            Console.WriteLine("Enter registration number: ");
            string registrationNumber = Console.ReadLine().ToLower();
            if (registrationNumber.Equals("0"))
            {
                BackToMainMenu();
            }
            if (ValidateInput(registrationNumber))
            {

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
        if (ValidateInput(userInput)){
            if (userInput.Equals("y")){
                ShowWelcomeMessage();
            }
            
        }
    }   
}
