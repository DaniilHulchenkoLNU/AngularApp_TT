using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace AngularApp_TT.Server.Service
{
    public class JsonService
    {
        public async Task<T> DeserializeJsonAsync<T>(Stream jsonStream)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return await JsonSerializer.DeserializeAsync<T>(jsonStream, options);
        }
    }
}
