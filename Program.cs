using System.Reflection.Metadata;
using App;
static void Admin_meny()
{
    Console.WriteLine("1. To give admins more permissions in their respective Location");
    Console.WriteLine("2. To give an admin a specific region");
    Console.WriteLine("3. To Handle registrations");
    Console.WriteLine("4. To Add locations");
    Console.WriteLine("5. To accept/deny user registration to become patients");
    Console.WriteLine("6. To create Personnel accounts");
    Console.WriteLine("7. Watch the acces list ");
}


Admin_meny();


static void Give_Admin_permision()
{
    Console.WriteLine("Give a User the Admin permissions in that location// type the name och the person to give Admin permissions");
     foreach (user in users)
    {

        Console.WriteLine(users.username);



    }
    Console.WriteLine("Write one of theese names to give them admin");

    string input = Console.ReadLine()!;
    
    
  




}