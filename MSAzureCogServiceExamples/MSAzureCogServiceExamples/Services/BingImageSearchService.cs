using MSAzureCogServiceExamples.Models.BingSearch;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MSAzureCogServiceExamples.Services
{
    public class BingImageSearchService
    {
        public static async Task<SearchResult> SearchForImages(string url)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", CognitiveServicesKeys.BingSearch);

            var json = await client.GetStringAsync(url);

            var result = JsonConvert.DeserializeObject<SearchResult>(json);

            return result;
        }
    }
}
