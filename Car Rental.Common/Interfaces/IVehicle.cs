using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    public string regNum { get; set; }
    public string make { get; set; }
    public int odometer { get; set; }
    public double costKM { get; set; }
    public VehicleTypes vehicleTypes { get; set; }
    public int vehicleTypesInt { get; set; }
    public VechicleStatuses status { get; set; }
}
