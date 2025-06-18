namespace Garage.Handlers;

public static class InputHandler
{

    public static bool ValidateStringInput(string userInput)
    {
        if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput))
        {
            InvalidInputMessage("Input not valid. Try again");
            return false;
        }
        else
        {
            return true;
        }
    }
    public static bool ValidateIntInput(string userInput, out int number)
    {
        if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput) || !int.TryParse(userInput, out number))
        {
            number = -1;
            InvalidInputMessage("Input must be a number. Try again");
            return false;
        }
        if (number < 0)
        {
            InvalidInputMessage("Number must be zero or positive. Try again.");
            return false;
        }
        else
        {
            return true;
        }
    }
    public static void InvalidInputMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    public static void ValidInputMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();

    }
}
