namespace App;

public class Patient
{
    public string Email;
    public string Password; 
    

    public Patient(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public bool CheckPassword(string password)
    {
        return Password == password;
    }
}