using InformacionCrud.Shared;
namespace InformacionCrud.Cliente.Services
{
    public interface ICiudadanoService
    {
        Task<List<CiudadanoDTO>> Lista();
        Task<CiudadanoDTO> Buscar(int id);
        Task<int> Guardar(CiudadanoDTO ciudadano);
        Task<int> Editar (CiudadanoDTO ciudadano);
        Task<bool> Eliminar(int id );
    }
}
