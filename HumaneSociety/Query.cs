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

        public static Adoption GetPendingAdoptions()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            Employee usernameAndPassword =  new Employee();

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

        public static object GetUserAdoptionStatus(Client client)
        {
            throw new NotImplementedException();
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

        public static object RetrieveClients()
        {

            throw new NotImplementedException();
        }

        public static USState GetStates(string state, string abbrev)
        {
            var statesId = (from s in db.USStates where s.Name.Equals(state) && s.Abbreviation.Equals(abbrev) select s).First();
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
            throw new NotImplementedException();
        }

        public static void UpdateEmail(Client client)
        {
            throw new NotImplementedException();
        }

        public static void UpdateAddress(Client client)
        {
            throw new NotImplementedException();
        }

        public static void UpdateFirstName(Client client)
        {
            throw new NotImplementedException();
        }

        public static void UpdateLastName(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
