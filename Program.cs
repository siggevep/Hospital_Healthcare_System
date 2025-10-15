using System.Reflection.Metadata;

/*
As a user, I need to be able to log in. 

As a user, I need to be able to log out.

As a user, I need to be able to request registration as a patient.

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
using App;

IUser? active_user = null;
bool running = true;

List<IUser> users = new List<IUser>();


//users.Add(new Local_Admin("Lukas", "Eriksson", "04"));




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

            Console.WriteLine("personnummer:");
            string person_nummer = Console.ReadLine()!;
            foreach (IUser user in users)
            {
                if (user.TryLogin(name, password, person_nummer))
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
                    Console.WriteLine(users[3]);

                    Console.WriteLine("hello Local admin");
                }
                // Lägger bara till dettat temp för att testa User rollen. Pretty basic
                if(active_user.IsRole(Role.User))
                {
                    Console.WriteLine("Hey King");
                    string input = Console.ReadLine();
                    if (input == "quit")

                    {
                        Environment.Exit(0);
                    }
                }
                // här kan ni lägga Local Admin-logik/meny senare
            }
            else
            {
                Console.WriteLine("Fel användarnamn, lösenord eller personnummer.");

            }
            //lägga till log in 
            // måste fixa så att du kollar om ditt konto finns
        }

        //ifall create user väljs
        if (menu1 == "2")
        {
            Console.WriteLine("Email:");
            string name = Console.ReadLine()!;

            Console.WriteLine("Password:");
            string password = Console.ReadLine()!;
          


            Console.WriteLine("Please enter your personnummer");
            string Person_nummer = Console.ReadLine();

              users.Add(new User(name, password, Person_nummer));

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

