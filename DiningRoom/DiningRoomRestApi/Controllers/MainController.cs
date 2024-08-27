using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;
using DiningRoomDatabaseImplement;
using DiningRoomDatabaseImplement.Models;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;

namespace DiningRoomRestApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class MainController : Controller
	{
		private readonly ILogger _logger;
		private readonly ICardLogic _card;
		private readonly IOrderLogic _order;
		private readonly IProductLogic _product;
		private readonly IComponentLogic _component;
		private readonly IDrinkLogic _drink;
		public MainController(ILogger<MainController> logger, ICardLogic card, IOrderLogic order, IProductLogic product, IComponentLogic component, IDrinkLogic drink)
		{
			_logger = logger;
			_card = card;
			_order = order;
			_product = product;
			_component = component;
			_drink = drink;
		}
		[HttpGet]
		public List<CardViewModel>? GetCardList(int Id)
		{
			try
			{
				return _card.ReadList(new CardSearchModel
				{
					Id = Id,
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error get list Card");
				throw;
			}
		}

		[HttpGet]
		public List<OrderViewModel>? GetOrderList(int UserId)
		{
			try
			{
				return _order.ReadList(new OrderSearchModel
				{
					UserId = UserId,
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error get list Order");
				throw;
			}
		}

		[HttpGet]
		public List<ProductViewModel>? GetProductList(int UserId)
		{
			try
			{
				return _product.ReadList(new ProductSearchModel
				{
					UserId = UserId,
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error get list Product");
				throw;
			}
		}
        [HttpPost]
        public void CreateProduct(ProductBindingModel model)
        {
            try
            {
                _product.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error create Product");
                throw;
            }
        }

        [HttpPost]
        public void UpdateProduct(ProductBindingModel model)
        {
            try
            {
                _product.Update(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error update Product");
                throw;
            }
        }
        [HttpPost]
        public void DeleteProduct(ProductBindingModel model)
        {
            try
            {
                _product.Delete(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error delete Product");
                throw;
            }
        }
        [HttpGet]
		public List<ComponentViewModel>? GetComponentList(int UserId)
		{
			try
			{
				return _component.ReadList(new ComponentSearchModel
				{
					UserId = UserId,
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error get list Component");
				throw;
			}
		}
        [HttpPost]
        public void CreateComponent(ComponentBindingModel model)
        {
            try
            {
                _component.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error create Component");
                throw;
            }
        }

        [HttpGet]
		public List<DrinkViewModel>? GetDrinkList(int userId)
		{
			try
			{
				return _drink.ReadList(new DrinkSearchModel
				{
					UserId = userId,
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error get list Drink");
				throw;
			}
		}

		[HttpPost]
		public void UpdateOrder(OrderBindingModel model)
		{
			try
			{
				_order.Update(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error update Order");
				throw;
			}
		}

		[HttpGet]
		public OrderViewModel? GetOrder(int orderId)
		{
			try
			{
				return _order.ReadElement(new OrderSearchModel
				{
					Id = orderId
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error get order by id={Id}", orderId);
				throw;
			}
		}

		[HttpPost]
		public void CreateOrder(OrderBindingModel model)
		{
			try
			{
				_order.Create(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error create Order");
				throw;
			}
		}

		[HttpPost]
		public void DeleteOrder(OrderBindingModel model)
		{
			try
			{
				_order.Delete(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error delete Order");
				throw;
			}
		}

		[HttpPost]
		public void UpdateComponent(ComponentBindingModel model)
		{
			try
			{
				_component.Update(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error update Component");
				throw;
			}
		}

		[HttpGet]
		public ComponentViewModel? GetComponent(int componentId)
		{
			try
			{
				return _component.ReadElement(new ComponentSearchModel
				{
					Id = componentId
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error get Component by id={Id}", componentId);
				throw;
			}
		}

		

		[HttpPost]
		public void DeleteComponent(ComponentBindingModel model)
		{
			try
			{
				_component.Delete(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error delete Component");
				throw;
			}
		}

		[HttpPost]
		public void CreateCard(CardBindingModel model)
		{
			try
			{
				_card.Create(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error create Card");
				throw;
			}
		}

		[HttpPost]
		public void UpdateCard(CardBindingModel model)
		{
			try
			{
				_card.Update(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error update Card");
				throw;
			}
		}
        [HttpPost]
		public void DeleteCard(CardBindingModel model)
		{
			try
			{
				_card.Delete(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error delete card");
				throw;
			}
		}

		
		[HttpPost]
        public void CreateDrink(DrinkBindingModel model)
        {
            try
            {
                _drink.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error create Drink");
                throw;
            }
        }
		[HttpPost]
		public void UpdateDrink(DrinkBindingModel model)
		{

			try
			{
				_drink.Update(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error update Drink");
				throw;
			}
		}

        [HttpPost]
		public void DeleteDrink(DrinkBindingModel model)
		{
			try
			{
				_drink.Delete(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error delete Drink");
				throw;
			}
		}

		[HttpGet]
		public List<ProductViewModel>? GetProducts()
		{
			try
			{
				return _product.ReadList(null);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения списка конференций");
				throw;
			}
		}
		[HttpGet]
		public List<DrinkViewModel>? GetDrinks()
		{
			try
			{
				return _drink.ReadList(null);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения списка конференций");
				throw;
			}
		}
		[HttpGet]
		public DrinkViewModel GetDrinkById(int drinkId)
		{
			try
			{
				var elem = _drink.ReadElement(new DrinkSearchModel { Id = drinkId });
				if (elem == null)
					return null;
				return elem;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения по id={Id}", drinkId);
				throw;
			}
		}
        [HttpGet]
        public ProductViewModel GetProductById(int productId)
        {
            try
            {
                var elem = _product.ReadElement(new ProductSearchModel { Id = productId });
                if (elem == null)
                    return null;
                return elem;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения по id={Id}", productId);
                throw;
            }
        }
    }
}
