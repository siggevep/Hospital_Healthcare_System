namespace App;

class Journal
{
  public string? PatientName;
  public string? Date;
  public string? Titel;
  public string? Description;
  public string? Attachment;

  public Journal(string? patientname, string? date, string? titel, string? description, string? attachment)
  {
    PatientName = patientname;
    Date = date;
    Titel = titel;
    Description = description;
    Attachment = attachment;

  }

}