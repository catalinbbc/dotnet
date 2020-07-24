using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiClient : ControllerBase
    {
        //private readonly HttpClient httpClient;
        private readonly IHttpClientFactory httpClientFactory;


        public WebApiClient(IHttpClientFactory factory)
        {
            //this.httpClient = httpClient;
            this.httpClientFactory = factory;
            
        }

        //public object JsonConvert { get; private set; }

        public async Task<IActionResult> GetAlbums()
        {
            var httpClient = this.httpClientFactory.CreateClient("albums-api");

            //use Auth to get the token

            var json = JsonConvert.SerializeObject(new { username = "test", password = "test" });

            var postData = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync($"Users/authenticate/", postData);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return this.NotFound();
                }
            }

            var result = await response.Content.ReadAsStringAsync();

            dynamic authorizationData = JsonConvert.DeserializeObject<dynamic>(result);
            string token = authorizationData.token;


            //use the token to make requests
            var httpClientForAlbums = this.httpClientFactory.CreateClient("albums-api");

            httpClientForAlbums.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //simulate 100 requests for getAlbums
            List<Task<HttpResponseMessage>> tasks = new List<Task<HttpResponseMessage>>();
            for (var i = 0; i < 100; i++)
            {
                tasks.Add(httpClientForAlbums.GetAsync($"/api/Albums/"));
            }
            Task.WaitAll(tasks.ToArray());

            HttpResponseMessage responseStudents = tasks.First().Result;
            var resultStudents = await responseStudents.Content.ReadAsStringAsync();

            dynamic theAlbums = JsonConvert.DeserializeObject<dynamic>(resultStudents);

            return this.Ok(theAlbums);

        }


    }
}
