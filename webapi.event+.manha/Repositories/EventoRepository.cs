using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class EventoRepository : IEventoRepository
    {

        private readonly EventContext ctx;

        public EventoRepository()
        {
            ctx = new EventContext();
        }


        public void Atualizar(Guid id, Evento eventoAtualizado)
        {
            Evento eventoBuscado = ctx.Evento.FirstOrDefault(f => f.IdEvento == id)!;

          
            
                eventoBuscado.DataEvento = eventoAtualizado.DataEvento;

                eventoBuscado.NomeEvento = eventoAtualizado.NomeEvento;

                eventoBuscado.Descricao = eventoAtualizado.Descricao;

                eventoBuscado.IdTipoEvento = eventoAtualizado.IdTipoEvento;

                eventoBuscado.IdInstituicao = eventoAtualizado.IdInstituicao;

                ctx.Evento.Update(eventoBuscado);

                ctx.SaveChanges();

            
            
        }

        public Evento BuscarPorId(Guid id)
        {
           Evento eventoBuscado = ctx.Evento.FirstOrDefault(f => f.IdEvento == id)!;

            if (eventoBuscado != null)
            {
                return eventoBuscado;

            }
            return null!;

            
        }

        public void Cadastrar(Evento evento)
        {
            ctx.Evento.Add(evento);

            ctx.SaveChanges();
            
        }

        public void Deletar(Guid id)
        {
           Evento eventoBuscado = ctx.Evento.FirstOrDefault(f => f.IdEvento == id)!;

            ctx.Evento.Remove(eventoBuscado);

            ctx.SaveChanges();

        }

        public List<Evento> Listar()
        {
            return ctx.Evento.ToList();
        }


    }
}
