using DiningRoomBusinessLogic.BusinessLogic;
using DiningRoomBusinessLogic.MailWorker;

//using DiningRoomBusinessLogic.MailWorker;
using DiningRoomBusinessLogic.OfficePackage;
using DiningRoomBusinessLogic.OfficePackage.Implements;
using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.StorageContracts;
using DiningRoomDatabaseImplement.Implements;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.SetMinimumLevel(LogLevel.Trace);
// Add services to the container.

builder.Services.AddTransient<IComponentStorage, ComponentStorage>();
builder.Services.AddTransient<IProductStorage, ProductStorage>();
builder.Services.AddTransient<IDrinkStorage, DrinkStorage>();
builder.Services.AddTransient<ICardStorage, CardStorage>();
builder.Services.AddTransient<IOrderStorage, OrderStorage>();
builder.Services.AddTransient<IUserStorage, UserStorage>();

builder.Services.AddTransient<IComponentLogic, ComponentLogic>();
builder.Services.AddTransient<IProductLogic, ProductLogic>();
builder.Services.AddTransient<IDrinkLogic, DrinkLogic>();
builder.Services.AddTransient<ICardLogic, CardLogic>();
builder.Services.AddTransient<IOrderLogic, OrderLogic>();
builder.Services.AddTransient<IUserLogic, UserLogic>();

builder.Services.AddSingleton<AbstractMailWorker, MailKitWorker>();
builder.Services.AddTransient<AbstractSaveToPdf, SaveToPdf>();
builder.Services.AddTransient<IReportLogic, ReportLogic>();
builder.Services.AddTransient<AbstractSaveToExcel, SaveToExcel>();
builder.Services.AddTransient<AbstractSaveToWord, SaveToWord>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DiningRoomRestApi",
        Version = "v1"
    });
});

var app = builder.Build();
var mailSender = app.Services.GetService<AbstractMailWorker>();
mailSender?.MailConfig(new MailConfigBindingModel
{
    MailLogin = builder.Configuration?.GetSection("MailLogin")?.Value?.ToString()
?? string.Empty,
    MailPassword =
builder.Configuration?.GetSection("MailPassword")?.Value?.ToString() ??
string.Empty,
    SmtpClientHost =
builder.Configuration?.GetSection("SmtpClientHost")?.Value?.ToString() ??
string.Empty,
    SmtpClientPort =
Convert.ToInt32(builder.Configuration?.GetSection("SmtpClientPort")?.Value?.ToString()),
    PopHost = builder.Configuration?.GetSection("PopHost")?.Value?.ToString() ??
string.Empty,
    PopPort = Convert.ToInt32(builder.Configuration?.GetSection("PopPort")?.Value?.ToString())
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DiningRoomRestApi v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
