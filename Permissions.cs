namespace App;


[System.Flags]
// Rättigheter som kan kombineras med bitflaggor.
public enum Permission
{
    None = 0,
    ManagePermissions = 1 << 0,
    MangageLocations = 1 << 1,
    ManagePersonnels = 1 << 2,
    ManageRegistrations = 1 << 3,
    ManageJournals = 1 << 4,
    ManageAppointments = 1 << 5,
    ManageLocalAdmins = 1 << 6,
}


