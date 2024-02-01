using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HttpClientFactoryController : ControllerBase
    {
        private string baseUrl = "https://jsonplaceholder.typicode.com/";
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientFactoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<List<Todo>> Get()
        {

            using (System.Net.Http.HttpClient client = _httpClientFactory.CreateClient(/*"MyApiClient"*/))
            {
                try
                {
                    client.BaseAddress = new Uri(baseUrl);

                    //var response = await client.GetStringAsync("todos");
                    HttpResponseMessage response = await client.GetAsync("todos");

                    //string data = await response.Content.ReadAsStringAsync();

                    //var model = JsonConvert.DeserializeObject<List<Todo>>(data);

                    List<Todo>? todoList = await response.Content.ReadFromJsonAsync<List<Todo>>();

                    return todoList;
                }
                catch (Exception ex)
                {
                    await Console.Out.WriteLineAsync(ex.Message + ex.InnerException);
                    return null;
                }

            }

        }
    }
}
