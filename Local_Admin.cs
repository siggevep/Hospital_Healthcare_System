namespace App;
class Local_Admin : IUser
{
    public string Username;
    string Password;

    public Local_Admin(string username, string password)
    {
        Username = username;
        Password = password;

    }
    
    public bool TryLogin(string username, string password)
    {
        return username == Username && password == Password;

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