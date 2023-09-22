using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface ITiposUsuarioRepository
    {

        void Cadastrar(TiposUsuario tiposUsuario);

        void Deletar(Guid id);

        List<TiposUsuario> Listar();

        TiposUsuario BuscarPorId(Guid id);

        void Atualizar(Guid id, TiposUsuario tiposUsuario);


    }
}
