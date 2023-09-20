using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Enums;
using Car_Rental.Common.Classes;
using Car_Rental.Data.Interfaces;

namespace Car_Rental.Data.Classes;

public class collectionData : IData
{
    readonly List<IPerson> _persons = new List<IPerson>();
    readonly List<IVehicle> _vehicles = new List<IVehicle>();
    readonly List<IBooking> _bookings = new List<IBooking>();

    public collectionData() => SeedData();

    void SeedData()
    {
        _vehicles.Add(new Car("ABC123", "Volvo", 10000, 1, "Combi", 200));
        _vehicles.Add(new Car("DEF456", "Saab", 20000, 1, "Sedan", 100));
        _vehicles.Add(new Car("GHI789", "Tesla", 1000, 3, "Sedan", 100));
        _vehicles.Add(new Car("JKL012", "Jeep", 5000, 1.5, "Van", 300));
        _vehicles.Add(new Motorcycle("MNO234", "Yamaha", 30000, 0.5, "Motorcycle", 50));
        _bookings.Add(new Booking());
    }

    public IEnumerable<IPerson> GetPersons() => _persons;
    public IEnumerable<IBooking> GetBookings() => _bookings;
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) => _vehicles;
}