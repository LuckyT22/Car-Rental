using Car_Rental.Common.Classes;
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.ExtentionMethods;

public class VehicleExtentions
{
    public static int Duration(DateTime start, DateTime returned, IVehicle vechicleDailyCost)
    {
        var totalDays = 0;
        var tDays = (returned - start).TotalDays;
        if (tDays < 2) 
        {
            totalDays = 1;
        }
        else
        {
            totalDays = (int)tDays;
        }
        totalDays = totalDays *= vechicleDailyCost.dailyCost;
        return totalDays;
    }
    public static double kmDriven(double distance, double kmCost) => distance * kmCost;
}
