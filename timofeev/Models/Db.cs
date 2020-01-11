using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace timofeev.Models
{
    public class Db
    {
        private Db() { }

        static string GetInternalExceptionMessage(Exception e)
        {
            Exception _exception = e;
            do
            {
                _exception = _exception.InnerException ?? _exception;
            }
            while (_exception.InnerException != null);
            switch (_exception.GetType().Name)
            {
                case "SqlException":
                    return $"Error: An error occurred while executing the SQL command. Possible violation of data integrity.";
                    //return $"Error: Произошла ошибка при выполнении команды SQL. Возможо нарушение целостности данных.";
                default:
                    return $"Error: {_exception.Message}";
            }
        }

        #region rating
        public static bool AddRating(Rating r)
        {
            return Task.Run(async () =>
            {
                return await Db.AddRatingAsync(r);
            }).Result;
        }

        public static async Task<bool> AddRatingAsync(Rating r)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                if (dbContext.Ratings.SingleOrDefault(x => x.Id == r.Id) == null)
                {
                    dbContext.Ratings.Add(r);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool UpdateRating(Rating r)
        {
            return Task.Run(async () =>
            {
                return await Db.UpdateRatingAsync(r);
            }).Result;
        }

        public static async Task<bool> UpdateRatingAsync(Rating r)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                Rating _r = dbContext.Ratings.SingleOrDefault(x => x.Id == r.Id);
                if (_r == null)
                {
                    return false;
                }
                else
                {
                    _r.RatingLevel = r.RatingLevel;
                    _r.BonusPercent = r.BonusPercent;
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
        }

        public static string DeleteRating(string r_id)
        {
            return Task.Run(async () =>
            {
                return await Db.DeleteRatingAsync(r_id);
            }).Result;
        }

        public static async Task<string> DeleteRatingAsync(string r_id)
        {
            try
            {
                using (DefDbContext dbContext = new DefDbContext())
                {
                    Rating _r = dbContext.Ratings.SingleOrDefault(x => x.Id == r_id);
                    if (_r != null)
                    {
                        dbContext.Ratings.Remove(_r);
                        await dbContext.SaveChangesAsync();
                    }
                }
                return "Success";
            }
            catch (Exception e)
            {
                return GetInternalExceptionMessage(e);
            }            
        }

        public static bool DeleteRating(int r_index)
        {
            return Task.Run(async () =>
            {
                return await Db.DeleteRatingAsync(r_index);
            }).Result;
        }

        public static async Task<bool> DeleteRatingAsync(int r_index)
        {
            try
            {
                var r = GetRatings()[r_index];
                using (DefDbContext dbContext = new DefDbContext())
                {
                    Rating _r = dbContext.Ratings.SingleOrDefault(x => x.Id == r.Id);
                    if (_r != null)
                    {
                        dbContext.Ratings.Remove(_r);
                        await dbContext.SaveChangesAsync();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Rating GetRating(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.GetRatingAsync(id);
            }).Result;
        }

        public static async Task<Rating> GetRatingAsync(string id)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.Ratings.SingleOrDefaultAsync(x => x.Id == id);
            }
        }

        public static List<Rating> GetRatings(int count = 10)
        {
            return Task.Run(async () =>
            {
                return await Db.GetRatingsAsync(count);
            }).Result;
        }

        public static async Task<List<Rating>> GetRatingsAsync(int count)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.Ratings.Take(count <= 0 ? 100 : count).ToListAsync();
            }
        }
        #endregion
        #region position
        public static bool UpdatePosition(Position p)
        {
            return Task.Run(async () =>
            {
                return await Db.UpdatePositionAsync(p);
            }).Result;
        }

        public static async Task<bool> UpdatePositionAsync(Position p)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                Position _p = dbContext.Positions.SingleOrDefault(x => x.Id == p.Id);
                if (_p == null)
                {
                    return false;
                }
                else
                {
                    _p.PositionName = p.PositionName;
                    _p.Salary = p.Salary;
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
        }

        public static string DeletePosition(string p_id)
        {
            return Task.Run(async () =>
            {
                return await Db.DeletePositionAsync(p_id);
            }).Result;
        }

        public static async Task<string> DeletePositionAsync(string p_id)
        {
            try
            {
                using (DefDbContext dbContext = new DefDbContext())
                {
                    Position _p = dbContext.Positions.SingleOrDefault(x => x.Id == p_id);
                    if (_p != null)
                    {
                        dbContext.Positions.Remove(_p);
                        await dbContext.SaveChangesAsync();
                    }
                }
                return "Success";
            }
            catch (Exception e)
            {
                return GetInternalExceptionMessage(e);
            }
        }

        public static bool AddPosition(Position p)
        {
            return Task.Run(async () =>
            {
                return await Db.AddPositionAsync(p);
            }).Result;
        }

        public static async Task<bool> AddPositionAsync(Position p)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                if (dbContext.Positions.SingleOrDefault(x => x.Id == p.Id) == null)
                {
                    dbContext.Positions.Add(p);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static Position GetPosition(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.GetPositionAsync(id);
            }).Result;
        }

        public static async Task<Position> GetPositionAsync(string id)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.Positions.SingleOrDefaultAsync(x => x.Id == id);
            }
        }

        public static List<Position> GetPositions(int count = 10)
        {
            return Task.Run(async () =>
            {
                return await Db.GetPositionsAsync(count);
            }).Result;
        }

        public static async Task<List<Position>> GetPositionsAsync(int count)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.Positions.Take(count <= 0 ? 100 : count).ToListAsync();
            }
        }
        #endregion
        #region person
        public static bool UpdatePerson(Person p)
        {
            return Task.Run(async () =>
            {
                return await Db.UpdatePersonAsync(p);
            }).Result;
        }

        public static async Task<bool> UpdatePersonAsync(Person p)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                Person _p = dbContext.Persons.SingleOrDefault(x => x.Id == p.Id);
                if (_p == null)
                {
                    return false;
                }
                else
                {
                    _p.Address = p.Address;
                    _p.Email = p.Email;
                    _p.Firstname = p.Firstname;
                    _p.Name = p.Name;
                    _p.Secondname = p.Secondname;
                    _p.PassportInfo = p.PassportInfo;
                    _p.PhoneNumber = p.PhoneNumber;
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
        }

        public static string DeletePerson(string p_id)
        {
            return Task.Run(async () =>
            {
                return await Db.DeletePersonAsync(p_id);
            }).Result;
        }

        public static async Task<string> DeletePersonAsync(string p_id)
        {
            try
            {
                using (DefDbContext dbContext = new DefDbContext())
                {
                    Person _p = dbContext.Persons.SingleOrDefault(x => x.Id == p_id);
                    if (_p != null)
                    {
                        dbContext.Persons.Remove(_p);
                        await dbContext.SaveChangesAsync();
                    }
                }
                return "Success";
            }
            catch (Exception e)
            {
                return GetInternalExceptionMessage(e);
            }
        }

        public static bool AddPerson(Person p)
        {
            return Task.Run(async () =>
            {
                return await Db.AddPersonAsync(p);
            }).Result;
        }

        public static async Task<bool> AddPersonAsync(Person p)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                if (dbContext.Persons.SingleOrDefault(x => x.Id == p.Id) == null)
                {
                    dbContext.Persons.Add(p);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static Person GetPerson(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.GetPersonAsync(id);
            }).Result;
        }

        public static async Task<Person> GetPersonAsync(string id)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.Persons.SingleOrDefaultAsync(x => x.Id == id);
            }
        }

        public static List<Person> GetPersons(int count = 10)
        {
            return Task.Run(async () =>
            {
                return await Db.GetPersonsAsync(count);
            }).Result;
        }

        public static async Task<List<Person>> GetPersonsAsync(int count)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.Persons.Take(count <= 0 ? 100 : count).ToListAsync();
            }
        }
        #endregion
        #region employee
        public static bool UpdateEmployee(Employee e)
        {
            return Task.Run(async () =>
            {
                return await Db.UpdateEmployeeAsync(e);
            }).Result;
        }

        public static async Task<bool> UpdateEmployeeAsync(Employee e)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                Employee _e = dbContext.Employees.SingleOrDefault(x => x.Id == e.Id);
                if (_e == null)
                {
                    return false;
                }
                else
                {
                    // Выбор только из существующих
                    //_e.Person = dbContext.Persons.SingleOrDefault(x => x.Id == e.PersonId);
                    _e.Position = dbContext.Positions.SingleOrDefault(x => x.Id == e.PositionId);
                    _e.Rating = dbContext.Ratings.SingleOrDefault(x => x.Id == e.RatingId);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
        }

        public static string DeleteEmployee(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.DeleteEmployeeAsync(id);
            }).Result;
        }

        public static async Task<string> DeleteEmployeeAsync(string id)
        {
            try
            {
                using (DefDbContext dbContext = new DefDbContext())
                {
                    Employee _e = dbContext.Employees.SingleOrDefault(x => x.Id == id);
                    if (_e != null)
                    {
                        dbContext.Employees.Remove(_e);
                        await dbContext.SaveChangesAsync();
                    }
                }
                return "Success";
            }
            catch (Exception e)
            {
                return GetInternalExceptionMessage(e);
            }
        }

        public static bool AddEmployee(Employee e)
        {
            return Task.Run(async () =>
            {
                return await Db.AddEmployeeAsync(e);
            }).Result;
        }

        public static async Task<bool> AddEmployeeAsync(Employee e)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                if (dbContext.Employees.SingleOrDefault(x=>x.Id == e.Id) == null)
                {
                    e.Person = dbContext.Persons.SingleOrDefault(x => x.Id == e.PersonId) ?? e.Person;
                    e.Position = dbContext.Positions.SingleOrDefault(x => x.Id == e.PositionId) ?? e.Position;
                    e.Rating = dbContext.Ratings.SingleOrDefault(x => x.Id == e.RatingId) ?? e.Rating;

                    dbContext.Employees.Add(e);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<Employee> GetEmployees(int count = 10)
        {
            return Task.Run(async () =>
            {
                return await Db.GetEmployeesAsync(count);
            }).Result;
        }

        public static async Task<List<Employee>> GetEmployeesAsync(int count)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.Employees.Include("Position").Include("Rating").Include("Person").Take(count <= 0 ? 100 : count).ToListAsync();
            }
        }

        public static Employee GetEmployee(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.GetEmployeeAsync(id);
            }).Result;
        }

        public static async Task<Employee> GetEmployeeAsync(string id)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.Employees.Include("Position").Include("Rating").Include("Person").SingleOrDefaultAsync(x => x.Id == id);
            }
        }
        #endregion

        #region confectionery category
        public static bool UpdateConfectioneryCategory(ConfectioneryCategory cc)
        {
            return Task.Run(async () =>
            {
                return await Db.UpdateConfectioneryCategoryAsync(cc);
            }).Result;
        }

        public static async Task<bool> UpdateConfectioneryCategoryAsync(ConfectioneryCategory cc)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                ConfectioneryCategory _cc = dbContext.ConfectioneryCategories.SingleOrDefault(x => x.Id == cc.Id);
                if (_cc == null)
                {
                    return false;
                }
                else
                {
                    _cc.CategoryName = cc.CategoryName;
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
        }

        public static string DeleteConfectioneryCategory(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.DeleteConfectioneryCategoryAsync(id);
            }).Result;
        }

        public static async Task<string> DeleteConfectioneryCategoryAsync(string id)
        {
            try
            {
                using (DefDbContext dbContext = new DefDbContext())
                {
                    ConfectioneryCategory _cc = dbContext.ConfectioneryCategories.SingleOrDefault(x => x.Id == id);
                    if (_cc != null)
                    {
                        dbContext.ConfectioneryCategories.Remove(_cc);
                        await dbContext.SaveChangesAsync();
                    }
                }
                return "Success";
            }
            catch (Exception e)
            {
                return GetInternalExceptionMessage(e);
            }
        }

        public static bool AddConfectioneryCategory(ConfectioneryCategory cc)
        {
            return Task.Run(async () =>
            {
                return await Db.AddConfectioneryCategoryAsync(cc);
            }).Result;
        }

        public static async Task<bool> AddConfectioneryCategoryAsync(ConfectioneryCategory cc)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                if (dbContext.ConfectioneryCategories.SingleOrDefault(x => x.Id == cc.Id) == null)
                {
                    dbContext.ConfectioneryCategories.Add(cc);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static ConfectioneryCategory GetConfectioneryCategory(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.GetConfectioneryCategoryAsync(id);
            }).Result;
        }

        public static async Task<ConfectioneryCategory> GetConfectioneryCategoryAsync(string id)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.ConfectioneryCategories.SingleOrDefaultAsync(x => x.Id == id);
            }
        }

        public static List<ConfectioneryCategory> GetConfectioneryCategories(int count = 10)
        {
            return Task.Run(async () =>
            {
                return await Db.GetConfectioneryCategoriesAsync(count);
            }).Result;
        }

        public static async Task<List<ConfectioneryCategory>> GetConfectioneryCategoriesAsync(int count)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.ConfectioneryCategories.Take(count <= 0 ? 100 : count).ToListAsync();
            }
        }
        #endregion
        #region confectionery
        public static bool UpdateConfectionery(Confectionery c)
        {
            return Task.Run(async () =>
            {
                return await Db.UpdateConfectioneryAsync(c);
            }).Result;
        }

        public static async Task<bool> UpdateConfectioneryAsync(Confectionery c)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                Confectionery _c = dbContext.Confectioneries.SingleOrDefault(x => x.Id == c.Id);
                if (_c == null)
                {
                    return false;
                }
                else
                {
                    // Выбор только из существующих
                    _c.ConfectioneryCategory = dbContext.ConfectioneryCategories.SingleOrDefault(x => x.Id == c.ConfectioneryCategoryId);
                    _c.Name = c.Name;
                    _c.Composition = c.Composition;
                    _c.Price = c.Price;
                    _c.Weight = c.Weight;
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
        }

        public static string DeleteConfectionery(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.DeleteConfectioneryAsync(id);
            }).Result;
        }

        public static async Task<string> DeleteConfectioneryAsync(string id)
        {
            try
            {
                using (DefDbContext dbContext = new DefDbContext())
                {
                    Confectionery _C = dbContext.Confectioneries.SingleOrDefault(x => x.Id == id);
                    if (_C != null)
                    {
                        dbContext.Confectioneries.Remove(_C);
                        await dbContext.SaveChangesAsync();
                    }
                }
                return "Success";
            }
            catch (Exception e)
            {
                return GetInternalExceptionMessage(e);
            }
        }

        public static bool AddConfectionery(Confectionery c)
        {
            return Task.Run(async () =>
            {
                return await Db.AddConfectioneryAsync(c);
            }).Result;
        }

        public static async Task<bool> AddConfectioneryAsync(Confectionery c)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                if (dbContext.Confectioneries.SingleOrDefault(x => x.Id == c.Id) == null)
                {
                    c.ConfectioneryCategory = dbContext.ConfectioneryCategories.SingleOrDefault(x => x.Id == c.ConfectioneryCategoryId) ?? c.ConfectioneryCategory;

                    dbContext.Confectioneries.Add(c);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<Confectionery> GetConfectioneries(int count = 10)
        {
            return Task.Run(async () =>
            {
                return await Db.GetConfectioneriesAsync(count);
            }).Result;
        }

        public static async Task<List<Confectionery>> GetConfectioneriesAsync(int count)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.Confectioneries.Include("ConfectioneryCategory").Take(count <= 0 ? 100 : count).ToListAsync();
            }
        }

        public static Confectionery GetConfectionery(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.GetConfectioneryAsync(id);
            }).Result;
        }

        public static async Task<Confectionery> GetConfectioneryAsync(string id)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.Confectioneries.Include("ConfectioneryCategory").SingleOrDefaultAsync(x => x.Id == id);
            }
        }
        #endregion

        #region client
        public static bool UpdateClient(Client c)
        {
            return Task.Run(async () =>
            {
                return await Db.UpdateClientAsync(c);
            }).Result;
        }

        public static async Task<bool> UpdateClientAsync(Client c)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                Client _c = dbContext.Clients.SingleOrDefault(x => x.Id == c.Id);
                if (_c == null)
                {
                    return false;
                }
                else
                {
                    _c.Firstname = c.Firstname;
                    _c.Name = c.Name;
                    _c.Secondname = c.Secondname;
                    _c.PhoneNumber = c.PhoneNumber;
                    _c.DeliveryAddress = c.DeliveryAddress;
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
        }

        public static string DeleteClient(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.DeleteClientAsync(id);
            }).Result;
        }

        public static async Task<string> DeleteClientAsync(string id)
        {
            try
            {
                using (DefDbContext dbContext = new DefDbContext())
                {
                    Client _cc = dbContext.Clients.SingleOrDefault(x => x.Id == id);
                    if (_cc != null)
                    {
                        dbContext.Clients.Remove(_cc);
                        await dbContext.SaveChangesAsync();
                    }
                }
                return "Success";
            }
            catch (Exception e)
            {
                return GetInternalExceptionMessage(e);
            }
        }

        public static bool AddClient(Client c)
        {
            return Task.Run(async () =>
            {
                return await Db.AddClientAsync(c);
            }).Result;
        }

        public static async Task<bool> AddClientAsync(Client c)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                if (dbContext.Clients.SingleOrDefault(x => x.Id == c.Id) == null)
                {
                    dbContext.Clients.Add(c);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static Client GetClient(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.GetClientAsync(id);
            }).Result;
        }

        public static async Task<Client> GetClientAsync(string id)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.Clients.SingleOrDefaultAsync(x => x.Id == id);
            }
        }

        public static List<Client> GetClients(int count = 10)
        {
            return Task.Run(async () =>
            {
                return await Db.GetClientsAsync(count);
            }).Result;
        }

        public static async Task<List<Client>> GetClientsAsync(int count)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.Clients.Take(count <= 0 ? 100 : count).ToListAsync();
            }
        }
        #endregion
        #region order theme
        public static bool UpdateOrderTheme(OrderTheme c)
        {
            return Task.Run(async () =>
            {
                return await Db.UpdateOrderThemeAsync(c);
            }).Result;
        }

        public static async Task<bool> UpdateOrderThemeAsync(OrderTheme ot)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                OrderTheme _ot = dbContext.OrderThemes.SingleOrDefault(x => x.Id == ot.Id);
                if (_ot == null)
                {
                    return false;
                }
                else
                {
                    _ot.Description = ot.Description;
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
        }

        public static string DeleteOrderTheme(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.DeleteOrderThemeAsync(id);
            }).Result;
        }

        public static async Task<string> DeleteOrderThemeAsync(string id)
        {
            try
            {
                using (DefDbContext dbContext = new DefDbContext())
                {
                    OrderTheme _cc = dbContext.OrderThemes.SingleOrDefault(x => x.Id == id);
                    if (_cc != null)
                    {
                        dbContext.OrderThemes.Remove(_cc);
                        await dbContext.SaveChangesAsync();
                    }
                }
                return "Success";
            }
            catch (Exception e)
            {
                return GetInternalExceptionMessage(e);
            }
        }

        public static bool AddOrderTheme(OrderTheme c)
        {
            return Task.Run(async () =>
            {
                return await Db.AddOrderThemeAsync(c);
            }).Result;
        }

        public static async Task<bool> AddOrderThemeAsync(OrderTheme c)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                if (dbContext.OrderThemes.SingleOrDefault(x => x.Id == c.Id) == null)
                {
                    dbContext.OrderThemes.Add(c);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static OrderTheme GetOrderTheme(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.GetOrderThemeAsync(id);
            }).Result;
        }

        public static async Task<OrderTheme> GetOrderThemeAsync(string id)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.OrderThemes.SingleOrDefaultAsync(x => x.Id == id);
            }
        }

        public static List<OrderTheme> GetOrderThemes(int count = 10)
        {
            return Task.Run(async () =>
            {
                return await Db.GetOrderThemesAsync(count);
            }).Result;
        }

        public static async Task<List<OrderTheme>> GetOrderThemesAsync(int count)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.OrderThemes.Take(count <= 0 ? 100 : count).ToListAsync();
            }
        }
        #endregion
        #region order
        public static bool UpdateOrder(Order c)
        {
            return Task.Run(async () =>
            {
                return await Db.UpdateOrderAsync(c);
            }).Result;
        }

        public static async Task<bool> UpdateOrderAsync(Order obj)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                Order _obj = dbContext.Orders.SingleOrDefault(x => x.Id == obj.Id);
                if (_obj == null)
                {
                    return false;
                }
                else
                {
                    // Выбор только из существующих
                    _obj.Client = dbContext.Clients.SingleOrDefault(x => x.Id == obj.ClientId);
                    _obj.Employee = dbContext.Employees.SingleOrDefault(x => x.Id == obj.EmployeeId);
                    _obj.OrderTheme = dbContext.OrderThemes.SingleOrDefault(x => x.Id == obj.OrderThemeId);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
        }

        public static string DeleteOrder(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.DeleteOrderAsync(id);
            }).Result;
        }

        public static async Task<string> DeleteOrderAsync(string id)
        {
            try
            {
                using (DefDbContext dbContext = new DefDbContext())
                {
                    Order _obj = dbContext.Orders.SingleOrDefault(x => x.Id == id);
                    if (_obj != null)
                    {
                        dbContext.Orders.Remove(_obj);
                        await dbContext.SaveChangesAsync();
                    }
                }
                return "Success";
            }
            catch (Exception e)
            {
                return GetInternalExceptionMessage(e);
            }
        }

        public static bool AddOrder(Order obj)
        {
            return Task.Run(async () =>
            {
                return await Db.AddOrderAsync(obj);
            }).Result;
        }

        public static async Task<bool> AddOrderAsync(Order obj)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                if (dbContext.Orders.SingleOrDefault(x => x.Id == obj.Id) == null)
                {
                    obj.Client = dbContext.Clients.SingleOrDefault(x => x.Id == obj.ClientId);
                    obj.Employee = dbContext.Employees.SingleOrDefault(x => x.Id == obj.EmployeeId);
                    obj.OrderTheme = dbContext.OrderThemes.SingleOrDefault(x => x.Id == obj.OrderThemeId);

                    dbContext.Orders.Add(obj);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<Order> GetOrders(int count = 10)
        {
            return Task.Run(async () =>
            {
                return await Db.GetOrdersAsync(count);
            }).Result;
        }

        public static async Task<List<Order>> GetOrdersAsync(int count)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.Orders.Include("Client").Include("Employee").Include("Employee.Person").Include("Employee.Position").Include("OrderTheme").Take(count <= 0 ? 100 : count).ToListAsync();
            }
        }

        public static Order GetOrder(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.GetOrderAsync(id);
            }).Result;
        }

        public static async Task<Order> GetOrderAsync(string id)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.Orders.Include("Client").Include("Employee").Include("OrderTheme").SingleOrDefaultAsync(x => x.Id == id);
            }
        }
        #endregion
        #region order details
        public static bool UpdateOrderDetails(OrderDetails c)
        {
            return Task.Run(async () =>
            {
                return await Db.UpdateOrderDetailsAsync(c);
            }).Result;
        }

        public static async Task<bool> UpdateOrderDetailsAsync(OrderDetails obj)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                OrderDetails _obj = dbContext.OrderDetails.SingleOrDefault(x => x.Id == obj.Id);
                if (_obj == null)
                {
                    return false;
                }
                else
                {
                    // Выбор только из существующих
                    _obj.Confectionery = dbContext.Confectioneries.SingleOrDefault(x => x.Id == obj.ConfectioneryId);
                    _obj.Order = dbContext.Orders.SingleOrDefault(x => x.Id == obj.OrderId);
                    _obj.Quantity = obj.Quantity;
                    _obj.TotalAmount = obj.TotalAmount;
                    await dbContext.SaveChangesAsync();
                    return true;
                }
            }
        }

        public static string DeleteOrderDetails(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.DeleteOrderDetailsAsync(id);
            }).Result;
        }

        public static async Task<string> DeleteOrderDetailsAsync(string id)
        {
            try
            {
                using (DefDbContext dbContext = new DefDbContext())
                {
                    OrderDetails _obj = dbContext.OrderDetails.SingleOrDefault(x => x.Id == id);
                    if (_obj != null)
                    {
                        dbContext.OrderDetails.Remove(_obj);
                        await dbContext.SaveChangesAsync();
                    }
                }
                return "Success";
            }
            catch (Exception e)
            {
                return GetInternalExceptionMessage(e);
            }
        }

        public static bool AddOrderDetails(OrderDetails obj)
        {
            return Task.Run(async () =>
            {
                return await Db.AddOrderDetailsAsync(obj);
            }).Result;
        }

        public static async Task<bool> AddOrderDetailsAsync(OrderDetails obj)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                if (dbContext.OrderDetails.SingleOrDefault(x => x.Id == obj.Id) == null)
                {
                    obj.Confectionery = dbContext.Confectioneries.SingleOrDefault(x => x.Id == obj.ConfectioneryId);
                    obj.Order = dbContext.Orders.SingleOrDefault(x => x.Id == obj.OrderId);

                    dbContext.OrderDetails.Add(obj);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<OrderDetails> GetOrderDetails(int count = 10)
        {
            return Task.Run(async () =>
            {
                return await Db.GetOrderDetailsAsync(count);
            }).Result;
        }

        public static async Task<List<OrderDetails>> GetOrderDetailsAsync(int count)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.OrderDetails.Include("Order").Include("Order.Client").Include("Order.Employee.Person").Include("Order.Employee.Position").Include("Order.OrderTheme").Include("Confectionery").Include("Confectionery.ConfectioneryCategory").Take(count <= 0 ? 100 : count).ToListAsync();
            }
        }

        public static OrderDetails GetOrderDetails(string id)
        {
            return Task.Run(async () =>
            {
                return await Db.GetOrderDetailsAsync(id);
            }).Result;
        }

        public static async Task<OrderDetails> GetOrderDetailsAsync(string id)
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                return await dbContext.OrderDetails.Include("Order").Include("Confectionery").SingleOrDefaultAsync(x => x.Id == id);
            }
        }
        #endregion

        public static void Init()
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                #region ratings
                List<Rating> list_r = new List<Rating>
                {
                    new Rating()
                    {
                        Id = "9bef0b69-5c0f-483d-8072-314515d7a4d1",
                        BonusPercent = 1.1f,
                        RatingLevel = 1
                    },
                    new Rating()
                    {
                        Id = "0084850a-c76c-4bb7-b533-40f66e83360a",
                        BonusPercent = 1.5f,
                        RatingLevel = 2
                    },
                    new Rating()
                    {
                        Id = "6e1baf49-cf5d-4f9d-86a2-0052761691f7",
                        BonusPercent = 2f,
                        RatingLevel = 3
                    }
                };
                foreach (var r in list_r)
                {
                    if (dbContext.Ratings.SingleOrDefault(x => x.Id == r.Id) == null) 
                    {
                        dbContext.Ratings.Add(r);
                    }
                }
                dbContext.SaveChanges();
                #endregion
                #region positions
                List<Position> list_p = new List<Position>
                {
                    new Position()
                    {
                        Id = "623d6601-e857-4856-867f-9c277089bc47",
                        PositionName = "Operator",
                        Salary = 1000
                    },
                    new Position()
                    {
                        Id = "685f9c37-f999-42f7-99cd-3bc4fcd87e10",
                        PositionName = "Manager",
                        Salary = 2000
                    },
                    new Position()
                    {
                        Id = "979952ed-dc58-44fe-bd10-c91e99a2a924",
                        PositionName = "Director",
                        Salary = 3000
                    }
                };
                foreach (var p in list_p)
                {
                    if (dbContext.Positions.SingleOrDefault(x => x.Id == p.Id) == null)
                    {
                        dbContext.Positions.Add(p);
                    }
                }
                dbContext.SaveChanges();
                #endregion
                #region persons
                List<Person> list_pr = new List<Person>
                {
                    new Person()
                    {
                        Id = "109b038f-fff5-4b39-9692-686834f8a911",
                        Address = "Russia, Nizhniy Novgorod",
                        Email = "Ivanov@my.com",
                        Firstname = "Ivanov",
                        Name = "Stepan",
                        Secondname = "Razinovich",
                        PassportInfo = "23 12 246124",
                        PhoneNumber = "89124563478"
                    },
                    new Person()
                    {
                        Id = "b89e79a6-25cb-4ce6-a5b7-a0e0958b221f",
                        Address = "Russia, Nizhniy Novgorod",
                        Email = "Vasilyev@my.com",
                        Firstname = "Vasilyev",
                        Name = "Andrey",
                        Secondname = "Aleksandrovich",
                        PassportInfo = "22 11 386527",
                        PhoneNumber = "89239871429"
                    },
                    new Person()
                    {
                        Id = "2298c009-1464-449e-8480-8c842fb72dde",
                        Address = "Russia, Moscow",
                        Email = "Mihalkova@my.com",
                        Firstname = "Mihalkova",
                        Name = "Yuliya",
                        Secondname = "Maksimovna",
                        PassportInfo = "16 24 368092",
                        PhoneNumber = "89998793489"
                    },
                };
                foreach (var pr in list_pr)
                {
                    if (dbContext.Persons.SingleOrDefault(x => x.Id == pr.Id) == null)
                    {
                        dbContext.Persons.Add(pr);
                    }
                }
                dbContext.SaveChanges();
                #endregion
                #region employees
                List<Employee> list_e = new List<Employee>
                {
                    new Employee()
                    {
                        Id = "c2562379-94b1-4ab8-8024-538ec97e5167",
                        Person = dbContext.Persons.First(x=>x.Name == "Stepan"),
                        Position = dbContext.Positions.First(x=>x.PositionName == "Operator"),
                        Rating = dbContext.Ratings.First(x=>x.RatingLevel == 1)
                    },
                    new Employee()
                    {
                        Id = "67c14fc6-df65-410a-9cb8-9695aa9171c7",
                        Person = dbContext.Persons.First(x=>x.Name == "Andrey"),
                        Position = dbContext.Positions.First(x=>x.PositionName == "Manager"),
                        Rating = dbContext.Ratings.First(x=>x.RatingLevel == 1)
                    },
                    new Employee()
                    {
                        Id = "bb2f2920-40e8-4853-8084-eb358609d079",
                        Person = dbContext.Persons.First(x=>x.Name == "Yuliya"),
                        Position = dbContext.Positions.First(x=>x.PositionName == "Director"),
                        Rating = dbContext.Ratings.First(x=>x.RatingLevel == 1)
                    }
                };
                foreach (var e in list_e)
                {
                    if (dbContext.Employees.SingleOrDefault(x => x.Id == e.Id) == null)
                    {
                        dbContext.Employees.Add(e);
                    }
                }
                dbContext.SaveChanges();
                #endregion

                #region clients
                List<Client> list_cl = new List<Client>
                {
                    new Client()
                    {
                        Id = "7d6b1424-e2f1-43b2-8873-9d1d81cd6f00",
                        Firstname = "Smirnov",
                        Name = "Sergey",
                        Secondname = "Teriyakovich",
                        PhoneNumber = "89202357892",
                        DeliveryAddress = "Gorkogo 157"
                    },
                    new Client()
                    {
                        Id = "44e27243-858b-4542-ada9-b8be96963f64",
                        Firstname = "Garispanov",
                        Name = "Anatoliy",
                        Secondname = "Prohorovich",
                        PhoneNumber = "89207934892",
                        DeliveryAddress = "Alekseeva 12"
                    },
                    new Client()
                    {
                        Id = "45ef4990-9c40-4896-a550-547fbe7142ab",
                        Firstname = "Konopalova",
                        Name = "Tatyana",
                        Secondname = "Petrovna",
                        PhoneNumber = "89672353792",
                        DeliveryAddress = "Mironova 7"
                    }
                };
                foreach (var c in list_cl)
                {
                    if (dbContext.Clients.SingleOrDefault(x => x.Id == c.Id) == null)
                    {
                        dbContext.Clients.Add(c);
                    }
                }
                dbContext.SaveChanges();
                #endregion
                #region order themes
                List<OrderTheme> list_ot = new List<OrderTheme>
                {
                    new OrderTheme()
                    {
                        Id = "cb5cb801-4888-4996-bd17-8ac24adc960a",
                        Description = "Birthday"
                    },
                    new OrderTheme()
                    {
                        Id = "bcecf149-7d3e-4578-b9d6-1f2941e36078",
                        Description = "Endless summer"
                    },
                    new OrderTheme()
                    {
                        Id = "9555c1ab-ea94-42e2-882d-a5b3044b892b",
                        Description = "Christmas"
                    }
                };
                foreach (var ot in list_ot)
                {
                    if (dbContext.OrderThemes.SingleOrDefault(x => x.Id == ot.Id) == null)
                    {
                        dbContext.OrderThemes.Add(ot);
                    }
                }
                dbContext.SaveChanges();
                #endregion
                #region order
                List<Order> list_o = new List<Order>
                {
                    new Order()
                    {
                        Id = "b425ecd6-ba89-4123-aca5-7d04f8171cf6",
                        Client = dbContext.Clients.First(),
                        Employee = dbContext.Employees.First(x=>x.Position.PositionName == "Operator"),
                        OrderTheme = dbContext.OrderThemes.First(x=>x.Description == "Birthday")
                    },
                    new Order()
                    {
                        Id = "cc3dc855-8482-43f8-84d6-6c240da4f31d",
                        Client = dbContext.Clients.First(),
                        Employee = dbContext.Employees.First(x=>x.Position.PositionName == "Manager"),
                        OrderTheme = dbContext.OrderThemes.First(x=>x.Description == "Endless summer")
                    },
                    new Order()
                    {
                        Id = "91f1c810-578d-4439-8b94-0cc1e2a9603a",
                        Client = dbContext.Clients.First(x=>x.Firstname == "Konopalova"),
                        Employee = dbContext.Employees.First(x=>x.Position.PositionName == "Director"),
                        OrderTheme = dbContext.OrderThemes.First(x=>x.Description == "Christmas")
                    }
                };
                foreach (var o in list_o)
                {
                    if (dbContext.Orders.SingleOrDefault(x => x.Id == o.Id) == null)
                    {
                        dbContext.Orders.Add(o);
                    }
                }
                dbContext.SaveChanges();
                #endregion

                #region confectionery categories
                List<ConfectioneryCategory> list_cc = new List<ConfectioneryCategory>
                {
                    new ConfectioneryCategory()
                    {
                        Id = "8834c815-27f4-4a96-8140-acd22e928e59",
                        CategoryName = "Pie"
                    },
                    new ConfectioneryCategory()
                    {
                        Id = "00b5a0f3-a991-47b3-b35a-f5c01a3c3a80",
                        CategoryName = "Cake"
                    },
                    new ConfectioneryCategory()
                    {
                        Id = "02933c17-2cf6-44ae-81ad-db01e30eefea",
                        CategoryName = "Ice cream"
                    }
                };
                foreach (var cc in list_cc)
                {
                    if (dbContext.ConfectioneryCategories.SingleOrDefault(x => x.Id == cc.Id) == null)
                    {
                        dbContext.ConfectioneryCategories.Add(cc);
                    }
                }
                dbContext.SaveChanges();
                #endregion
                #region confectioneries
                List<Confectionery> list_c = new List<Confectionery>
                {
                    new Confectionery()
                    {
                        Id = "8834c815-27f4-4a96-8140-acd22e928e59",
                        Name = "Napoleon",
                        Composition = "Cream",
                        Weight = 450,
                        Price = 5,
                        ConfectioneryCategory = dbContext.ConfectioneryCategories.First(x=>x.CategoryName == "Cake")
                    },
                    new Confectionery()
                    {
                        Id = "1bbd6568-dcbe-4934-9a7e-b41a5bb54350",
                        Name = "Ossetian pie",
                        Composition = "Dough",
                        Weight = 1000,
                        Price = 10,
                        ConfectioneryCategory = dbContext.ConfectioneryCategories.First(x=>x.CategoryName == "Pie")
                    },
                    new Confectionery()
                    {
                        Id = "02933c17-2cf6-44ae-81ad-db01e30eefea",
                        Name = "Popsicle Magnate",
                        Composition = "Chocolate",
                        Weight = 72,
                        Price = 1.5f,
                        ConfectioneryCategory = dbContext.ConfectioneryCategories.First(x=>x.CategoryName == "Ice cream")
                    }
                };
                foreach (var c in list_c)
                {
                    if (dbContext.Confectioneries.SingleOrDefault(x => x.Id == c.Id) == null)
                    {
                        dbContext.Confectioneries.Add(c);
                    }
                }
                dbContext.SaveChanges();
                #endregion

                #region order details
                List<OrderDetails> list_od = new List<OrderDetails>
                {
                    new OrderDetails()
                    {
                        Id = "3169165b-82d6-43de-9a2e-4336dbbc9a24",
                        Order = dbContext.Orders.First(x=>x.OrderTheme.Description == "Birthday"),
                        Confectionery = dbContext.Confectioneries.First(x=>x.Name == "Napoleon"),
                        Quantity = 2,
                        TotalAmount = 10
                    },
                    new OrderDetails()
                    {
                        Id = "31595303-74dd-4ee9-9c40-35e9d803d684",
                        Order = dbContext.Orders.First(x=>x.OrderTheme.Description == "Endless summer"),
                        Confectionery = dbContext.Confectioneries.First(x=>x.Name == "Popsicle Magnate"),
                        Quantity = 3,
                        TotalAmount = (decimal)4.5
                    },
                    new OrderDetails()
                    {
                        Id = "d2f99512-4df4-4284-8b05-a3f737045aca",
                        Order = dbContext.Orders.First(x=>x.OrderTheme.Description == "Christmas"),
                        Confectionery = dbContext.Confectioneries.First(x=>x.Name == "Ossetian pie"),
                        Quantity = 1,
                        TotalAmount = 10
                    }
                };
                foreach (var od in list_od)
                {
                    if (dbContext.OrderDetails.SingleOrDefault(x => x.Id == od.Id) == null)
                    {
                        dbContext.OrderDetails.Add(od);
                    }
                }
                dbContext.SaveChanges();
                #endregion
            }
        }

        public static void Drop()
        {
            using (DefDbContext dbContext = new DefDbContext())
            {
                foreach (var item in dbContext.OrderDetails.ToArray())
                {
                    dbContext.OrderDetails.Remove(dbContext.OrderDetails.First(x => x.Id == item.Id));
                }

                foreach (var item in dbContext.Confectioneries.ToArray())
                {
                    dbContext.Confectioneries.Remove(dbContext.Confectioneries.First(x => x.Id == item.Id));
                }

                foreach (var item in dbContext.Orders.ToArray())
                {
                    dbContext.Orders.Remove(dbContext.Orders.First(x => x.Id == item.Id));
                }

                foreach (var item in dbContext.Employees.ToArray())
                {
                    dbContext.Employees.Remove(dbContext.Employees.First(x => x.Id == item.Id));
                }


                foreach (var item in dbContext.ConfectioneryCategories.ToArray())
                {
                    dbContext.ConfectioneryCategories.Remove(dbContext.ConfectioneryCategories.First(x => x.Id == item.Id));
                }
                foreach (var item in dbContext.Persons.ToArray())
                {
                    dbContext.Persons.Remove(dbContext.Persons.First(x => x.Id == item.Id));
                }
                foreach (var item in dbContext.Positions.ToArray())
                {
                    dbContext.Positions.Remove(dbContext.Positions.First(x => x.Id == item.Id));
                }
                foreach (var item in dbContext.Ratings.ToArray())
                {
                    dbContext.Ratings.Remove(dbContext.Ratings.First(x => x.Id == item.Id));
                }
                foreach (var item in dbContext.Clients.ToArray())
                {
                    dbContext.Clients.Remove(dbContext.Clients.First(x => x.Id == item.Id));
                }
                foreach (var item in dbContext.OrderThemes.ToArray())
                {
                    dbContext.OrderThemes.Remove(dbContext.OrderThemes.First(x => x.Id == item.Id));
                }
                dbContext.SaveChanges();
            }
        }
    }
}