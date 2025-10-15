namespace App;

[System.Flags]
// Rättigheter som kan kombineras med bitflaggor.
public enum Permission
{
  None                = 0,
  ManagePermissions   = 1 << 0,
  AddLocation         = 1 << 1,
  RemoveLocation      = 1 << 2,
  CreatePersonnel     = 1 << 3,
  RemovePersonnel     = 1 << 4,
  HandleRegistrations = 1 << 5,
}

class Local_Admin_Permission
{
  // Event som signalerar att en användares permissions har ändrats.
  public static event System.Action<string, Permission>? PermissionsChanged;

  // Event som signalerar att en användares region har ändrats.
  public static event System.Action<string, string>? RegionChanged;

  // Returnerar alla användares (username, perms, region) från lagringen.
  public static System.Collections.Generic.List<(string Username, Permission Perms, string Region)> ListAll()
  {
    var dict = SaveData.LoadPermissions();
    var list = new System.Collections.Generic.List<(string, Permission, string)>();
    foreach (var kvp in dict)
      list.Add((kvp.Key, kvp.Value.perms, kvp.Value.region ?? string.Empty));
    return list;
  }

  // Hämtar permissions och region för en användare, false om okänd.
  public static bool View(string username, out Permission perms, out string region)
  {
    return SaveData.TryGetPermissions(username, out perms, out region);
  }

  // Sätter exakta permissions för en användare (endast om actingAdmin har rätt och target finns).
  public static bool Set(string actingAdmin, string targetUser, Permission newPerms)
  {
    if (IsSelf(actingAdmin, targetUser)) return false;
    if (!AdminHasManagePermissions(actingAdmin)) return false;
    if (!SaveData.TryGetPermissions(targetUser, out var oldPerms, out var region)) return false;
    if (oldPerms == newPerms) return false;
    if (!SaveData.TrySetPermissions(targetUser, newPerms, region)) return false;
    PermissionsChanged?.Invoke(targetUser, newPerms);
    return true;
  }

  // Lägger till en enskild rättighet för en användare (idempotent).
  public static bool Grant(string actingAdmin, string targetUser, Permission perm)
  {
    if (IsSelf(actingAdmin, targetUser)) return false;
    if (!AdminHasManagePermissions(actingAdmin)) return false;
    if (!SaveData.TryGetPermissions(targetUser, out var oldPerms, out var region)) return false;
    var newPerms = oldPerms | perm;
    if (newPerms == oldPerms) return false;
    if (!SaveData.TrySetPermissions(targetUser, newPerms, region)) return false;
    PermissionsChanged?.Invoke(targetUser, newPerms);
    return true;
  }

  // Tar bort en enskild rättighet för en användare (idempotent).
  public static bool Revoke(string actingAdmin, string targetUser, Permission perm)
  {
    if (IsSelf(actingAdmin, targetUser)) return false;
    if (!AdminHasManagePermissions(actingAdmin)) return false;
    if (!SaveData.TryGetPermissions(targetUser, out var oldPerms, out var region)) return false;
    var newPerms = oldPerms & ~perm;
    if (newPerms == oldPerms) return false;
    if (!SaveData.TrySetPermissions(targetUser, newPerms, region)) return false;
    PermissionsChanged?.Invoke(targetUser, newPerms);
    return true;
  }

  // Sätter en användares enda region (kräver ManagePermissions och att target finns).
  public static bool SetRegion(string actingAdmin, string targetUser, string region)
  {
    if (IsSelf(actingAdmin, targetUser)) return false;
    if (!AdminHasManagePermissions(actingAdmin)) return false;
    if (!SaveData.TryGetPermissions(targetUser, out var perms, out var oldRegion)) return false;
    var newRegion = region ?? string.Empty;
    if (System.String.Equals(oldRegion ?? string.Empty, newRegion, System.StringComparison.Ordinal)) return false;
    if (!SaveData.TrySetPermissions(targetUser, perms, newRegion)) return false;
    RegionChanged?.Invoke(targetUser, newRegion);
    return true;
  }

  // Kontrollerar om actingAdmin finns och har ManagePermissions.
  static bool AdminHasManagePermissions(string actingAdmin)
  {
    if (!SaveData.TryGetPermissions(actingAdmin, out var aPerms, out _)) return false;
    return (aPerms & Permission.ManagePermissions) == Permission.ManagePermissions;
  }

  // Jämför två användarnamn case-insensitivt.
  static bool IsSelf(string a, string b)
  {
    return System.String.Equals(a, b, System.StringComparison.OrdinalIgnoreCase);
  }
}

