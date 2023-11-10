using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IVehicle
{
    public string regNum { get; set; }
    public string make { get; set; }
    public double odometer { get; set; }
    public double costKM { get; set; }
    public VehicleTypes type { get; set; }
    public int dailyCost { get; set; }
    public VehicleStatuses status { get; set; }
    public int Id { get; set; }
    public void ChangeStatus(VehicleStatuses stat);
    public void UpdateOdometer(double km);
}
