using DiningRoomView;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.StorageContracts;
using DiningRoomDatabaseImplement.Implements;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DiningRoomBusinessLogic.BusinessLogic;



namespace DiningRoomView
{
    internal static class Program
    {
        private static ServiceProvider? _serviceProvider;
        public static ServiceProvider? ServiceProvider => _serviceProvider;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
            Application.Run(_serviceProvider.GetRequiredService<FormMain>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(option =>
            {
                option.SetMinimumLevel(LogLevel.Information);
            });
            services.AddTransient<IComponentStorage, ComponentStorage>();
            services.AddTransient<IProductStorage, ProductStorage>();
            services.AddTransient<IDrinkStorage, DrinkStorage>();
            services.AddTransient<ICardStorage, CardStorage>();
            services.AddTransient<IOrderStorage, OrderStorage>();

            services.AddTransient<IComponentLogic, ComponentLogic>();
            services.AddTransient<IProductLogic, ProductLogic>();
            services.AddTransient<IDrinkLogic, DrinkLogic>();
            services.AddTransient<ICardLogic, CardLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();

            services.AddTransient<FormMain>();
            services.AddTransient<FormComponent>();
            services.AddTransient<FormComponents>();
            services.AddTransient<FormProduct>();
            services.AddTransient<FormProductComponent>();
            services.AddTransient<FormDrink>();
            services.AddTransient<FormDrinkComponent>();



        }
    }
}