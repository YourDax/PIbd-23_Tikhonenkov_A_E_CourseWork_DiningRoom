using DiningRoomContracts.BindingModels;
using DiningRoomContracts.ViewModels;
using DiningRoomDataModels.Enums;
using DiningRoomDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomDatabaseImplement.Models
{
	public class User : IUserModel
	{
		public int Id { get; private set; }

		[Required]
		public string Login { get; set; } = string.Empty;

		[Required]
		public string Password { get; set; } = string.Empty;

		
		[Required]
		public string Email { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public virtual List<Card> Cards { get; set; } = new();
        [ForeignKey("UserId")]
        public virtual List<Order> Orders { get; set; } = new();

        [ForeignKey("UserId")]
        public virtual List<Drink> Drinks { get; set; } = new();
        [ForeignKey("UserId")]
        public virtual List<Component> Components { get; set; } = new();

        [ForeignKey("UserId")]
        public virtual List<Product> Products { get; set; } = new();


        public static User Create(UserBindingModel model)
		{
			return new User
			{
				Id = model.Id,
				Login = model.Login,
				Password = model.Password,
				Email = model.Email
			};
		}

		public void Update(UserBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			Login = model.Login;
			Password = model.Password;
			Email = model.Email;
		}

		
		public UserViewModel GetViewModel => new()
		{
			Id = Id,
			Login = Login,
			Password = Password,
			Email = Email,

		};
	}
}
