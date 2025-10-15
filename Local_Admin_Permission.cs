namespace App
{
   
    class Location
    {
        public string Name;
        public string Hospital;

        public Location(string name, string hospital)
        {
            Name = name;
            Hospital = hospital;
        }

        public override string ToString()
        {
            return Name + " (Sjukhus: " + Hospital + ")";
        }
    }

    //Personal konto
    class PersonnelAccount
    {
        public string Email;
        public string Password;

        public PersonnelAccount(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    // Registrering
    class Registration
    {
        public string UserEmail;
        public string Password;
        public RegistrationStatus Status;

        public Registration(string useremail, string password, RegistrationStatus status)
        {
            UserEmail = useremail;
            Password = password;
            Status = status;
        }
    }

    // Status för registrering
    public enum RegistrationStatus
    {
        Pending,
        Accept,
        Deny
    }

   
    class Local_Admin_Permission
    {
        
        public static List<Location> Locations = new List<Location>();
        public static List<PersonnelAccount> Personnels = new List<PersonnelAccount>();
        public static List<Registration> Registrations = new List<Registration>();

        public static bool NewLocation(string LocationName, string HospitalName)
        {
           
            Locations.Add(new Location(LocationName, HospitalName));
            Console.WriteLine("Ny plats: " + LocationName + " (" + HospitalName + ")");
            return true;
        }

        // Visar alla platser
        public static void ShowLocations()
        {
            if (Locations.Count == 0)
            {
                Console.WriteLine("Inga platser ännu.");
                return;
            }

            Console.WriteLine("Platser:");
            int i = 0;
            while (i < Locations.Count)
            {
                Console.WriteLine("- " + Locations[i].ToString());
                i = i + 1;
            }
        }

   
        public static bool NewPersonnel(string personnelemail, string personnelpassword)
        {

            Personnels.Add(new PersonnelAccount(personnelemail, personnelpassword));
            Console.WriteLine("Nytt konto för personalen: " + personnelemail);
            return true;
        }

        //Skapar en registreringsförfrågan
        public static bool CreateRegistration(string userEmail, string password)
        {


            Registrations.Add(new Registration(userEmail, password, RegistrationStatus.Pending));
            Console.WriteLine("Registreringsförfrågan skapad för: " + userEmail);
            return true;
        }

   

        //Godkänn en registrering
        public static bool AcceptNewPatient(string userEmail)
        {
            int i = 0;
      while (i < Registrations.Count)
      {
        Registration reg = Registrations[i];
        if (reg.UserEmail == userEmail && reg.Status == RegistrationStatus.Pending)
        {
          reg.Status = RegistrationStatus.Accept;
          Console.WriteLine("Registrering godkänd: " + reg.UserEmail);
          return true;
        }
        i = i + 1;
      }

      return false;

           
        }

        // Deny registration
        public static bool DenyNewPatient(string userEmail)
        {
            int i = 0;
            while (i < Registrations.Count)
            {
                Registration reg = Registrations[i];
                if (reg.UserEmail == userEmail && reg.Status == RegistrationStatus.Pending)
                {
                    reg.Status = RegistrationStatus.Deny;
                    Console.WriteLine("Registrering avslagen: " + reg.UserEmail);
                    return true;
                }
                i = i + 1;
            }

            return false;
        }
    }
}
