using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IUsuarioRepository
    {

        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid id);

        Usuario Login(string email, string senha);

        void Deletar(Guid id);

        List<Usuario> Listar();

        string Atualizar(Usuario usuario, Guid id);  
    }
}
