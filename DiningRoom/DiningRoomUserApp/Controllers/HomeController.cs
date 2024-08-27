using DiningRoomUserApp.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using DiningRoomUserApp.Models;
using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;
using DiningRoomDatabaseImplement;
using DiningRoomDatabaseImplement.Models;
using DiningRoomDataModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using DiningRoomDataModels.Enums;
using System.Reflection;

namespace DiningRoomUserApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IComponentLogic _component;
        public HomeController(IComponentLogic component)
        {
            _component = component;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Components()
        {
            if (APIClient.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<ComponentViewModel>>($"api/main/getcomponentlist?userId={APIClient.User.Id}"));
        }
        public IActionResult CreateComponent()
        {
            if (APIClient.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            var componentUnits = Enum.GetValues(typeof(DiningRoomDataModels.Enums.ComponentUnit))
                              .Cast<DiningRoomDataModels.Enums.ComponentUnit>()
                              .Select(e => new SelectListItem
                              {
                                  Value = ((int)e).ToString(),
                                  Text = e.ToString()
                              }).ToList();

            ViewBag.ComponentUnits = new SelectList(componentUnits, "Value", "Text");

            return View();
        }
        [HttpPost]
        public void CreateComponent(string componentName, double componentPrice, ComponentUnit unit)
        {
            if (APIClient.User == null)
            {
                throw new Exception("Необходима авторизация");
            }
            if (componentName.Length <=0 || componentPrice<=0 || unit == ComponentUnit.Неизвестна)
            {
                throw new Exception("Введите данные");
            }

            APIClient.PostRequest("api/main/createcomponent", new ComponentBindingModel
            {
                ComponentName = componentName,
                Cost = componentPrice,
                Unit = unit,
                UserId = APIClient.User.Id,
            });
            Response.Redirect("Components");
        }


        public IActionResult UpdateComponent()
        {
            if (APIClient.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            var componentUnits = Enum.GetValues(typeof(DiningRoomDataModels.Enums.ComponentUnit))
                              .Cast<DiningRoomDataModels.Enums.ComponentUnit>()
                              .Select(e => new SelectListItem
                              {
                                  Value = ((int)e).ToString(),
                                  Text = e.ToString()
                              }).ToList();

            ViewBag.ComponentUnits = new SelectList(componentUnits, "Value", "Text");
            ViewBag.Components = APIClient.GetRequest<List<ComponentViewModel>>($"api/main/getcomponentlist?userid={APIClient.User.Id}");
            return View();
        }
        [HttpPost]
        public void UpdateComponent(int component, string componentName, double componentPrice, ComponentUnit unit)
        {
            if (APIClient.User == null)
            {
                throw new Exception("Необходима авторизация");
            }
            if (componentName.Length <=0 || componentPrice<=0 || unit == ComponentUnit.Неизвестна)
            {
                throw new Exception("Введите данные");
            }
            APIClient.PostRequest("api/main/updatecomponent", new ComponentBindingModel
            {
                Id = component,
                ComponentName = componentName,
                Cost = componentPrice,
                Unit = unit,
                UserId = APIClient.User.Id,
            });
            Response.Redirect("Components");
        }

        public IActionResult DeleteComponent()
        {
            if (APIClient.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Components = APIClient.GetRequest<List<ComponentViewModel>>($"api/main/getcomponentlist?userId={APIClient.User.Id}");
            return View();
        }
        [HttpPost]
        public void DeleteComponent(int component)
        {
            if (APIClient.User == null)
            {
                throw new Exception("Необходима авторизация");
            }
            APIClient.PostRequest("api/main/deletecomponent", new ComponentBindingModel
            {
                Id = component
            });
            Response.Redirect("Components");
        }

        public IActionResult Products()
        {
            if (APIClient.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<ProductViewModel>>($"api/main/getproductlist?userId={APIClient.User.Id}"));
        }
        public IActionResult CreateProduct()
        {
            if (APIClient.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            var list = _component.ReadList(new ComponentSearchModel { UserId = APIClient.User.Id });
            var simpComponent = list.Select(x => new { ComponentId = x.Id, ComponentName = x.ComponentName });
            ViewBag.components = new MultiSelectList(simpComponent, "ComponentId", "ComponentName");
            return View();
        }
        [HttpPost]
        public void CreateProduct(string productName, double productPrice, int[] components)
        {
            if (APIClient.User == null)
            {
                throw new Exception("Необходима авторизация");
            }
            if (productName.Length <=0 || productPrice<=0 || components.Length == 0)
            {
                throw new Exception("Введите данные");
            }
            Dictionary<int, (IComponentModel, int)> _productComponents = new Dictionary<int, (IComponentModel, int)>();
            foreach (int id in components)
            {
                _productComponents.Add(id, (_component.ReadElement(new ComponentSearchModel { Id = id }),1));

            }

            APIClient.PostRequest("api/main/createproduct", new ProductBindingModel
            {
                ProductName = productName,
                Cost = productPrice,
                UserId = APIClient.User.Id,
                ProductComponents = _productComponents,
            });
            Response.Redirect("Products");
        }
        public IActionResult UpdateProduct()
        {
            if (APIClient.User == null)
            {
                return Redirect("~/Home/Enter");
            }

            ViewBag.Products = APIClient.GetRequest<List<ProductViewModel>>($"api/main/getproductlist?userid={APIClient.User.Id}");
            ViewBag.Components = APIClient.GetRequest<List<ComponentViewModel>>($"api/main/getcomponentlist?userid={APIClient.User.Id}");
            return View();
        }
        [HttpPost]
        public void UpdateProduct(int product, string productName, double productPrice, List<int> components)
        {
            if (APIClient.User == null)
            {
                throw new Exception("Необходима авторизация");
            }
            if (productName.Length <= 0 || productPrice <= 0)
            {
                throw new Exception("Введите данные");
            }
            Dictionary<int, (IComponentModel, int)> _productComponents = new Dictionary<int, (IComponentModel, int)>();
            foreach (int id in components)
            {
                _productComponents.Add(id, (new ComponentSearchModel { Id = id } as IComponentModel, 1));

            }
            APIClient.PostRequest("api/main/updateproduct", new ProductBindingModel
            {
                Id = product,
                ProductName = productName,
                Cost = productPrice,
                UserId = APIClient.User.Id,
                ProductComponents = _productComponents,
            });
            Response.Redirect("Products");
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            if (APIClient.User == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.User);
        }
        [HttpPost]
        public void Privacy(string login, string email, string password, string fio, string phone)
        {
            if (APIClient.User == null)
            {
                throw new Exception("Вы как сюда попали? Сюда вход только авторизованным");
            }
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fio) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone))
            {
                throw new Exception("Введите логин, пароль и ФИО");
            }
            APIClient.PostRequest("api/user/updatedata", new UserBindingModel
            {
                Id = APIClient.User.Id,
                Login = login,
                Password = password,
                Email = email,
            });

            APIClient.User.Login = login;
            APIClient.User.Password = password;
            APIClient.User.Email = email;
            Response.Redirect("Index");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public void Register(string login, string email, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                throw new Exception("Введите все данные");
            }
            APIClient.PostRequest("api/user/register", new UserBindingModel
            {
                Login = login,
                Password = password,
                Email = email,
            });

            Response.Redirect("Enter");
            return;
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
            APIClient.User = APIClient.GetRequest<UserViewModel>($"api/user/login?login={login}&password={password}");
            if (APIClient.User == null)
            {
                throw new Exception("Неверный логин/пароль");
            }
            Response.Redirect("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
