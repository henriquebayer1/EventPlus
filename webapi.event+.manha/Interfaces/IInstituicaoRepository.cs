using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Interfaces
{
    public interface IInstituicaoRepository
    {

        void Cadastrar(Instituicao instituicao);

        List<Instituicao> Listar();

        Instituicao BuscarPorId(Guid id);

        void Atualizar(Guid id, Instituicao evento);

        void Deletar(Guid id);

    }
}
