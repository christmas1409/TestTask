using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TextMessengerAPI.Web.Tests.Common
{
    public static class HttpClientExtension
    {
        public static async Task<Guid> FindByClientsAsync(this HttpClient client, string query)
        {
            var response = await client.GetAsync($"Dialog/FindByClients{query}");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var dialogId = JsonConvert.DeserializeObject<Guid>(result);
            return dialogId;
        }
    }
}
