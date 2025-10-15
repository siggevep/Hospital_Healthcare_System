namespace App;

public class Main_Admin : IUser
{
  public string? Username;

  public string? Password;

  public Main_Admin(string? username, string? password)
  {
    Username = username;
    Password = password;

  }

  public bool TryLogin(string? username, string? password)
  {
    return username == Username && password == Password;
  }
  public bool IsRole(Role role)
  {
    return Role.Main_Admin == role;
  }
  public Role GetRole()
  {
    return Role.Main_Admin;
  }
  
}
