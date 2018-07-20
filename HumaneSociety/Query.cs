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

        public static IQueryable<Adoption> GetPendingAdoptions()
        {
            var adoption = (from a in db.Adoptions where a.ApprovalStatus.Equals(null) select a);
            return adoption;
        }

        public static void UpdateAdoption(bool v, Adoption adoption)
        {
            throw new NotImplementedException();
        }

        public static IQueryable<Shot> GetShots(Animal animal)
        {
            throw new NotImplementedException();
        }

        public static void UpdateShot(string v, Animal animal)
        {
            throw new NotImplementedException();
        }

        public static void EnterUpdate(Animal animal, Dictionary<int, string> updates)
        {
            Dictionary<int, string> animalList = new Dictionary<int, string>();

            db.Animals.InsertOnSubmit(animal);

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

            db.SubmitChanges();
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

        public static IQueryable<Adoption> GetUserAdoptionStatus(Client client)
        {
            var adoptionStatus = from status in db.Adoptions
                         where status.ClientId == client.ClientId
                         select status;
            return adoptionStatus;
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
            Client client = new Client();

            db.Clients.InsertOnSubmit(client);
            db.SubmitChanges();

            
        }

        public static void UpdateClient(Client client)
        {
            var myQuery = from clients in db.GetTable<Client>()
                          where clients.ClientId == (clients.ClientId)
                          select clients;
            Client updateClient = myQuery.First();
            updateClient.ClientId = (updateClient.UserName.Single());
            updateClient.FirstName = (updateClient.FirstName);
            updateClient.LastName = (updateClient.LastName.First().ToString());
            updateClient.UserName = (updateClient.UserName.First().ToString());
            updateClient.Email = (updateClient.Email.First().ToString());
            updateClient.Address = (updateClient.Address);
            updateClient.Address.Zipcode = (updateClient.Address.Zipcode);
            updateClient.Address.USState = (updateClient.Address.USState);
            db.SubmitChanges();
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
                          where clients.AddressId == (clients.AddressId)
                          select clients;
            Client updateClient = myQuery.First();
            updateClient.AddressId = (updateClient.AddressId);
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
