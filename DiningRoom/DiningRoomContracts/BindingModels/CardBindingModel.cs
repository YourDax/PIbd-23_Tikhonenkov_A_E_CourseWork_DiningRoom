using DiningRoomDataModels.Enums;
using DiningRoomDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomContracts.BindingModels
{
	public class CardBindingModel : ICardModel
	{
		public int Id { get; set; }

		public int UserId { get; set; }

        public string CardName { get; set; } = string.Empty;
        
        public Dictionary<int, (IDrinkModel, int)> DrinkCard { get; set; } = new();
	}
}
