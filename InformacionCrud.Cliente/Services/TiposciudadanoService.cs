using InformacionCrud.Shared;
using System.Net.Http.Json;

namespace InformacionCrud.Cliente.Services
{
    public class TiposciudadanoService : ITiposciudadanoService
    {
        private readonly HttpClient _http;

        public TiposciudadanoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TiposciudadanosDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TiposciudadanosDTO>>>("api/tiposciudadano/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
    }
}
