namespace App;

class Local_Admin_Permission
{
  // Add new locations
  public static void NewLocation(string? LocationName, string? HospitalName)
  {
    List<string?> locations = new List<string?>();
    locations.Add(LocationName, HospitalName);
  }
  

}
