namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    public string regNum { get; set; }
    public string make { get; set; }
    public int odometer { get; set; }
    public double costKM { get; set; }
    public string vehicleType { get; set; }
    public int dailyCost { get; set; }
}
