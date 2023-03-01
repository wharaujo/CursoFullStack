using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contrato
{
    public interface IPalestrantesPersist
    {
        //PALESTRANTE
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool IncludeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool IncludeEventos);
        Task<Palestrante> GetPalestranteAsync(int palestranteId, bool IncludeEventos);
    }
}