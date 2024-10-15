using IletisimForm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace IletisimForm.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUserRepository _repository;

        // Tek constructor kullanarak tüm bağımlılıkları burada enjekte ediyoruz
        public UserController(AppDbContext context, IUserRepository repository)
        {
            _context = context;
            _repository = repository;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetUsers()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();

        }

        [HttpPost]

        public IActionResult CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return View("Thanks", user);

        }

        public IActionResult List(string firstname= null, string department= null)
        {
             
            var users=_repository.GetUsersByFilters(firstname, department);
            ViewBag.Firstname = firstname;
            ViewBag.Department = department;  
            return View(users);
        }


        public IActionResult Edit(int id) 
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);

        }
        [HttpPost]
        public IActionResult Edit(User user)
        {
            _repository.UpdateUser(user);
            return RedirectToAction(nameof(List));

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.DeleteUser(id);
            return RedirectToAction("List");

        } 
    }
}
