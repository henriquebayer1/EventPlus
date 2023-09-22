using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class ComentariosEventoRepository : IComentariosEventoRepository
    {
        private readonly EventContext ctx;
        public ComentariosEventoRepository()
        {
            ctx = new EventContext();

        }

        public ComentariosEvento BuscarPorId(Guid id)
        {
            ComentariosEvento comentarioBuscado = ctx.ComentariosEvento.FirstOrDefault(f => f.IdComentariosEvento == id);

            if (comentarioBuscado != null)
            {
                return comentarioBuscado;
            }
            return null;
        }

        public void Cadastrar(ComentariosEvento comentario)
        {
            ctx.ComentariosEvento.Add(comentario);

            ctx.SaveChanges();

        }

        public void Deletar(Guid id)
        {
           ComentariosEvento comentarioBuscado = ctx.ComentariosEvento.FirstOrDefault(f => f.IdComentariosEvento == id)!;

            ctx.ComentariosEvento.Remove(comentarioBuscado!);

            ctx.SaveChanges();

        }

        public List<ComentariosEvento> Listar()
        {
            return ctx.ComentariosEvento.ToList();
        }
    }
}
