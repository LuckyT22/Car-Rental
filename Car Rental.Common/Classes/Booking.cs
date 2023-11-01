using Car_Rental.Common.Enums;
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
    public double? Distance { get; set; }
    public string? RentedDate { get; set; }
    public string? ReturnDate { get; set; }
    public VechicleStatuses status { get; set; }
    public int? dailyCost { get; set; }

    public Booking(int id, IVehicle vehicle, IPerson customer)
    {
        Id = id;
        Vehicle = vehicle;
        Customer = customer;
        RegNum = vehicle.regNum;
        Odometer = vehicle.odometer;
        dailyCost = vehicle.dailyCost;
        RentedDate = DateTime.Now.ToString("d/M/yyyy");
        Distance = vehicle.costKM;
    }
    public Booking()
    {
        
    }
}
