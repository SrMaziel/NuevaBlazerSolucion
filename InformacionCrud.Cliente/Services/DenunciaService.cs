using InformacionCrud.Shared;
using System.Net.Http.Json;

namespace InformacionCrud.Cliente.Services
{
	public class DenunciaService : IDenunciaService
	{
		private readonly HttpClient _http;

		public DenunciaService(HttpClient http)
		{
			_http = http;
		}


		public async Task<List<DenunciaDTO>> Lista()
		{
			var result = await _http.GetFromJsonAsync<ResponseAPI<List<DenunciaDTO>>>("api/Denuncia/Lista");

			if (result!.EsCorrecto)
				return result.Valor!;
			else
				throw new Exception(result.Mensaje);
		}


		public async Task<DenunciaDTO> Buscar(int id)
		{
			{
				var result = await _http.GetFromJsonAsync<ResponseAPI<DenunciaDTO>>($"api/Denuncia/Buscar/{id}");

				if (result!.EsCorrecto)
					return result.Valor!;
				else
					throw new Exception(result.Mensaje);
			}
		}


		public async Task<int> Guardar(DenunciaDTO denuncia)
		{
			var result = await _http.PostAsJsonAsync("api/Denuncia/Guardar", denuncia);
			var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

			if (response!.EsCorrecto)
				return response.Valor!;
			else
				throw new Exception(response.Mensaje);
		}


		public async Task<int> Editar(DenunciaDTO denuncia)
		{
			var result = await _http.PutAsJsonAsync($"api/Denuncia/Editar/{denuncia.Iddenuncia}", denuncia);
			var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

			if (response!.EsCorrecto)
				return response.Valor!;
			else
				throw new Exception(response.Mensaje);
		}



		public async Task<bool> Eliminar(int id)
		{
			var result = await _http.DeleteAsync("api/Denuncia/Eliminar/{id}");
			var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

			if (response!.EsCorrecto)
				return response.EsCorrecto!;
			else
				throw new Exception(response.Mensaje);
		}

		

		
	}
}
