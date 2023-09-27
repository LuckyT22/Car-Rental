using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Motorcycle : IVehicle
{
    public string regNum { get; set; }
    public string make { get; set; }
    public int odometer { get; set; }
    public double costKM { get; set; }
    public VehicleTypes vehicleTypes { get; set; }
    public int vehicleTypesInt { get; set; }
    public VechicleStatuses status { get; set; }
    public Motorcycle(string RegNum, string Make, int Odometer, double CostKM, VehicleTypes type, int VehicleTypesInt, VechicleStatuses Status)
    {
        regNum = RegNum;
        make = Make;
        odometer = Odometer;
        costKM = CostKM;
        vehicleTypes = type;
        vehicleTypesInt = (int)VehicleTypes.Motorcycle;
        status = Status;

    }
}
