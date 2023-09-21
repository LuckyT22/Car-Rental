using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;
public class Customer : IPerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int SSN { get; set; }

    public Customer(string firstName, string lastName, int sSN) =>
        (FirstName, LastName, SSN) = (firstName, lastName, sSN);   
}
