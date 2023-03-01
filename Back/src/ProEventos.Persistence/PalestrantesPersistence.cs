using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contexto;
using ProEventos.Persistence.Contrato;

namespace ProEventos.Persistence
{
    public class PalestrantesPersistence : IPalestrantesPersist
    {
        private readonly ProEventosContext _context;
        public PalestrantesPersistence(ProEventosContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
         public async Task<Palestrante[]> GetAllPalestrantesAsync(bool IncludeEventos = false)
        {
             IQueryable<Palestrante> query = _context.Palestrantes
                         .Include(p => p.RedesSociais);

            if(IncludeEventos)
            {
                query = query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool IncludeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                         .Include(p => p.RedesSociais);

            if(IncludeEventos)
            {
                query = query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id)
                        .Where(P => P.Nome.ToLower().Contains(Nome.ToLower()));
            
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteAsync(int palestranteId, bool IncludeEventos)
        {
           IQueryable<Palestrante> query = _context.Palestrantes
                         .Include(p => p.RedesSociais);

            if(IncludeEventos)
            {
                query = query.Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id)
                        .Where(p => p.Id == palestranteId);
            
            return await query.FirstOrDefaultAsync();
        }
    }
}