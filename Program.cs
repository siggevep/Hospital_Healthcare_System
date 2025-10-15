using System.Reflection.Metadata;
using App;

IUser? active_user = null;
bool running = true;

List<IUser> users = new List<IUser>();

users.Add(new Local_Admin("Lukas", "Eriksson"));


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
            if(active_user!.IsRole(Role.Local_Admin))
            {
                Console.WriteLine("hello Main admin");
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

