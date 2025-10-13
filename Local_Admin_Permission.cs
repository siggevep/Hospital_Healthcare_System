
namespace App;

class Local_Admin_Permission
{
  // Add new locations
  public static void NewLocation(string? LocationName, string? HospitalName)
  {
    List<string?> locations = new List<string?>();
    locations.Add(LocationName, HospitalName);
  }

  // Give admins the permission to create accounts for personnel.
  public static void NewPersonnel(string? personnelemail, string? personnelpassword)
  {
    List<string?> personnels = new List<string?>();
    personnels.Add(personnelemail, personnelpassword);
  }

}