using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {
        public static HumaneSocietyDataContext db = new HumaneSocietyDataContext();

        public static void GetPendingAdoptions()
        {
            var adoption = (from a in db.Adoptions where a.ApprovalStatus.Equals(null) select a);
        }

        public static void UpdateAdoption(bool v, Adoption adoption)
        {
            throw new NotImplementedException();
        }

        public static object GetShots(Animal animal)
        {
            throw new NotImplementedException();
        }

        public static void UpdateShot(string v, Animal animal)
        {
            throw new NotImplementedException();
        }

        public static void EnterUpdate(Animal animal, Dictionary<int, string> updates)
        {
            throw new NotImplementedException();
        }

        public static void RemoveAnimal(Animal animal)
        {
            db.GetTable<Animal>().DeleteOnSubmit(animal);
            db.SubmitChanges();
        }

        public static Species GetSpecies(string species)
        {
            var foundSpecies = (from s in db.Species where s.Name.Equals(species) select s).Single();
            return foundSpecies;
        }

        public static Client GetClient(string userName, string password)
        {
            var client = (from c in db.Clients where c.UserName.Equals(userName) && c.Password.Equals(password) select c).First();
            return client;
        }

        public static DietPlan GetDietPlan()
        {
            DietPlan diet = new DietPlan();
            return diet;
        }

        public static void AddAnimal(Animal animal)
        {
            Animal newAnimal = new Animal();
    
            db.Animals.InsertOnSubmit(newAnimal);

            db.SubmitChanges();

            Animal insertedAnimal = db.Animals.First();
            Console.WriteLine("Name: {0}, Species{1}, Age{2}, Demeanor{3}, Kid Friendly{4}, Pet Friendly{5}," +
                 "Weight{6}, DietPlan{7}", insertedAnimal.Name, insertedAnimal.Age, insertedAnimal.Demeanor, insertedAnimal.KidFriendly, insertedAnimal.PetFriendly, 
                 insertedAnimal.Weight, insertedAnimal.DietPlan);
            Console.WriteLine("New Animal inserted.");
            Console.ReadKey();

        }

        public static Employee EmployeeLogin(string userName, string password)
        {
            var acceptedLogin = (from l in db.Employees where l.UserName.Equals(userName) && l.Password.Equals(password) select l).First();
            return acceptedLogin;
        }

        public static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            var foundUserInfo = (from u in db.Employees where u.Email.Equals(email) && u.EmployeeNumber.Equals(employeeNumber) select u).First();
            return foundUserInfo;
        }

        public static void AddUsernameAndPassword(Employee employee)
        {
            Employee usernameAndPassword = new Employee();

            db.Employees.InsertOnSubmit(usernameAndPassword);
            Employee insertedData = db.Employees.First();
            Console.WriteLine("UserName: {0}, Password{1}", insertedData.UserName, insertedData.Password);
            Console.WriteLine("New username and password inserted.");
            Console.ReadKey();
        }

        public static bool CheckEmployeeUserNameExist(string username)
        {
            var foundUserName = (from u in db.Employees where u.UserName.Equals(username) select u).First();
            return true;
        }

        public static Room GetRoom(int animalId)
        {
            throw new NotImplementedException();
        }

        public static void GetUserAdoptionStatus(Client client)
        {
            var clientID = client.ClientId;
            var clientInfo = from a in db.Adoptions where a.ClientId.Equals(clientID) select a.ApprovalStatus;
        }

        public static object GetAnimalByID(int iD)
        {
            throw new NotImplementedException();
        }

        public static void Adopt(object animal, Client client)
        {
            throw new NotImplementedException();
        }

        public static void RunEmployeeQueries(Employee employee, string v)
        {
            throw new NotImplementedException();
        }

        public static List<Client> RetrieveClients()
        {
            var client = db.Clients.ToList();
            return client;
        }

        public static List<USState> GetStates(string state, string abbrev)
        {
            var statesId = db.USStates.ToList();
            return statesId;
                          
        }

        public static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int state)
        {
            Client newClient = new Client();

            db.Clients.InsertOnSubmit(newClient);

            db.SubmitChanges();

            Client insertedClient = db.Clients.First();
            Console.WriteLine("First Name: {0}, Last Name: {1}, username: {2}, password{3}, email: {4}, address: {5}, zipcode: {6}, state: {7}", insertedClient.FirstName, insertedClient.LastName,
                insertedClient.UserName, insertedClient.Password, insertedClient.Email, insertedClient.Address);
            Console.WriteLine("New Client inserted.");
            Console.ReadKey();
        }

        public static void UpdateClient(Client client)
        {
            throw new NotImplementedException();
        }

        public static void UpdateUsername(Client client)
        {
            var myQuery = from clients in db.GetTable<Client>()
                          where clients.UserName == (clients.UserName.Single().ToString())
                          select clients;
            Client updateClient = myQuery.First();
            updateClient.UserName = (updateClient.UserName.Single().ToString());
            db.SubmitChanges();
        }

        public static void UpdateEmail(Client client)
        {
            var myQuery = from clients in db.GetTable<Client>()
                          where clients.Email == (clients.Email.Single().ToString())
                          select clients;
            Client updateClient = myQuery.First();
            updateClient.Email = (updateClient.Email.Single().ToString());
            db.SubmitChanges();
        }

        public static void UpdateAddress(Client client)
        {
            var myQuery = from clients in db.GetTable<Client>()
                          where clients.Address == (clients.Address)
                          select clients;
            Client updateClient = myQuery.First();
            updateClient.Address = (updateClient.Address);
            db.SubmitChanges();
        }

        public static void UpdateFirstName(Client client)
        {
            var myQuery = from clients in db.GetTable<Client>()
                          where clients.FirstName == (clients.FirstName.Single().ToString())
                          select clients;
            Client updateClient = myQuery.First();
            updateClient.FirstName = (updateClient.FirstName.Single().ToString());
            db.SubmitChanges();
        }

        public static void UpdateLastName(Client client)
        {
            var myQuery = from clients in db.GetTable<Client>()
                          where clients.LastName == (clients.LastName.Single().ToString())
                          select clients;
            Client updateClient = myQuery.First();
            updateClient.LastName = (updateClient.LastName.Single().ToString());
            db.SubmitChanges();
        }
    }
}
