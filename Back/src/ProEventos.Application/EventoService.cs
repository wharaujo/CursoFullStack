using System;
using System.Threading.Tasks;
using ProEventos.Domain;
using ProEventos.Persistence.Contrato;

namespace ProEventos.Application
{
    public class EventoService : IEventosServices
    {
        private readonly IGeralPersist _geralPersist;
        private readonly IEventosPersist _eventosPersist;
        public EventoService(IGeralPersist geralPersist, IEventosPersist eventosPersist)
        {
            _geralPersist = geralPersist;
            _eventosPersist = eventosPersist;
        }

        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventosPersist.GetEventoByIdAsync(model.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
           try
           {
                var evento = await _eventosPersist.GetEventoByIdAsync(eventoId, false);
                if(evento == null) return null;

                model.Id = evento.Id;

                _geralPersist.Update(model);
                 if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventosPersist.GetEventoByIdAsync(model.Id, false);
                }

                return null;
           }
           catch (Exception ex)
           {
            throw new Exception(ex.Message);
           }
        }

        public async Task<bool> DeleteEventos(int eventoId)
        {
            try
           {
                var evento = await _eventosPersist.GetEventoByIdAsync(eventoId, false);
                if(evento == null) throw new Exception("Evento para delete não encontrado.");

                _geralPersist.Delete<Evento>(evento);
                
                return await _geralPersist.SaveChangesAsync();
           }
           catch (Exception ex)
           {
            throw new Exception(ex.Message);
           }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool IncludePalestrante = false)
        {
            try
            {
                var eventos = await _eventosPersist.GetAllEventosAsync(IncludePalestrante);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool IncludePalestrante = false)
        {
              try
            {
                var eventos = await _eventosPersist.GetAllEventosByTemaAsync(tema, IncludePalestrante);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool IncludePalestrante = false)
        {
              try
            {
                var eventos = await _eventosPersist.GetEventoByIdAsync(eventoId, IncludePalestrante);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}