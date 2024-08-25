using InformacionCrud.Shared;
using System.Net.Http.Json;

namespace InformacionCrud.Cliente.Services
{
    public class TiposdelitoService : ITiposdelitoService
    {
        private readonly HttpClient _http;

        public TiposdelitoService(HttpClient http)
        {
            _http = http;
        }

       public async Task<List<TiposdelitosDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TiposdelitosDTO>>>("api/tiposdelito/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
    }
}
