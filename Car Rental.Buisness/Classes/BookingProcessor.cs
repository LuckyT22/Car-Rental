using Car_Rental.Data.Interfaces;
using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using Car_Rental.Common.Enums;
using Car_Rental.Data.Classes;
using System;
using System.Runtime.Intrinsics.X86;

namespace Car_Rental.Buisness.Classes;
public class BookingProcessor
{
    private readonly IData _db;
    public BookingProcessor(IData db) => _db = db;

    public Customer EmptyCustomer = new();
    public Vehicle EmptyVehicle = new();
    public Booking EmptyBooking = new();
    public IEnumerable<IBooking> GetBookings() { return _db.Get<IBooking>(null); }
    public IEnumerable<IPerson> GetCustomers() { return _db.Get<IPerson>(null); }
    public IPerson? GetPerson(int SSN) { return _db.Get<IPerson>(p => p.SSN == SSN).SingleOrDefault(); }
    public IEnumerable<IVehicle> GetVehicles(VechicleStatuses status = default) { return _db.Get<IVehicle>(null); }
    public IVehicle? GetVehicle(int vehicleId) { return _db.Get<IVehicle>(v => v.Id == vehicleId).SingleOrDefault(); }
    public IVehicle? GetVehicle(string regNo) { return _db.Get<IVehicle>(v => v.regNum == regNo).SingleOrDefault(); }
    // public lägg till asynkron returdata typ RentVehicle(int vehicleId, int
  // customerId)
    //{
        // Använd Task.Delay för att simulera tiden det tar
        // att hämta data från ett API.
    //}
    //public IBooking ReturnVehicle(int vehicleId, double ditance) { }
    public void AddVehicle(string make, string registrationNumber, double
   odometer, double costKm, VehicleTypes type, VechicleStatuses status)
    {
        if (make != null && registrationNumber is not null && odometer != null && costKm != null && status != null && type != null)
        {
            if (type == VehicleTypes.Motorcycle)
            {
                EmptyVehicle = new Motorcycle(_db.NextVehicleId, registrationNumber, make, odometer, costKm, type, status);
                _db.Add((IVehicle)EmptyVehicle);
            }
            else
            {
                EmptyVehicle = new Car(_db.NextVehicleId, registrationNumber, make, odometer, costKm, type, status);
                _db.Add((IVehicle)EmptyVehicle);
            }
        }
    }
    public void AddCustomer(int socialSecurityNumber, string firstName, string
   lastName)
    {
        if (socialSecurityNumber != null && firstName is not null && lastName is not null && _db.NextPersonId!=null)
        {
            EmptyCustomer = new Customer(_db.NextPersonId, firstName, lastName, socialSecurityNumber);
            _db.Add((IPerson)EmptyCustomer);
        }
    }
    // Calling Default Interface Methods
    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);
}