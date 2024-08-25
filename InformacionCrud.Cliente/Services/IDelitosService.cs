using InformacionCrud.Shared;

namespace InformacionCrud.Cliente.Services
{
    public interface IDelitosService
    {
        Task<List<DelitosDTO>> Lista();
    }
}
