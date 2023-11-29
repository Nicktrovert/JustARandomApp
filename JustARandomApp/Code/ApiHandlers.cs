using Newtonsoft.Json;
namespace JustARandomApp.Code
{
    public interface IApiHandler
    {
        public Task<string> GetImage(string type);
    }
    public class RanCatApi
    {
        public string url { get; set; }
    }
    public class RanCatApiHandler : IApiHandler
    {
        private HttpClient httpC = new();
        private HttpResponseMessage httpRM = new();
        private RanCatApi ranCatApi = new();
        public async Task<string> GetImage(string type)
        {
            httpRM = await httpC.GetAsync("https://api.thecatapi.com/v1/images/search");
            if (httpRM.IsSuccessStatusCode)
            {
                string result = await httpRM.Content.ReadAsStringAsync();
                result = result.Replace("[", "").Replace("]", "");
                ranCatApi = JsonConvert.DeserializeObject<RanCatApi>(result);
            }
            return ranCatApi.url;
        }
    }
    public class RanDogApi
    {
        public string message { get; set; }
    }
    public class RanDogApiHandler : IApiHandler
    {
        private HttpClient httpC = new();
        private HttpResponseMessage httpRM = new();
        private RanDogApi ranDogApi = new();
        public async Task<string> GetImage(string type)
        {
            httpRM = await httpC.GetAsync("https://dog.ceo/api/breeds/image/random");
            if (httpRM.IsSuccessStatusCode)
            {
                string result = await httpRM.Content.ReadAsStringAsync();
                ranDogApi = JsonConvert.DeserializeObject<RanDogApi>(result);
            }
            return ranDogApi.message;
        }
    }
    public class RanAnimeGirlApi
    {
        public string url { get; set; }
    }
    public class RanAnimeGirlApiHandler : IApiHandler
    {
        private HttpClient httpC = new();
        private HttpResponseMessage httpRM = new();
        private RanAnimeGirlApi ranAnimeGirlApi = new();
        public async Task<string> GetImage(string type)
        {
            httpRM = await httpC.GetAsync("https://api.waifu.pics/sfw/" + type);
            if (httpRM.IsSuccessStatusCode)
            {
                string result = await httpRM.Content.ReadAsStringAsync();
                ranAnimeGirlApi = JsonConvert.DeserializeObject<RanAnimeGirlApi>(result);
            }
            return ranAnimeGirlApi.url;
        }
    }
}