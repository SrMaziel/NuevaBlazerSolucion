using InformacionCrud.Shared;

namespace InformacionCrud.Cliente.Services
{
    public interface iBienesService
    {
        Task<List<BienesDTO>> Lista();
    }
}
