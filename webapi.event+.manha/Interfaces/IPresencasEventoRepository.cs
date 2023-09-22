using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IPresencasEventoRepository
    {


        void Cadastrar(PresencasEvento presencaEvento);

        void Atualizar(Guid id, PresencasEvento presencaEventoAtualizada);

        List<PresencasEvento> ListarTodos();

        PresencasEvento BuscarPorId(Guid id);


    }
}
