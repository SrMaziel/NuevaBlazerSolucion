using InformacionCrud.Shared;
using System.Net.Http.Json;

namespace InformacionCrud.Cliente.Services
{
    public class CiudadanoService : ICiudadanoService
    {
        private readonly HttpClient _http;

        public CiudadanoService(HttpClient http)
        {
            _http = http;
        }


        public async Task<List<CiudadanoDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<CiudadanoDTO>>>("api/ciudadano/Lista");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }



        public async Task<CiudadanoDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<CiudadanoDTO>>($"api/ciudadano/Buscar/{id}");

            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }



        public async Task<int> Guardar(CiudadanoDTO ciudadano)
        {
            var result = await _http.PostAsJsonAsync("api/ciudadano/Guardar", ciudadano);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<int> Editar(CiudadanoDTO ciudadano)
        {
            var result = await _http.PutAsJsonAsync($"api/ciudadano/Editar/{ciudadano.Idciudadano}", ciudadano);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/ciudadano/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto!;
            else
                throw new Exception(response.Mensaje);
        }



       
    }
}
