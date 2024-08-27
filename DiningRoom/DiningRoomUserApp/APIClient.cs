using DiningRoomContracts.ViewModels;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace DiningRoomUserApp
{
    public class APIClient
    {
        private static readonly HttpClient _user = new();

        public static UserViewModel? User { get; set; } = null;

		public static void Connect(IConfiguration configuration)
        {
            _user.BaseAddress = new Uri(configuration["IPAddress"]);
            _user.DefaultRequestHeaders.Accept.Clear();
            _user.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static T? GetRequest<T>(string requestUrl)
        {
            var response = _user.GetAsync(requestUrl);
            var result = response.Result.Content.ReadAsStringAsync().Result;
            if (response.Result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(result);
            }
            else
            {
                throw new Exception(result);
            }
        }

        public static void PostRequest<T>(string requestUrl, T model)
        {
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _user.PostAsync(requestUrl, data);

            var result = response.Result.Content.ReadAsStringAsync().Result;
            if (!response.Result.IsSuccessStatusCode)
            {
                throw new Exception(result);
            }
        }
    }
}
