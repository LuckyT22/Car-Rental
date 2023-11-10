using Car_Rental.Common.Enums;
using Car_Rental.Common.ExtentionMethods;
using Car_Rental.Common.Interfaces;
using System.Runtime.Intrinsics.X86;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public int Id { get; set; }
    public IVehicle Vehicle { get; set; }
    public IPerson Customer { get; set; }
    public string RegNum { get; set; }
    public double Odometer { get; set; }
    public double Distance { get; set; }
    public DateTime RentedDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public VehicleStatuses status { get; set; }
    public double kmCost { get; set; }
    public double dailyCost { get; set; }
    public bool isOpen { get; set; }
    public double TotalCost { get; set; }

    public Booking(int id, IVehicle vehicle, IPerson customer, bool IsOpen = true)
    {
        Id = id;
        Vehicle = vehicle;
        Customer = customer;
        RegNum = vehicle.regNum;
        Odometer = vehicle.odometer;
        Vehicle.ChangeStatus(VehicleStatuses.Available);
        dailyCost = vehicle.dailyCost;
        RentedDate = DateTime.Now;
        Distance = vehicle.costKM;
        isOpen = IsOpen;
    }
    public Booking()
    {
        
    }
    public double ReturnVehicle(IVehicle vehicle, double distance)
    {
        vehicle.ChangeStatus(VehicleStatuses.Booked);
        ReturnDate = DateTime.Now;
        dailyCost = VehicleExtentions.Duration(RentedDate, ReturnDate, vehicle);
        kmCost = VehicleExtentions.kmDriven(distance, vehicle.costKM);
        vehicle.UpdateOdometer(distance);
        TotalCost = dailyCost + kmCost;
        return TotalCost;
        
    }
}
