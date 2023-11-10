using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    public int Id { get; set; }
    public IVehicle Vehicle { get; set; }
    public IPerson Customer { get; set; }
    public double Odometer { get; set; }
    public double Distance { get; set; }
    public DateTime RentedDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public VehicleStatuses status { get; set; }
    public double kmCost { get; set; }
    public double dailyCost { get; set; }
    public bool isOpen { get; set; }
    public double TotalCost { get; set; }
    public double ReturnVehicle(IVehicle vehicle, double distance);
}
