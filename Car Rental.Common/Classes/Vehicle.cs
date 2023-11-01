using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Vehicle : IVehicle
{
    public string regNum { get; set; }
    public string make { get; set; }
    public double odometer { get; set; }
    public double costKM { get; set; }
    public VehicleTypes type { get; set; }
    public int dailyCost { get; set; }
    public VechicleStatuses status { get; set; }
    public int Id { get; set; }
}
