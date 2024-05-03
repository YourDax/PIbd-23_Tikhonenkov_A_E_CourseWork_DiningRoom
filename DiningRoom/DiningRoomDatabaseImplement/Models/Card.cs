using DiningRoomContracts.BindingModels;
using DiningRoomContracts.ViewModels;
using DiningRoomDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomDatabaseImplement.Models
{
	public class Card : ICardModel
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CardName { get; set; } = string.Empty;
        public int? DrinkId { get; set; }

        public virtual Drink? Drink { get; set; } = new();
        [Required]
        public DateTime DateCardCreate { get; set; }
        public static Card Create(DiningRoomDatabase context, CardBindingModel model)
        {
            return new Card()
            {
                Id = model.Id,
                CardName = model.CardName,
                UserId = model.UserId,
            };
        }
        public void Update(CardBindingModel model)
        {
            CardName = model.CardName;
        }
        public CardViewModel GetViewModel => new()
        {
            Id = Id,
            CardName = CardName,
            UserId = UserId,
        };
    }
}
