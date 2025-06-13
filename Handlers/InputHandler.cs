namespace Garage.Handlers;

public static class InputHandler
{
    public static bool ValidateInput(string userInput, bool successfulInput, int usersChoice)
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
    }
    public static bool ValidateBoolInput(string userInput)
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
    public static bool ValidateIntInput(string userInput, out int number)
    {
        if (string.IsNullOrEmpty(userInput))
        {
            number = -1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Input not valid. Try again");
            Console.WriteLine(" ");
            Console.ResetColor();
            return false;
        }
        if (!int.TryParse(userInput, out number))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Input is not a valid number. Try again.\n");
            Console.ResetColor();
            return false;
        }
        else
        {
            return true;
        }
    }
}
