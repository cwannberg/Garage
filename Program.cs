using Garage.Models;
using Garage.UI;

namespace Garage;

internal class Program
{
    static void Main(string[] args)
    {
        //Test();
       // ConsoleUI.AddVehicleMenu();
        ConsoleUI.ShowWelcomeMessage();
    }

    static void Test()
    {
        Console.WriteLine(Enum.VehicleType.Car.ToString());
        //var car = new Car("ABC123", "red", 4, "diesel", 5);
        //Console.WriteLine($"The car with registration number {car.RegistrationNumber} is {car.Color}. It has {car.NumberOfWheels} wheels, {car.NumberOfSeats} seats and is fueled by {car.Fuel}");

        //var garage = new Garage<Vehicle>(10);
        //garage.Add(car);

        //Console.WriteLine("The garage cointans a vehicle with the registration number: ");
        //foreach(var vehicle in garage)
        //{
        //    Console.WriteLine(vehicle.RegistrationNumber);
        //}
    }
}
