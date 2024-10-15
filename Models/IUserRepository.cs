using System.Linq;

namespace IletisimForm.Models
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; } 

        User GetById(int userId); 

        IEnumerable<User> GetUsersByDepartment(Department department);
        IEnumerable<User> GetUsersByFilters(string firstname=null , string department=null);

        void CreateUser(User newUser); 

        void UpdateUser(User updatedUser); 

        void DeleteUser(int userId); 

    }
}
