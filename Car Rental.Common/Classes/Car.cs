﻿using Car_Rental.Common.Enums;
using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Car : Vehicle
{
    public Car(int id, string RegNum, string Make, double Odometer, double CostKM, VehicleTypes Type, VechicleStatuses Status)
    {
        Id = id;
        regNum = RegNum;
        make = Make;
        odometer = Odometer;
        costKM = CostKM;
        type = Type;
        dailyCost = (int)Type;
        status = Status;
    }
    public Car()
    {
        
    }
}
