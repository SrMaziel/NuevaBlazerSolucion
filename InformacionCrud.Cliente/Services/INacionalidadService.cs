using InformacionCrud.Shared;

namespace InformacionCrud.Cliente.Services
{
    public interface INacionalidadService
    {
        Task<List<NacionalidadDTO>> Lista();
    }
}
