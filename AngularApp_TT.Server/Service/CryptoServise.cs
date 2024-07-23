using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AngularApp_TT.Server.Models.Entity;

namespace AngularApp_TT.Server.Services
{
    public class CryptoService
    {
        private readonly HttpClient _httpClient;

        public CryptoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<СryptoRate>> FetchCryptoRatesAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<CoinCapResponse>("https://api.coincap.io/v2/assets");
                if (response != null && response.data != null)
                {
                    return response.data;
                }
                return new List<СryptoRate>();
            }
            catch (Exception ex)
            {
                // Логирование ошибки или другие действия
                throw new Exception("Ошибка при получении данных о криптовалютах.", ex);
            }
        }

        private class CoinCapResponse
        {
            public List<СryptoRate> data { get; set; }
            public long timestamp { get; set; }

        }
    }
}
