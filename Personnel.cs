namespace App;

class Personnel : IUser
{
    public string Username;
    string Password;

    public Personnel(string username, string password)
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
        return Role.Personnel == role;
        
    }
public Role GetRole()
    {
        return Role.Personnel;
        
    }


}