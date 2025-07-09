using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HotelWebAPI.Reservations.Resolver
{
    public class PaymentResolver
    {
        private readonly string _apiUrl = "http://localhost:5032/";

        public async Task<string?> ResolveFor<T>(T dto, string endpoint)
        {
            return await ResolveForExternalPaymentAPI(dto, endpoint);
        }

        private async Task<string?> ResolveForExternalPaymentAPI<T>(T dto, string endpoint)
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri(_apiUrl)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonSerializer.Serialize(dto);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(endpoint, content);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                return null;
            }
        }
    }
}
