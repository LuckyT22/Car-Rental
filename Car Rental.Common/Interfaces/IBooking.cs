using Car_Rental.Common.Enums;

namespace Car_Rental.Common.Interfaces;

public interface IBooking
{
    public string RegNum { get; set; }
    public string Customer { get; set; }
    public int KmRented { get; set; }
    public int? KmReturned { get; set; }
    public string RentedDate { get; set; }
    public string? ReturnDate { get; set; }
    public VechicleStatuses status { get; set; }
}
