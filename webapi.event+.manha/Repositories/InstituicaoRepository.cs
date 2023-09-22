using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;

namespace webapi.event_.manha.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext ctx;

        public InstituicaoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, Instituicao instituicaoAtualizada)
        {
            Instituicao instituicaoBuscada = ctx.Instituicao.FirstOrDefault(f => f.IdInstituicao == id)!;

            instituicaoBuscada.CNPJ = instituicaoAtualizada.CNPJ;

            instituicaoBuscada.Endereco = instituicaoAtualizada.Endereco;

            instituicaoBuscada.NomeFantasia = instituicaoAtualizada.NomeFantasia;

            ctx.Instituicao.Update(instituicaoBuscada);

            ctx.SaveChanges();


        }

        public Instituicao BuscarPorId(Guid id)
        {
            Instituicao instituicaoBuscada = ctx.Instituicao.FirstOrDefault(f => f.IdInstituicao == id)!;

            if (instituicaoBuscada != null)
            {
                return instituicaoBuscada;

            }
            return null!;
        }

        public void Cadastrar(Instituicao instituicao)
        {
            ctx.Instituicao.Add(instituicao);

            ctx.SaveChanges();
           
        }

        public void Deletar(Guid id)
        {
            Instituicao instituicaoBuscada = ctx.Instituicao.FirstOrDefault(f => f.IdInstituicao == id)!;

            ctx.Instituicao.Remove(instituicaoBuscada);

            ctx.SaveChanges();
        }

        public List<Instituicao> Listar()
        {
           return ctx.Instituicao.ToList();


        }
    }
}
