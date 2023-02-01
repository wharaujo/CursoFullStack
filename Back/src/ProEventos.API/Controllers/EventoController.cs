using System;
using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[] {
            new Evento() {
                EventoId = 1,
                Tema = "Angular 11 e .NET 5",
                Local = "Salvador",
                DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                QtdPessoas = 250,
                Lote = "1º Lote",
                ImagemURL = "foto.png"
            },
                new Evento() {
                EventoId = 2,
                Tema = ".NET 5 e novidades",
                Local = "Rio de Janeiro",
                DataEvento = DateTime.Now.AddDays(5).ToString("dd/MM/yyyy"),
                QtdPessoas = 250,
                Lote = "2º Lote",
                ImagemURL = "imagem.png"
            }
        };

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
          return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
          return _evento.Where(evento => evento.EventoId == id);
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
