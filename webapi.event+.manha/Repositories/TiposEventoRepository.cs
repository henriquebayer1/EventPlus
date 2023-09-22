using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class TiposEventoRepository : ITiposEventoRepository
    {

        private readonly EventContext ctx;

        public TiposEventoRepository()
        {
            ctx = new EventContext();
        }


        public void Atualizar(Guid id, TiposEvento novoTipoEvento)
        {
            TiposEvento tipoEventoBuscado = ctx.TiposEvento.FirstOrDefault(f => f.IdTipoEvento == id);

            tipoEventoBuscado.Titulo = novoTipoEvento.Titulo;

            ctx.TiposEvento.Update(tipoEventoBuscado);

            ctx.SaveChanges();
        }

        public TiposEvento BuscarPorId(Guid id)
        {
            TiposEvento tipoEventoBuscado = ctx.TiposEvento.FirstOrDefault(f => f.IdTipoEvento == id)!;

            if (tipoEventoBuscado != null)
            {
                return tipoEventoBuscado;
            }
            return null;

        }

        public void Cadastrar(TiposEvento tiposEvento)
        {
            ctx.TiposEvento.Add(tiposEvento);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            TiposEvento tiposEventoBuscado = ctx.TiposEvento.FirstOrDefault(e => e.IdTipoEvento == id);

            ctx.TiposEvento.Remove(tiposEventoBuscado);

            ctx.SaveChanges();
        }

        public List<TiposEvento> Listar()
        {

            return ctx.TiposEvento.ToList();

        }



    }
}
