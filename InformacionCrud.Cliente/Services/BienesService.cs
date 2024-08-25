
using InformacionCrud.Shared;
using System.Net.Http.Json;

namespace InformacionCrud.Cliente.Services
{
    public class BienesService : iBienesService
    {
        private readonly HttpClient _http;

        public BienesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<BienesDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<BienesDTO>>>("api/biene/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
    }
}
