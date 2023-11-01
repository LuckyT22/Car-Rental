namespace Car_Rental.Common.Interfaces;

public interface IPerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int SSN { get; set; }
    int Id { get; set; }
}
