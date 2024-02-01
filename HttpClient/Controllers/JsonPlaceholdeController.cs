using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;

namespace HttpClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonPlaceholdeController : ControllerBase
    {
        //private HttpClient client
        //private readonly IHttpClientFactory _httpClientFactory;

        private string baseUrl = "https://jsonplaceholder.typicode.com/";




        [HttpGet]
        public async Task<List<Todo>> Get()
        {
            //var client = _httpClientFactory.CreateClient();
           
            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
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
                finally
                {
                    client.Dispose();
                }

            }

        }

        [HttpPost]
        public async Task<CreatePost> Post([FromBody] CreatePostDTO model)
        {

            using System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            client.BaseAddress = new Uri(baseUrl);

            //var contentModel = JsonConvert.SerializeObject(model);         //bunu yazmayanda data null gedir
            //var myContent = new StringContent(contentModel, Encoding.UTF8, "application/json");
            //var res = await client.PostAsync("posts", myContent);
            //var dataPostAsync = await res.Content.ReadFromJsonAsync<CreatePost>();
            //return dataPostAsync;

            HttpResponseMessage response = await client.PostAsJsonAsync("posts", model);
            var dataPostAsJsonAsync = await response.Content.ReadFromJsonAsync<CreatePost>();

            return dataPostAsJsonAsync;
        }
    }
}
