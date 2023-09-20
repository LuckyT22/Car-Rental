using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Car : IVehicle
{
    public string regNum { get; set; }
    public string make { get; set; }
    public int odometer { get; set; }
    public double costKM { get; set; }
    public string vehicleType { get; set; }
    public int dailyCost { get; set; }

    public Car(string RegNum, string Make, int Odometer, double CostKM, string VehicleType, int DailyCost)
    {
        regNum = RegNum;
        make = Make;
        odometer = Odometer;
        costKM = CostKM;
        vehicleType = VehicleType;
        dailyCost = DailyCost;
    }
}
