namespace eShop.ServiceLayer.ModelsDTO;

public class CustomerDTO
{
    public int PrivateNumber { get; set; } 
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string ZipCode { get; set; }
    public bool IsAdmin { get; set; }

    public CustomerDTO(string fname, string lname, string email, string adress)
    {
        Firstname = fname;
        Lastname = lname;
        Email = email;
        Address = adress;
    }
    public CustomerDTO(int privateNumber, string fname, string lname, string zipcode, string email, string adress, bool isAdmin)
    {
        PrivateNumber = privateNumber;
        Firstname = fname;
        Lastname = lname;
        ZipCode = zipcode;
        Email = email;
        Address = adress;
        IsAdmin = isAdmin;
    }
}
