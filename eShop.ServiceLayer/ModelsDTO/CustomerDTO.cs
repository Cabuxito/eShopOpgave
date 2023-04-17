using eShop.DataLayer.Entities;
using System.ComponentModel;

namespace eShop.ServiceLayer.ModelsDTO;

public class CustomerDTO
{
    public int PrivateNumber { get; set; } 
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public int ZipCode { get; set; }
    public bool IsAdmin { get; set; } = false;

    public CustomerDTO(string fname, string lname, string email, string address)
    {
        Firstname = fname;
        Lastname = lname;
        Email = email;
        Address = address;
    }
    public CustomerDTO(string fname, string lname, string email,string password, string address, int zipCode) 
    {
        Firstname = fname;
        Lastname = lname;
        Email = email;
        Address = address;
        Password = password;
        ZipCode = zipCode;
    }
    public CustomerDTO(int privateNumber, string fname, string lname, int zipcode, string email, string address, bool isAdmin, string password)
    {
        PrivateNumber = privateNumber;
        Firstname = fname;
        Lastname = lname;
        ZipCode = zipcode;
        Email = email;
        Address = address;
        IsAdmin = isAdmin;
        Password = password;
    }
}
