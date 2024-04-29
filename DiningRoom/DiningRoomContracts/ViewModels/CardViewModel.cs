using DiningRoomDataModels.Models;
using System.ComponentModel;

namespace DiningRoomContracts.ViewModels
{
	public class CardViewModel : ICardModel
	{
		public int Id { get; set; }

		public int UserId { get; set; }


		[DisplayName("Название карты")]
		public string CardName { get; set; } = string.Empty;
        public Dictionary<int, (IDrinkModel, int)> DrinkCard { get; set; } = new();
    }
}
