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
// Creat a registration class in order to send a patient's account request

public class Registrasion
{

  public string? PatientPersonalNumber;
  public string? PatientPassword;
  public RegistrationStatus Registration_Status;

  public Registrasion(string? patientperssonalnumber, string? patientpassword, RegistrationStatus registration_status)
  {
    PatientPersonalNumber = patientperssonalnumber;
    PatientPassword = patientpassword;
    Registration_Status = registration_status;

  }

  public void Pending()
  {
    Registration_Status = RegistrationStatus.Pending;


  }
  public void accept()
  {
    Registration_Status = RegistrationStatus.Accept;


  }
  public void Deny()
  {
    Registration_Status = RegistrationStatus.Deny;


  }
}
