namespace App;

interface IUser
{
    public bool TryLogin(string username, string password);

}

enum Role
{
    None,
    User,
    Patient,
    Main_Admin,
    Local_Admin,



}