namespace App;

interface IUser
{
    public bool TryLogin(string username, string password, string person_nummer);

    public bool IsRole(Role role);
    
    
    

    public Role GetRole();

}

enum Role
{
    None,
    User,
    Patient,
    Main_Admin,
    Local_Admin,
    Personnel,

}