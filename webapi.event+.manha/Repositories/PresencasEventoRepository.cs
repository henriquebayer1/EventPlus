using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class PresencasEventoRepository : IPresencasEventoRepository
    {
        private readonly EventContext ctx = new EventContext();

        public PresencasEventoRepository()
        {
            ctx = new EventContext();
        }


        public void Atualizar(Guid id, PresencasEvento presencaEventoAtualizada)
        {
            PresencasEvento presencaEventoBuscada = ctx.PresencasEvento.FirstOrDefault(f => f.IdPresencasEvento == id)!;

            presencaEventoBuscada.Situacao = presencaEventoAtualizada.Situacao;

            presencaEventoBuscada.IdUsuario = presencaEventoAtualizada.IdUsuario;

            presencaEventoBuscada.IdEvento = presencaEventoAtualizada.IdEvento;

            ctx.PresencasEvento.Update(presencaEventoBuscada);

            ctx.SaveChanges();
        }

        public PresencasEvento BuscarPorId(Guid id)
        {
            PresencasEvento presencaEventoBuscada =  ctx.PresencasEvento.FirstOrDefault(f => f.IdPresencasEvento == id)!;

            if (presencaEventoBuscada != null)
            {
                return presencaEventoBuscada;
            }
            return null!;

        }

        public void Cadastrar(PresencasEvento presencaEvento)
        {
            ctx.PresencasEvento.Add(presencaEvento);

            ctx.SaveChanges();
            
        }

        public List<PresencasEvento> ListarTodos()
        {
            
            return ctx.PresencasEvento.ToList();


        }
    }
}
