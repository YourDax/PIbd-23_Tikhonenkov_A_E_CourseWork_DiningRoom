using DiningRoomContracts.BindingModels;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.StorageContracts;
using DiningRoomContracts.ViewModels;
using DiningRoomDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomDatabaseImplement.Implements
{
	public class CardStorage : ICardStorage
	{
		public List<CardViewModel> GetFullList()
		{
			using var context = new DiningRoomDatabase();
			return context.Cards
				.Include(x => x.Drinks)
				.ToList()
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public List<CardViewModel> GetFilteredList(CardSearchModel model) {
			using var context = new DiningRoomDatabase();

			//сортировка по дате создания заявки
			if (model.DateFrom.HasValue && model.DateTo.HasValue)
			{
				return context.Cards
					.Where(x => (x.DateCardCreate >= model.DateFrom && x.DateCardCreate <= model.DateTo))
					.Include(x => x.Drinks)
					.Select(x => x.GetViewModel)
					.ToList();
			}
			//возвращение просто всех заявок пользователя (замена GetFullList) 
			return context.Cards
				.Where(x => x.Id == model.Id)
				.Include(x => x.Drinks)
				.Select(x => x.GetViewModel)
				.ToList();
		}

		//Поиск только по id, потому что другие поля не уникальные - нет смысла искать 1 элемент
		public CardViewModel? GetElement(CardSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return null;
			}
			using var context = new DiningRoomDatabase();
			return context.Cards
				.Include(x => x.Drinks)
				.FirstOrDefault(x => x.Id == model.Id)
				?.GetViewModel;
		}

		public CardViewModel? Insert(CardBindingModel model)
		{
			using var context = new DiningRoomDatabase();
			var newCard = Card.Create(context, model);
			if (newCard == null)
			{
				return null;
			}
			context.Cards.Add(newCard);
			context.SaveChanges();
			return newCard.GetViewModel;
		}

		public CardViewModel? Update(CardBindingModel model)
		{
			using var context = new DiningRoomDatabase();
			using var transaction = context.Database.BeginTransaction();
			try
			{
				var Card = context.Cards.FirstOrDefault(x => x.Id == model.Id);
				if (Card == null)
				{
					return null;
				}
				Card.Update(model);
				context.SaveChanges();
				transaction.Commit();
				return Card.GetViewModel;
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public CardViewModel? Delete(CardBindingModel model)
		{
			using var context = new DiningRoomDatabase();
			var Card = context.Cards
				.Include(x => x.Drinks)
				.FirstOrDefault(y => y.Id == model.Id);
			if (Card != null)
			{
				context.Cards.Remove(Card);
				context.SaveChanges();
				return Card.GetViewModel;
			}
			return null;
		}
	}
}
