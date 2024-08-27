using DiningRoomUserApp;
using DiningRoomBusinessLogic.BusinessLogic;
using DiningRoomBusinessLogic.OfficePackage;
using DiningRoomBusinessLogic.OfficePackage.Implements;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.StorageContracts;
using DiningRoomDatabaseImplement.Implements;
using DiningRoomBusinessLogic.MailWorker;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductStorage, ProductStorage>();
builder.Services.AddTransient<IProductLogic, ProductLogic>();
builder.Services.AddTransient<IComponentStorage, ComponentStorage>();
builder.Services.AddTransient<IComponentLogic, ComponentLogic>();
builder.Services.AddTransient<IReportLogic, ReportLogic>();
builder.Services.AddTransient<AbstractSaveToPdf, SaveToPdf>();
builder.Services.AddTransient<AbstractSaveToExcel, SaveToExcel>();
builder.Services.AddTransient<AbstractSaveToWord, SaveToWord>();
builder.Services.AddSingleton<AbstractMailWorker, MailKitWorker>();

var app = builder.Build();
APIClient.Connect(builder.Configuration);
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
