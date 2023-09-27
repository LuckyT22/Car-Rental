using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;
using System.Runtime.Intrinsics.X86;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public string RegNum { get; set; }
    public string Customer { get; set; }
    public int KmRented { get; set; }
    public int? KmReturned { get; set; }
    public string RentedDate { get; set; }
    public string? ReturnDate { get; set; }
    public int? VehicleTypesDailyCost { get; set; }
    public VechicleStatuses status { get; set; }
    
    public Booking(string regnum, string customer, int kmRented, int? kmReturned, string rentedDate, string? returnDate, int? dailyCost,VechicleStatuses Status)
    {
        RegNum = regnum;
        Customer = customer;
        KmRented = kmRented;
        KmReturned = kmReturned;
        RentedDate = rentedDate;
        ReturnDate = returnDate;
        VehicleTypesDailyCost = dailyCost;
        status = Status;
    }
}
