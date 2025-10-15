using System.Reflection.Metadata;
using App;

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
                if(active_user.IsRole(Role.User))
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
