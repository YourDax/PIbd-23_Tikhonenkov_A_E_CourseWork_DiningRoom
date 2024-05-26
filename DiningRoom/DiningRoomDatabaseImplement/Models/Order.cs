using DiningRoomContracts.BindingModels;
using DiningRoomContracts.ViewModels;
using DiningRoomDatabaseImplement.Models;
using DiningRoomDatabaseImplement;
using DiningRoomDataModels.Enums;
using DiningRoomDataModels.Models;
using System.ComponentModel.DataAnnotations;

public class Order : IOrderModel
{
    [Required]
    public string Name { get; set; }
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int Count { get; set; }

    public double Sum { get; set; }
    [Required]
    public OrderStatus Status { get; set; }
    [Required]
    public DateTime DateCreate { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public virtual Product? Product { get; set; }

    public static Order? Create(OrderBindingModel model)
    {
        if (model == null)
        {
            return null;
        }
        return new Order()
        {
            Id = model.Id,
            Name = model.Name,
            UserId = model.UserId,
            ProductId = model.ProductId,
            Count = model.Count,
            Sum = model.Sum,
            DateCreate = model.DateCreate,
            Status = model.Status,
        };
    }

    public void Update(OrderBindingModel? model)
    {
        if (model == null)
        {
            return;
        }
        using var context = new DiningRoomDatabase();
        Status = model.Status;
        ProductId = model.ProductId;
        Count = model.Count;
        Sum = model.Sum;
        context.SaveChanges();
    }

    public OrderViewModel GetViewModel
    {
        get
        {
            using var context = new DiningRoomDatabase();
            return new OrderViewModel
            {
                Id = Id,
                Name = Name,
                UserId = UserId,
                Login = context.Users.FirstOrDefault(x => x.Id == UserId)?.Login ?? string.Empty,
                ProductId = ProductId,
                ProductName = ProductId.HasValue ? context.Products.FirstOrDefault(x => x.Id == ProductId)?.ProductName ?? string.Empty : null,
                DateCreate = DateCreate,
                Status = Status,
                Count = Count,
                Sum = Sum
            };
        }
    }
}
