
namespace IletisimForm.Models
{
    public class EfUserRepository:IUserRepository
    {
        private AppDbContext context;
        public EfUserRepository(AppDbContext _context)
        {
            context = _context;
        }

        public IQueryable<User> Users => throw new NotImplementedException();

        public void CreateUser(User newUser)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            context.Users.Remove(new User() { Id = userId });
            context.SaveChanges();
        }

        public User GetById(int userId)
        {
            return context.Users.Find(userId);
        }

        public IEnumerable<User> GetUsersByDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsersByFilters(string firstname = null, string department = null)
        {
            IQueryable<User> query = context.Users;
            if (firstname != null)
            {
                query=query.Where(i=> i.FirstName.ToLower().Contains(firstname.ToLower()));
            }

            if (department!=null)
            {
                query = query.Where(i => i.Department.ToLower() == department.ToLower());
            }
            return query.ToList();


        }

        public void UpdateUser(User updatedUser)
        {
           var user = context.Users.Find(updatedUser.Id);
            if (user != null) 
            {
                user.FirstName = updatedUser.FirstName;
                user.Telephone = updatedUser.Telephone;
                user.Eposta = updatedUser.Eposta;
                user.Department=updatedUser.Department;
                user.Message = updatedUser.Message;
                context.SaveChanges();
                

                
            }
        }
    }
}
