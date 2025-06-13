using Garage.Enum;
using Garage.Models;
using Garage.UI;
using System.Threading.Channels;

namespace Garage.Handlers;

internal static class GarageHandler
{


    public static void VehicleList() {

        Garage<Vehicle> garage = new Garage<Vehicle>();
    }

    public static void VehicleList(int capacity)
    {
        Garage<Vehicle> garage = new Garage<Vehicle>(capacity);
    }

    public static void AddVehicle(VehicleType vehicle)
    {

    }

    public static void RemoveVehicle()
    {

    }

    internal static void SearchForRegistrationNumber(string registrationNumber)
    {

    }

    internal static void GetVehicleList()
    {

    }

    internal static void GetVehicleTypesAndCount()
    {

    }
}
