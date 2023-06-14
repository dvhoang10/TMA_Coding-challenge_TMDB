using Newtonsoft.Json;

namespace TMDB.API.Utils
{
    public static class Utilities
    {
        public static async Task<T?> GetResponseAsync<T>(HttpResponseMessage httpResponseMessage) where T : class
        {
            if (!httpResponseMessage.IsSuccessStatusCode) return null;

            var response = await httpResponseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(response);

            return result;
        }
    }
}
