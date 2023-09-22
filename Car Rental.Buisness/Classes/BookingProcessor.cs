using Car_Rental.Data.Interfaces;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Enums;
using Car_Rental.Data.Classes;

namespace Car_Rental.Buisness.Classes;

public class BookingProcessor
{
    readonly collectionData _db;

    public BookingProcessor()
    {
        _db = new collectionData();
    }
    public IEnumerable<IPerson> GetCustomers()
    {
        return _db.GetPersons();
    }
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default)
    {
        return _db.GetVehicles();
    }
    public IEnumerable<IBooking> GetBookings()
    {
        return _db.GetBookings();
    }
}
