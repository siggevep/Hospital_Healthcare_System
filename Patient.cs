namespace App;

public class Patient : IUser
{
    public string Username;
   string Password; 
    

    public Patient(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public bool CheckPassword(string password)
    {
         return username == Username && password == Password;
    }


public bool IsRole(Role role)
    {
        return Role.Patient == role;
        
    }
    public Role GetRole()
    {
        return Role.Patient;


    }
}