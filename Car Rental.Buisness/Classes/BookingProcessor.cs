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
    public IEnumerable<IVehicle> GetVehicles(VehicleStatuses status = default) { return _db.Get<IVehicle>(null); }


    //public IPerson? GetPerson(int SSN) { return _db.Get<IPerson>(p => p.SSN == SSN).SingleOrDefault(); }
    //public IVehicle? GetVehicle(int vehicleId) { return _db.Get<IVehicle>(v => v.Id == vehicleId).SingleOrDefault(); }
    //public IVehicle? GetVehicle(string regNo) { return _db.Get<IVehicle>(v => v.regNum == regNo).SingleOrDefault(); }

    public async Task<IEnumerable<IBooking>> RentVehicle(int vehicleID, int customerID)
    { 
        if (vehicleID != null && customerID != null)
        {
            var newBooking = _db.RentVehicle(vehicleID, customerID);
            await _db.Add(newBooking);
            return GetBookings();
        }
        else
        {
            throw new ArgumentException();
        }
    }
    public IBooking ReturnVehicle(int vehicleID, double distance)
    {

            var newB = _db.ReturnVehicle(vehicleID);
            newB.ReturnVehicle(newB.Vehicle, distance);
            newB.Distance = distance;
            newB.status = VehicleStatuses.Booked;
            return newB;

        //try
        //{
        //}
        //catch (Exception)
        //{
        //    throw new Exception();
        //}    
    }
  /*  public lägg till asynkron returdata typ Rentvehicle(int vehicleid, int customerid)
    {
        använd task.delay för att simulera tiden det tar
        att hämta data från ett api.
    }*/
    public async Task AddVehicle(string make, string registrationNumber, double
   odometer, double costKm, VehicleTypes type, VehicleStatuses status)
    {
        if (make != null && registrationNumber is not null && odometer != null && odometer !=0 && costKm != null && costKm !=0 && status != null && type != null && type !=0)
        {
            if (type == VehicleTypes.Motorcycle)
            {
                EmptyVehicle = new Motorcycle(_db.NextVehicleId, registrationNumber, make, odometer, costKm, type, status);
                await _db.Add((IVehicle)EmptyVehicle);
                EmptyVehicle = new();
            }
            else
            {
                EmptyVehicle = new Car(_db.NextVehicleId, registrationNumber, make, odometer, costKm, type, status);
                await _db.Add((IVehicle)EmptyVehicle);
                EmptyVehicle = new();
            }
        }
    }
    public async Task AddCustomer(int socialSecurityNumber, string firstName, string
   lastName)
    {
        if (socialSecurityNumber != null && firstName is not null && lastName is not null && _db.NextPersonId!=null)
        {
            EmptyCustomer = new Customer(_db.NextPersonId, firstName, lastName, socialSecurityNumber);
            await _db.Add((IPerson)EmptyCustomer);
            EmptyCustomer = new();
        }
    }
    // Calling Default Interface Methods
    public string[] VehicleStatusNames => _db.VehicleStatusNames;
    public string[] VehicleTypeNames => _db.VehicleTypeNames;
    public VehicleTypes GetVehicleType(string name) => _db.GetVehicleType(name);
}