using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using App;

/*



As an admin with sufficient permissions, I need to be able to give admins the permission to handle the permission system, in fine granularity.

As an admin with sufficient permissions, I need to be able to assign admins to certain regions.

As an admin with sufficient permissions, I need to be able to give admins the permission to handle registrations.

As an admin with sufficient permissions, I need to be able to give admins the permission to add locations.

As an admin with sufficient permissions, I need to be able to give admins the permission to create accounts for personnel.

As an admin with sufficient permissions, I need to be able to give admins the permission to view a list of who has permission to what.

As an admin with sufficient permissions, I need to be able to add locations.

As an admin with sufficient permissions, I need to be able to accept user registration as patients.

As an admin with sufficient permissions, I need to be able to deny user registration as patients.

As an admin with sufficient permissions, I need to be able to create accounts for personnel.

As an admin with sufficient permissions, I need to be able to view a list of who has permission to what.

As personnel with sufficient permissions, I need to be able to view a patients journal entries.

As personnel with sufficient permissions, I need to be able to mark journal entries with different levels of read permissions.

As personnel with sufficient permissions, I need to be able to register appointments.

As personnel with sufficient permissions, I need to be able to modify appointments.

As personnel with sufficient permissions, I need to be able to approve appointment requests.

As personnel with sufficient permissions, I need to be able to view the schedule of a location.

As a patient, I need to be able to view my own journal.

As a patient, I need to be able to request an appointment.

As a logged in user, I need to be able to view my schedule.
*/

IUser? active_user = null;
bool running = true;

List<IUser> users = new List<IUser>();

users.Add(new Local_Admin("Lukas", "Eriksson"));

// Seedar permissions för Lukas om saknas (måste ha ManagePermissions för att kunna ändra andra).
if (!SaveData.TryGetPermissions("Lukas", out var _p, out var _r))
{
    var dict = SaveData.LoadPermissions();
    dict["Lukas"] = (Permission.ManagePermissions, "Skane"); // region valfri/tom string
    SaveData.SavePermissions(dict);
}

// Lyssna på events (loggning eller hooks) – andra delar kan reagera “baserat på event”.
Local_Admin_Permission.PermissionsChanged += (u, perms) =>
{
    Console.WriteLine($"[EVENT] Permissions uppdaterade för {u}: {perms}");
};
Local_Admin_Permission.RegionChanged += (u, region) =>
{
    Console.WriteLine($"[EVENT] Region uppdaterad för {u}: {region}");
};



while (running)
{ // Skapa Main Admin meny så att de kan ha tillgång till allt i systemet
    if (active_user == null)
    {
        System.Console.WriteLine("Log in firsta to open the system");
        System.Console.WriteLine("Username: ");
        string? username = Console.ReadLine();

        System.Console.WriteLine("Password: ");
        string? password = Console.ReadLine();
        foreach (IUser user in users)
        {
            if (user.TryLogin(username, password))
            {
                active_user = user;
                break;
            }
            if (active_user.IsRole(Role.Main_Admin))
            {
                System.Console.WriteLine("------------Welcom to Health Care System-------------");
                System.Console.WriteLine("-----------------------------------------------------");
                System.Console.WriteLine("1. Log in as a user.");

                /*System.Console.WriteLine("4. ");
                System.Console.WriteLine("5. ");
                System.Console.WriteLine("6. ");
                System.Console.WriteLine("7. ");
                System.Console.WriteLine("8. ");
                System.Console.WriteLine("9. ");
                System.Console.WriteLine("10. ");
                System.Console.WriteLine("11. ");
                System.Console.WriteLine("5. ");
                System.Console.WriteLine("5. ");*/
                string? input = Console.ReadLine();

                switch (input) // Kolla Vilken Role
                {
                    case "1": // Role is User
                        if (active_user.IsRole(Role.User))
                        {
                            System.Console.WriteLine($"Welcom {user.GetRole} ");
                            System.Console.WriteLine();
                            System.Console.WriteLine("1. Request registration as a patient.");
                            System.Console.WriteLine("2. Log out user.");
                            string? userinput = Console.ReadLine();
                            if (active_user == null)
                            {
                                System.Console.WriteLine("You should first log in.");

                            }
                            else
                            {
                                // open en switch sats to check the user choice
                                switch (userinput)
                                {
                                    case "1":
                                        System.Console.WriteLine("Enter your Personal number: ");
                                        string? patientperssonalnumber = Console.ReadLine();
                                        System.Console.WriteLine("Enter your password:");
                                        string? patientpassword = Console.ReadLine();
                                        if (patientperssonalnumber != null && patientperssonalnumber !="" && patientpassword != null && patientpassword != "")
                                        {

                                        }
                                        else
                                        {
                                            System.Console.WriteLine("Invalid input. The name or the password is empty");
                                        }
                                        break;
                                    case "2":
                                        break;
                                }
                            }



                        }


                        break;
                    case "2": // Role is Local Admin

                        break;
                    case "3": // Role is 

                        break;

                }

            }
        }




    }
    else
    {
        // Här ska Main Admin meny läggas

    }



}
// skapar första menyn ifall active_user == false. 
while (running)
{
    if (active_user == null)
    {

        //meny valen! Välj med 1-3
        Console.WriteLine("1. Log in");
        Console.WriteLine("2. Create user");
        Console.WriteLine("3. Quit");

        // matar in användarens val
        string menu1 = Console.ReadLine()!;

        // ifall log in väljs.
        if (menu1 == "1")
        {
            Console.WriteLine("Email:");
            string name = Console.ReadLine()!;

            Console.WriteLine("Password:");
            string password = Console.ReadLine()!;
            foreach (IUser user in users)
            {
                if (user.TryLogin(name, password))
                {
                    active_user = user;
                    break;
                }


            }
            // Säker hantering: kontrollera null innan rollkoll.
            if (active_user != null)
            {
                if (active_user.IsRole(Role.Local_Admin))
                {
                    Console.WriteLine("hello Local admin");
                }
                // Lägger bara till dettat temp för att testa User rollen. Pretty basic
                if (active_user.IsRole(Role.User))
                {
                    Console.WriteLine("Hey King");
                }
                // här kan ni lägga Local Admin-logik/meny senare
            }
            else
            {
                Console.WriteLine("Fel användarnamn eller lösenord.");
            }
            //lägga till log in 
            // måste fixa så att du kollar om ditt konto fins
        }

        //ifall create user väljs
        if (menu1 == "2")
        {
            Console.WriteLine("Email:");
            string name = Console.ReadLine()!;

            Console.WriteLine("Password:");
            string password = Console.ReadLine()!;
            users.Add(new User(name, password));

            //lägga till create
            // måste fixa så att din inloggning sparas 

            // Lägg till permissions-post med None + tom region (annars blir användaren 'okänd' för permissions).
            var dict = SaveData.LoadPermissions();
            if (!dict.ContainsKey(name))
            {
                dict[name] = (Permission.None, "");
                SaveData.SavePermissions(dict);
            }
        }

        // ifall quit väljs
        if (menu1 == "3")
        {
            running = false;
            //avsluta programmet. 
        }
    }
    else
    {



    }
}
