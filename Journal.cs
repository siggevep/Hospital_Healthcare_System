namespace App;

class Journal
{
  string? PatientName;
  string? Date;
  string? Titel;
  string? Description;
  string? Attechment;

  public Journal (string? patientname, string? date, string? titel, string? description, string? attechment)
  {
    PatientName = patientname;
    Date = date;
    Titel = titel;
    Description = description;
    Attechment = attechment;
    
  }
}
