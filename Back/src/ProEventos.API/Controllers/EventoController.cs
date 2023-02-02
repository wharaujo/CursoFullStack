using System;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;
using System.Collections.Generic;
using System.Linq;
using ProEventos.API.Data;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly DataContext _context;
        public EventoController(DataContext context){
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
          return _context.Eventos;
        }

        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
          return _context.Eventos.FirstOrDefault(evento => evento.EventoId == id);
        }

        [HttpPost("{id}")]
        public string Post(int id)
        {
            return $"Exemplo de Post criando o Id = {id}";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo de Put no Id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete no Id = {id}";
        }
    }
}
