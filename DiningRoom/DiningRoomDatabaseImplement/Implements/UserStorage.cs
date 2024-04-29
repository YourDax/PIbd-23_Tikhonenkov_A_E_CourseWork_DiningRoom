using DiningRoomContracts.BindingModels;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.StorageContracts;
using DiningRoomContracts.ViewModels;
using DiningRoomDatabaseImplement.Models;
using DiningRoomDataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomDatabaseImplement.Implements
{

	public class UserStorage : IUserStorage
	{
		public List<UserViewModel> GetFullList()
		{
			using var context = new DiningRoomDatabase();
			return context.Users.Select(x => x.GetViewModel).ToList();
		}

		public UserViewModel? GetElement(UserSearchModel model)
		{
			//!!!МБ ЭТУ ПРОВЕРКУ УБРАТЬ
			if (string.IsNullOrEmpty(model.Login) && string.IsNullOrEmpty(model.Email) && !model.Id.HasValue)
			{
				return null;
			}
			using var context = new DiningRoomDatabase();

			//Поиск пользователя при входе в систему по логину, паролю и его роли (чтобы не могли войти в аккаунты другой роли) 
			if (!string.IsNullOrEmpty(model.Login) && !string.IsNullOrEmpty(model.Password) && model.Role.HasValue)
			{
				return context.Users.FirstOrDefault(x => x.Login == model.Login && x.Password == model.Password)?.GetViewModel;
			}
			//!!!НИЖЕ МБ НЕ НАДО
			//Получение по логину (пользователей с таким логином будет 1 или 0)
			if (!string.IsNullOrEmpty(model.Login))
			{
				return context.Users.FirstOrDefault(x => x.Login == model.Login)?.GetViewModel;
			}
			//Получение по почте (пользователей с такой почтой будет 1 или 0)
			else if (!string.IsNullOrEmpty(model.Email))
			{
				return context.Users.FirstOrDefault(x => x.Email == model.Email)?.GetViewModel;
			}
			//Получение по id
			return context.Users.FirstOrDefault(x => x.Id == model.Id)?.GetViewModel;
		}

		public UserViewModel? Insert(UserBindingModel model)
		{
			var newUser = User.Create(model);
			if (newUser == null)
			{
				return null;
			}
			using var context = new DiningRoomDatabase();
			context.Users.Add(newUser);
			context.SaveChanges();
			return newUser.GetViewModel;
		}

		public UserViewModel? Update(UserBindingModel model)
		{
			using var context = new DiningRoomDatabase();
			var user = context.Users.FirstOrDefault(x => x.Id == model.Id);
			if (user == null)
			{
				return null;
			}
			user.Update(model);
			context.SaveChanges();
			return user.GetViewModel;
		}

		//!!!МБ И НЕ НУЖЕН
		public UserViewModel? Delete(UserBindingModel model)
		{
			using var context = new DiningRoomDatabase();
			var user = context.Users.FirstOrDefault(rec => rec.Id == model.Id);
			if (user != null)
			{
				context.Users.Remove(user);
				context.SaveChanges();
				return user.GetViewModel;
			}
			return null;
		}
	}
}
