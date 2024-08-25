using InformacionCrud.Shared;

namespace InformacionCrud.Cliente.Services
{
    public interface ITiposciudadanoService
    {
        Task<List<TiposciudadanosDTO>> Lista();
    }
}
