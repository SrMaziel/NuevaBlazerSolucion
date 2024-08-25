using InformacionCrud.Shared;

namespace InformacionCrud.Cliente.Services
{
    public interface ITiposdelitoService
    {
        Task<List<TiposdelitosDTO>> Lista();
    }
}
