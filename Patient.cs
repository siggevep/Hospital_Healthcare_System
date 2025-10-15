
namespace App;

class Patient: IUser
{

    public string Username;
    string Password;

    public string SSN;

    public Patient(string username, string password)
    {
        Username = username;
        Password = password;


    }
public bool TryLogin(string username, string password)
    {

        return Username == username && Password == password;
    }


    public bool IsRole(Role role)
    {
        return Role.User == role;
    }

public Role GetRole()
        {
        return Role.User;
    }

}