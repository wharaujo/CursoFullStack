using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application
{
    public interface IEventosServices
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEvento(int eventoId, Evento model);
        Task<bool> DeleteEventos(int eventoId);

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool IncludePalestrante = false);
        Task<Evento[]> GetAllEventosAsync(bool IncludePalestrante = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool IncludePalestrante = false);
    }
}