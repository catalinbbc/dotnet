using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HotelApiClient
{
    
    class HotelApiClient
    {
        private readonly HttpClient httpClient;
        
        public HotelApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;

            this.httpClient.BaseAddress = new Uri("http://localhost:5005/");

            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<HotelModel> GetHotel(int id)
        {
            var response = await this.httpClient.GetAsync($"api/hotels/{id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<HotelModel>(result);
        }

        public async Task<HotelModel> GetHotelV2(int id)
        {
            var response = await this.httpClient.GetAsync($"api/hotels/{id}");
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();

            using var streamReader = new StreamReader(stream);
            using var jsonReader = new JsonTextReader(streamReader);
            var hotel = new JsonSerializer().Deserialize<HotelModel>(jsonReader);
            return hotel;
        }

        public async Task<HotelModel> CreateHotel(CreateHotelModel model)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await this.httpClient.PostAsync("api/hotels", content);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<HotelModel>(result);
        }

        public class CreateHotelModel
        {
            public string Name { get; set; }

            public string City { get; set; }
        }

        public class HotelModel
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string City { get; set; }
        }
    }

   
}
