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
        public delegate void RunCrudMethods(Employee employee);

        public static IQueryable<Adoption> GetPendingAdoptions()
        {
            var adoption = (from a in db.Adoptions where a.ApprovalStatus.Equals(null) select a);
            return adoption;
        }

        public static void UpdateAdoption(bool v, Adoption adoption)
        {
            if (v == true) {
                adoption.ApprovalStatus = "Approved";
            } else if (v == false) {
                adoption.ApprovalStatus = "Not approved";
            }
        }

        public static IQueryable<AnimalShot> GetShots(Animal animal)
        {
            var animalShot = (from a in db.AnimalShots where a.Equals(animal) select a);
            return animalShot;
        }

        public static void UpdateShot(string v, Animal animal)
        {
            var currentShots = from a in db.AnimalShots where a.Equals(animal) select a;
            foreach (AnimalShot animalShot in currentShots)
            {
                animalShot.DateReceived = DateTime.Today;
                db.SubmitChanges();
            }
        }

        public static void EnterUpdate(Animal animal, Dictionary<int, string> updates)
        {
            var newAnimal = db.Animals.Where(a => a.AnimalId.Equals(animal.AnimalId)).SingleOrDefault();

            foreach (var update in updates)
            {
                if (update.Key == 1)
                {
                    newAnimal.Name = update.Value;
                    db.SubmitChanges();
                }
                else if (update.Key == 2)
                {
                    newAnimal.Species.Name = update.Value;
                    db.SubmitChanges();
                }
                else if (update.Key == 3)
                {
                    newAnimal.Age = Convert.ToInt32(update.Value);
                    db.SubmitChanges();
                }
                else if (update.Key == 4)
                {
                    animal.Demeanor = update.Value;
                    db.SubmitChanges();
                }
                else if (update.Key == 5)
                {
                    animal.KidFriendly = Convert.ToBoolean(update.Value);
                    db.SubmitChanges();
                }
                else if (update.Key == 6)
                {
                    animal.PetFriendly = Convert.ToBoolean(update.Value);
                    db.SubmitChanges();
                }
                else if (update.Key == 7)
                {
                    animal.Weight = Convert.ToInt32(update.Value);
                    db.SubmitChanges();
                }




            }

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
            var room = (from a in db.Rooms where a.AnimalId.Equals(animalId) select a).First();
            return room;
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

            var animalId = from a in db.Animals
                           where a.AnimalId == iD
                           select a;
            return animalId;
        }

        public static void Adopt(object animal, Client client)
        {
            throw new NotImplementedException();
        }

        public static void CrudCreateEmployee(Employee employee)
        {
            Employee newEmployee = new Employee();

            db.Employees.InsertOnSubmit(newEmployee);
            db.SubmitChanges();
        }

        public static void CrudReadEmployee(Employee employee)
        {
            var findEmployee = from e in db.Employees where e.EmployeeNumber == employee.EmployeeNumber select e;
            Console.WriteLine("Employee that was found: ", findEmployee);
        }

        public static void CrudUpdateEmployee(Employee employee)
        {
            var myQuery = from e in db.Employees where e.EmployeeId == employee.EmployeeId select e;
            Employee upDatedEmployee = myQuery.First();
            upDatedEmployee.FirstName = employee.FirstName;
            upDatedEmployee.LastName = employee.LastName;
            upDatedEmployee.EmployeeNumber = employee.EmployeeNumber;
            upDatedEmployee.Email = employee.Email;

            db.SubmitChanges();
        }

        public static void CrudDeleteEmployee(Employee employee)
        {
            db.GetTable<Employee>().DeleteOnSubmit(employee);
            db.SubmitChanges();
        }

        public static void RunEmployeeQueries(Employee employee, string v)
        {
            switch (v)
            {
                case "Create":
                    RunCrudMethods method1 = new RunCrudMethods(CrudCreateEmployee);
                    CrudCreateEmployee(employee);
                    break;
                case "Read":
                    RunCrudMethods method2 = new RunCrudMethods(CrudReadEmployee);
                    CrudReadEmployee(employee);
                    break;
                case "Update":
                    RunCrudMethods method3 = new RunCrudMethods(CrudUpdateEmployee);
                    CrudUpdateEmployee(employee);
                    break;
                case "Delete":
                    RunCrudMethods method4 = new RunCrudMethods(CrudDeleteEmployee);
                    CrudDeleteEmployee(employee);
                    break;

                default:
                    Console.WriteLine("Wrong input, please choose again.");
                    RunEmployeeQueries(employee, v);
                    break;
            }
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
