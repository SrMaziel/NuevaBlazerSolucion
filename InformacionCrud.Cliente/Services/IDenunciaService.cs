using InformacionCrud.Shared;

namespace InformacionCrud.Cliente.Services
{
	public interface IDenunciaService
	{
		Task<List<DenunciaDTO>> Lista();
		Task<DenunciaDTO> Buscar(int id);
		Task<int> Guardar(DenunciaDTO denuncia);
		Task<int> Editar(DenunciaDTO denuncia);
		Task<bool> Eliminar(int id);
	}
}
