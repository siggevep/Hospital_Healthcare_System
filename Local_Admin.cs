using System.Security.Cryptography.X509Certificates;

namespace App;
class Local_Admin : IUser
{

    public string Username;
    string Password;

    public string Person_nummer;


    

    public Local_Admin(string username, string password, string person_nummer)
    {
        Username = username;
        Password = password;
        Person_nummer = person_nummer;

    }
    
    public bool TryLogin(string username, string password, string person_nummer)
    {
        return username == Username && password == Password && Person_nummer == person_nummer;

    }
     
public bool IsRole(Role role)
    {
        return Role.Local_Admin == role;
        
    }
    public Role GetRole()
    {
        return Role.Local_Admin;

    }

   
    


}