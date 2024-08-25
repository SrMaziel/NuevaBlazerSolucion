using InformacionCrud.Shared;

namespace InformacionCrud.Cliente.Services
{
    public interface ITipodocumentoService
    {
        Task<List<TipodocumentosDTO>> Lista();
    }
}
