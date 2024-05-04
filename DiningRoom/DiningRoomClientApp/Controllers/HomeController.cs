using DiningRoomClientApp.Models;
using DiningRoomContracts.BindingModels;
using DiningRoomContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DiningRoomClientApp;


namespace DiningRoomClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (APIUser.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(/*APIUser.GetRequest<List<OrderViewModel>>($"api/main/getorders?userId={APIUser.User.Id}")*/);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            if (APIUser.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIUser.User);
        }

        [HttpPost]
        public void Privacy(string login, string password, string email)
        {
            if (APIUser.User == null)
            {
                throw new Exception("Вход только авторизованным");
            }
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                throw new Exception("Введите логин, пароль и почту");
            }
            APIUser.PostRequest("api/user/updatedata", new UserBindingModel
            {
                Id = APIUser.User.Id,
                Login = login,
                Password = password,
                Email = email
            });

            APIUser.User.Login = login;
            APIUser.User.Password = password;
            APIUser.User.Email = email;
            Response.Redirect("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                throw new Exception("Введите логин и пароль");
            }
            APIUser.User = APIUser.GetRequest<UserViewModel>($"api/user/login?login={login}&password={password}");
            if (APIUser.User == null)
            {
                throw new Exception("Неверный логин/пароль");
            }
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public void Register(string login, string password, string email)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                throw new Exception("Введите логин, пароль и почту");
            }
            APIUser.PostRequest("api/user/register", new UserBindingModel
            {
                Login = login,
                Password = password,
                Email = email
            });
            Response.Redirect("Enter");
            return;
        }
    }
}