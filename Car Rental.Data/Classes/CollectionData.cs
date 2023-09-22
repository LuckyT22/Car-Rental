using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Classes;
using Car_Rental.Data.Interfaces;
using System;

namespace Car_Rental.Data.Classes;

public class collectionData : IData
{
    readonly List<IPerson> _persons = new List<IPerson>();
    readonly List<IVehicle> _vehicles = new List<IVehicle>();
    readonly List<IBooking> _bookings = new List<IBooking>();

    public collectionData() => SeedData();

    void SeedData()
    {
        _vehicles.Add(new Car("ABC123", "Volvo", 10000, 1, VehicleTypes.Combi, (int)VehicleTypes.Combi));
        _vehicles.Add(new Car("DEF456", "Saab", 20000, 1, VehicleTypes.Sedan, (int)VehicleTypes.Sedan));
        _vehicles.Add(new Car("GHI789", "Tesla", 1000, 3, VehicleTypes.Sedan, (int)VehicleTypes.Sedan));
        _vehicles.Add(new Car("JKL012", "Jeep", 5000, 1.5, VehicleTypes.Van, (int)VehicleTypes.Van));
        _vehicles.Add(new Motorcycle("MNO234", "Yamaha", 30000, 0.5, VehicleTypes.Motorcycle, (int)VehicleTypes.Motorcycle));
        _bookings.Add(new Booking("GHI789", "Doe John (12345)", 1000, null, DateTime.Now.ToString("d/M/yyyy"), null, null));
        _bookings.Add(new Booking("JKL012", "Doe Jane (98765)", 5000, 5000, DateTime.Now.ToString("d/M/yyyy"), DateTime.Now.ToString("d/M/yyyy"), 300));
        _persons.Add(new Customer("John", "Doe", 12345));
        _persons.Add(new Customer("Jane", "Doe", 98765));
    }

    public IEnumerable<IPerson> GetPersons() => _persons;
    public IEnumerable<IBooking> GetBookings() => _bookings;
    public IEnumerable<IVehicle> GetVehicles(/*VehicleStatuses status = default*/) => _vehicles;
}