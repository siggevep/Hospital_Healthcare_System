
namespace App;

class Personnel : IUser
{
    public string Username;
    string Password;

    public string Person_nummer;

    public Personnel(string username, string password, string person_nummer)
    {
        Username = username;
        Password = password;
        Person_nummer = person_nummer;

    }

    public bool TryLogin(string username, string password, string person_nummer)
    {
        return username == Username && password == Password && Person_nummer == Person_nummer;

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
