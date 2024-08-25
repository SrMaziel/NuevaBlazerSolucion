using InformacionCrud.Shared;
using System.Net.Http.Json;

namespace InformacionCrud.Cliente.Services
{
    public class TipodocumentoService : ITipodocumentoService
    {
        private readonly HttpClient _http;

        public TipodocumentoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TipodocumentosDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<TipodocumentosDTO>>>("api/tipodocumento/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
    }
}
