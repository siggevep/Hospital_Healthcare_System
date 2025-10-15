namespace App;

interface IUser
{
    public bool TryLogin(string username, string password);

    public bool IsRole(Role role);

    public Role GetRole();

}

public enum Role
{
    None,
    User,
    Patient,
    Main_Admin,
    Local_Admin,
    Personnel,

}
public enum RegistrationStatus
{
    // All registrasions default falue is pending
    Pending,
    Accept,
    Deny,
}