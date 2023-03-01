using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contrato
{
    public interface IEventosPersist
    {
        //EVENTOS
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool IncludePalestrante);
        Task<Evento[]> GetAllEventosAsync(bool IncludePalestrante);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool IncludePalestrante);
    }
}