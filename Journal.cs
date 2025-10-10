namespace App;

class Journal
{
  string? PatientName;
  string? Date;
  string? Titel;
  string? Description;
  string? Attachment;

  public Journal(string? patientname, string? date, string? titel, string? description, string? attachment)
  {
    PatientName = patientname;
    Date = date;
    Titel = titel;
    Description = description;
    Attachment = attachment;

  }

  public string? GetPatientName()
  {
    return PatientName;
  }
  public string? GetDate()
  {
    return Date;
  }
  public string? GetTitel()
  {
    return Titel;
  }
  public string? GetDescription()
  {
    return Description;
  }
  public string? GetAttatchment()
  {
    return Attachment;
  }
}
