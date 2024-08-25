using InformacionCrud.Shared;
using System.Net.Http.Json;

namespace InformacionCrud.Cliente.Services
{
    public class NacionalidadService : INacionalidadService
    {
        private readonly HttpClient _http;

        public NacionalidadService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<NacionalidadDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<NacionalidadDTO>>>("api/nacionalidad/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
    }
}
