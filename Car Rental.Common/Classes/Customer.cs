using Car_Rental.Common.Interfaces;

namespace Car_Rental.Common.Classes;
public class Customer : IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int SSN { get; set; }
    public Customer(int id, string firstName, string lastName, int sSN)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        SSN = sSN;
    }
    public Customer()
    {

    }
}
