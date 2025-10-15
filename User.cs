namespace App;

class User : IUser
{

    public string Username;
    string Password;

    public string Person_nummer;

    public User(string username, string password, string person_nummer)
    {
        Username = username;
        Password = password;
        Person_nummer = person_nummer;


    }
public bool TryLogin(string username, string password, string person_nummer)
    {

        return Username == username && Password == password && Person_nummer == Person_nummer;
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