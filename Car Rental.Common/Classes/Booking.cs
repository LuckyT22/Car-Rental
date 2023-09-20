using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;

public class Booking : IBooking
{
    public bool Available { get; set; }

    public void Get(bool available)
    {
        Available = available;
    }
}
