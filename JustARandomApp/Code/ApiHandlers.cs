using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace JustARandomApp.Code
{
    public class RanCatApi
    {
        public string id { get; set; }
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
    public class RanCatApiHandler
    {
        private HttpClient httpC;
        private HttpResponseMessage httpRM;
        private RanCatApi ranCatApi = new RanCatApi();

        public RanCatApiHandler()
        {
            httpC = new HttpClient();
            httpRM = new HttpResponseMessage();
        }

        public async Task<string> GetImage()
        {
            httpRM = await httpC.GetAsync("https://api.thecatapi.com/v1/images/search");

            if (httpRM.IsSuccessStatusCode)
            {
                string result = await httpRM.Content.ReadAsStringAsync();
                result = result.Replace("[", "").Replace("]", "");
                ranCatApi = JsonConvert.DeserializeObject<RanCatApi>(result);
            }
            System.Diagnostics.Debug.Print(ranCatApi.url + " | " + ranCatApi.id);
            return ranCatApi.url;
        }
    }
    public class RanDogApi
    {
        public string message { get; set; }
        public string status { get; set; }
    }
    public class RanDogApiHandler
    {
        private HttpClient httpC;
        private HttpResponseMessage httpRM;
        private RanDogApi ranDogApi = new RanDogApi();

        public RanDogApiHandler()
        {
            httpC = new HttpClient();
            httpRM = new HttpResponseMessage();
        }

        public async Task<string> GetImage()
        {
            httpRM = await httpC.GetAsync("https://dog.ceo/api/breeds/image/random");

            if (httpRM.IsSuccessStatusCode)
            {
                string result = await httpRM.Content.ReadAsStringAsync();
                ranDogApi = JsonConvert.DeserializeObject<RanDogApi>(result);
            }
            System.Diagnostics.Debug.Print(ranDogApi.message + " | " + ranDogApi.status);
            return ranDogApi.message;
        }
    }
    public class RanAnimeGirlApi
    {
        public string url { get; set; }
    }
    public class RanAnimeGirlApiHandler
    {
        private HttpClient httpC;
        private HttpResponseMessage httpRM;
        private RanAnimeGirlApi ranAnimeGirlApi = new RanAnimeGirlApi();

        public RanAnimeGirlApiHandler()
        {
            httpC = new HttpClient();
            httpRM = new HttpResponseMessage();
        }
        public async Task<string> GetImage(string type)
        {
            httpRM = await httpC.GetAsync("https://api.waifu.pics/sfw/" + type);
            if (httpRM.IsSuccessStatusCode)
            {
                string result = await httpRM.Content.ReadAsStringAsync();
                ranAnimeGirlApi = JsonConvert.DeserializeObject<RanAnimeGirlApi>(result);
            }
            System.Diagnostics.Debug.Print(ranAnimeGirlApi.url);
            return ranAnimeGirlApi.url;
        }
    }
}
