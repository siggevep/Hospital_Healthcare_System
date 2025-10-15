namespace App;

class Local_Admin_Permission
{
 
 // Add new Locations
  public static void NewLocation(string? LocationName, string? HospitalName)
  {
    List<string?> Locations = new List<string?>();
    Locations.Add(LocationName, HospitalName);

  }

  // Give admins the permission to create accounts for personnel.
  public static void NewPersonnel(string? personnelemail, string? personnelpassword)
  {
    List<string?> personnels = new List<string?>();
    personnels.Add(personnelemail, personnelpassword);
  }

  // För att visa Locations
  public static void ShowLocations()
  {
    if (Locations.Count == 0)
    {
      Console.WriteLine("inga platser");
      return;
    }
    Console.WriteLine("Platser:");
    int i = 0;
    while (i < Locations.Count)
    {
      Console.WriteLine("- "+ Locations[i].ToString());
      i = i + 1;
    }
  }

  // Skapar Registreringsförfrågan
  public static void CreateRegistration (string userEmail, string password)
  {
    Registrations.Add(new Registration (UserEmail, password, RegistrationsStatus.Pending));
  }

  // Pendings
  ///code....




  // Handle registration

  public static bool AcceptNewPatient()
  {
    int i = 0; 
    while (i < Registrations.Count)
    {
      Registration reg = Registrations[i];
      if (reg.UserEmail == UserEmail && reg.Status == RegistrationStatus.Pending)
      {
        reg.Status == RegistrationStatus.Accept;
        Console.WriteLine("Registrering är godkänd. Välkommen " reg.UserEmail);
        return true;
      }
      i = i + 1;

    }

  } 


}

// för registrering
class Registration
{
  public string UserEmail;
  public string Password;

  public RegistrationStatus Status;

  public Registration(string useremail, string password, RegistrationStatus status)
  {
    UserEmail = useremail;
    Password = password;
    Status = status;

  }



} 
public enum RegistrationStatus
{
  Pending,
  Accept,
  Deny,
//edit for comitt
}
