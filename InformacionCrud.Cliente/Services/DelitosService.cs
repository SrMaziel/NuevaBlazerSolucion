
using InformacionCrud.Shared;
using System.Net.Http.Json;

namespace InformacionCrud.Cliente.Services
{
    public class DelitosService : IDelitosService
    {
        private readonly HttpClient _http;

        public DelitosService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<DelitosDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<DelitosDTO>>>("api/delitos/Lista");

                if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);


        }
    }
}
