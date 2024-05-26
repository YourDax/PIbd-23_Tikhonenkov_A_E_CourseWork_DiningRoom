using DiningRoomContracts.BindingModels;
using DiningRoomContracts.ViewModels;
using DiningRoomDatabaseImplement.Models;
using DiningRoomDatabaseImplement;
using DiningRoomDataModels.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Drink : IDrinkModel
{
    public int Id { get; private set; }
    public int UserId { get; set; }
    public User User { get; set; }

    [Required]
    public string DrinkName { get; private set; } = string.Empty;

    public int? CardId { get; set; }

    [Required]
    public double Cost { get; private set; }

    public virtual Card? Card { get; set; }

    [ForeignKey("DrinkId")]
    public virtual List<DrinkComponent> Components { get; set; } = new();

    private Dictionary<int, (IComponentModel, int)>? _drinkComponents;

    [NotMapped]
    public Dictionary<int, (IComponentModel, int)> DrinkComponents
    {
        get
        {
            if (_drinkComponents == null)
            {
                _drinkComponents = Components.ToDictionary(
                    DrkComp => DrkComp.ComponentId,
                    DrkComp => (DrkComp.Component as IComponentModel, DrkComp.Count)
                );
            }

            return _drinkComponents;
        }
    }

    public static Drink Create(DiningRoomDatabase Context, DrinkBindingModel Model)
    {
        return new()
        {
            Id = Model.Id,
            DrinkName = Model.DrinkName,
            CardId = Model.CardId,
            Cost = Model.Cost,
            Components = Model.DrinkComponents.Select(x => new DrinkComponent
            {
                Component = Context.Components.First(y => y.Id == x.Key),
                Count = x.Value.Item2
            }).ToList(),
            UserId = Model.UserId,
        };
    }
    public void Update(DrinkBindingModel model)
    {
        DrinkName = model.DrinkName;
        Cost = model.Cost;
        CardId = model.CardId;
    }
    public DrinkViewModel GetViewModel
    {
        get
        {
            using var context = new DiningRoomDatabase();
            return new DrinkViewModel
            {
                Id = Id,
                DrinkName = DrinkName,
                Cost = Cost,
                CardId = CardId,
                CardName = CardId.HasValue ? context.Cards.FirstOrDefault(x => x.Id == CardId)?.CardName ?? string.Empty : null,
                DrinkComponents = DrinkComponents
            };
        }
    }
    public void UpdateComponents(DiningRoomDatabase context, DrinkBindingModel model)
    {
        var drinkComponents = context.DrinkComponents.Where(rec => rec.DrinkId == model.Id).ToList();
        if (drinkComponents != null && drinkComponents.Count > 0)
        { // удалили те, которых нет в модели
            context.DrinkComponents.RemoveRange(drinkComponents.Where(rec => !model.DrinkComponents.ContainsKey(rec.ComponentId)));
            context.SaveChanges();
            // обновили количество у существующих записей
            foreach (var updateComponent in drinkComponents)
            {
                updateComponent.Count = model.DrinkComponents[updateComponent.ComponentId].Item2;
                model.DrinkComponents.Remove(updateComponent.ComponentId);
            }
            context.SaveChanges();
        }
        var drink = context.Drinks.First(x => x.Id == Id);
        foreach (var pc in model.DrinkComponents)
        {
            context.DrinkComponents.Add(new DrinkComponent
            {
                Drink = drink,
                Component = context.Components.First(x => x.Id == pc.Key),
                Count = pc.Value.Item2
            });
            context.SaveChanges();
        }
        _drinkComponents = null;
    }
}
