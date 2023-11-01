using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    public int Id { get; set; }
    public IVehicle Vehicle { get; set; }
    public IPerson Customer { get; set; }
    public double Odometer { get; set; }
    public double? Distance { get; set; }
    public string? RentedDate { get; set; }
    public string? ReturnDate { get; set; }
    public VechicleStatuses status { get; set; }
    public int? dailyCost { get; set; }
}
