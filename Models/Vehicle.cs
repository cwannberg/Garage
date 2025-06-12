

namespace Garage.Models
{
    internal class Vehicle
    {

        private string NumberPlate { get; set; }
        private string Color { get; set; }
        private int NumberOfWheels { get; set; }
        private string Fuel { get; set; }
        public Vehicle(string numberPlate, string color, int numberOfWheels, string fuel)
        {
            NumberPlate = numberPlate;
            Color = color;
            NumberOfWheels = numberOfWheels;
            Fuel = fuel;
        }
    }

    class Airplane : Vehicle
    {
        public Airplane(string numberPlate, string color, int numberOfWheels, string fuel, int wingspan) : base(numberPlate, color, numberOfWheels, fuel)
        {
        }
    }

    class Motorcycle : Vehicle
    {
        public Motorcycle(string numberPlate, string color, int numberOfWheels, string fuel, bool hasSidecar) : base(numberPlate, color, numberOfWheels, fuel)
        {
        }
    }

    class Car : Vehicle
    {
        public Car(string numberPlate, string color, int numberOfWheels, string fuel, int numberOfDoors) : base(numberPlate, color, numberOfWheels, fuel)
        {
        }
    }

    class Bus : Vehicle
    {
        public Bus(string numberPlate, string color, int numberOfWheels, string fuel, int passengerCapacity) : base(numberPlate, color, numberOfWheels, fuel)
        {
        }
    }

    class Boat : Vehicle
    {
        public Boat(string numberPlate, string color, int numberOfWheels, string fuel, int horsepower) : base(numberPlate, color, numberOfWheels, fuel)
        {
        }
    }

}
