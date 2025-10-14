namespace App;

public class SaveData
{
  // Här ligger befintliga metoder/lagring orörda.

  // Filnamn för radbaserad permissions-lagring (username;flagsInt;region).
  static readonly string PermsFile = "permissions.txt";

  // Läser hela permissions-store till ett dictionary (tom om fil saknas eller rader ogiltiga).
  public static System.Collections.Generic.Dictionary<string, (Permission perms, string region)> LoadPermissions()
  {
    var dict = new System.Collections.Generic.Dictionary<string, (Permission, string)>(System.StringComparer.OrdinalIgnoreCase);
    if (!System.IO.File.Exists(PermsFile)) return dict;
    foreach (var line in System.IO.File.ReadAllLines(PermsFile))
    {
      if (string.IsNullOrWhiteSpace(line)) continue;
      var parts = line.Split(';');
      if (parts.Length < 3) continue;
      var username = parts[0]?.Trim() ?? string.Empty;
      if (username.Length == 0) continue;
      if (!int.TryParse(parts[1], out var flagsInt)) continue;
      var region = parts[2] ?? string.Empty;
      dict[username] = ((Permission)flagsInt, region);
    }
    return dict;
  }

  // Skriver hela permissions-store till fil (true vid lyckad skrivning).
  public static bool SavePermissions(System.Collections.Generic.Dictionary<string, (Permission perms, string region)> data)
  {
    try
    {
      var lines = new System.Collections.Generic.List<string>(data.Count);
      foreach (var kvp in data)
      {
        var username = kvp.Key ?? string.Empty;
        var flagsInt = ((int)kvp.Value.perms).ToString();
        var region = kvp.Value.region ?? string.Empty;
        lines.Add($"{username};{flagsInt};{region}");
      }
      System.IO.File.WriteAllLines(PermsFile, lines);
      return true;
    }
    catch
    {
      return false;
    }
  }

  // Försöker hämta en användares permissions och region (false om okänd användare).
  public static bool TryGetPermissions(string username, out Permission perms, out string region)
  {
    perms = Permission.None;
    region = string.Empty;
    var dict = LoadPermissions();
    if (!dict.TryGetValue(username, out var tuple)) return false;
    perms = tuple.perms;
    region = tuple.region ?? string.Empty;
    return true;
  }

  // Försöker sätta permissions/region för en existerande användare (false om okänd eller skrivfel).
  public static bool TrySetPermissions(string username, Permission perms, string region)
  {
    var dict = LoadPermissions();
    if (!dict.ContainsKey(username)) return false;
    dict[username] = (perms, region ?? string.Empty);
    return SavePermissions(dict);
  }
}
