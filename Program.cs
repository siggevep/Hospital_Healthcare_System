using System.Reflection.Metadata;
using App;
static void Admin_meny()
{
    Console.WriteLine("1. To give admins more permissions in their respective Location");
    Console.WriteLine("2. To give an admin a specific region");
    Console.WriteLine("3. To handle registrations");
    Console.WriteLine("4. To add locations");
    Console.WriteLine("5. To accept/deny user registration to become patients");
    Console.WriteLine("6. To create accounts för personell");
    Console.WriteLine("7. Watch the access list ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1" : Give_Admin_permission(); break;
        case "2" : Give_Admin_specific_region(); break;
        case "3" : Handle_Registrations(); break;
        case "4" : Add_Locations(); break;
        case "5" : Give_Admin_permission_To_Register_Accounts(); break;
        case "6" : Create_Accounts_For_Personell(); break;
        case "7" : View_access(); break;
        
        

    }


}




static void Give_Admin_permission()
{
    Console.WriteLine("Give a User the Admin permissions in that location// type the name och the person to give Admin permissions");
    string input = Console.ReadLine();
    string input_2 = Console.ReadLine();



    foreach (IUser user in Users)
        if (user.TryLogin(input, input_2))
        {
            user.GetRole(Local_Admin);
            File.WriteAllText("./Local_Admin.txt", user.username + "  " + user.password); // Måste ändra till APPENDalltext plus måste fixa så att det står \n i slutet för annars skrivs alla namn och lösenord på en lång rad ,precis som denna raden
            break;

        }

}

