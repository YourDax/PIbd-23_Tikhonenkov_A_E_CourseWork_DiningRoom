using DiningRoomBusinessLogic.BusinessLogics;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.StorageContracts;
using DiningRoomDatabaseImplement.Implements;
using Microsoft.OpenApi.Models;

var Builder = WebApplication.CreateBuilder(args);


Builder.Services.AddTransient<IUserStorage, UserStorage>();
Builder.Services.AddTransient<ICardStorage, CardStorage>();
Builder.Services.AddTransient<IDrinkStorage, DrinkStorage>();
Builder.Services.AddTransient<IOrderStorage, OrderStorage>();
Builder.Services.AddTransient<IComponentStorage, ComponentStorage>();
Builder.Services.AddTransient<IProductStorage, ProductStorage>();

Builder.Services.AddTransient<IUserLogic, UserLogic>();
Builder.Services.AddTransient<ICardLogic, CardLogic>();
Builder.Services.AddTransient<IDrinkLogic, DrinkLogic>();
Builder.Services.AddTransient<IOrderLogic, OrderLogic>();
Builder.Services.AddTransient<IComponentLogic, ComponentLogic>();
Builder.Services.AddTransient<IProductLogic, ProductLogic>();

Builder.Services.AddTransient<IReportLogic, ReportLogic>();


Builder.Services.AddControllers();
Builder.Services.AddEndpointsApiExplorer();
Builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DiningRoomRestApi",
        Version = "v1"
    });
});

var App = Builder.Build();

if (App.Environment.IsDevelopment())
{
    App.UseSwagger();
    App.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DiningRoomRestApi v1"));
}

App.UseHttpsRedirection();
App.UseAuthorization();
App.MapControllers();

App.Run();
