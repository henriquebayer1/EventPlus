using Microsoft.AspNetCore.Http.HttpResults;
using System.Diagnostics.Tracing;
using webapi.event_.manha.Contexts;
using webapi.event_.manha.Domains;
using webapi.event_.manha.Interfaces;
using webapi.event_.manha.Utils;

namespace webapi.event_.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext ctx;

        public UsuarioRepository()
        {
            ctx = new EventContext();
        }

        public Usuario Login(string email, string senha)
        {
           Usuario usuarioBuscado = ctx.Usuario.Select(u => new Usuario
           {
               IdUsuario = u.IdUsuario,
               Nome = u.Nome,
               Email = u.Email,
               Senha = u.Senha,
               TiposUsuario = new TiposUsuario
               {
                   IdTipoUsuario = u.IdUsuario,
                   Titulo = u.TiposUsuario.Titulo
               }

           }).FirstOrDefault(u => u.Email == email)!;

            if (usuarioBuscado != null)

            {
                bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere)
                {
                    return usuarioBuscado;
                }
            }
            return null!;
        }

        public Usuario BuscarPorId(Guid id)
        {
            Usuario usuarioBuscado = ctx.Usuario.Select(u => new Usuario 
            { IdUsuario = u.IdUsuario,
             Nome = u.Nome,

             TiposUsuario = new TiposUsuario
             {
                 IdTipoUsuario= u.IdTipoUsuario,
                 Titulo = u.TiposUsuario!.Titulo
             }


            }).FirstOrDefault(f => f.IdUsuario == id)!;

            if (usuarioBuscado != null)
            {
                return usuarioBuscado;

            }
            return null!;
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
           Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(e => e.IdUsuario == id);

            ctx.Usuario.Remove(usuarioBuscado);

            ctx.SaveChanges();

        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();

        }

        public string Atualizar(Usuario usuario, Guid id)
        {
           Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(f => f.IdUsuario == id)!;

            if (usuarioBuscado != null)
            {
                usuarioBuscado.Nome = usuario.Nome;

                usuarioBuscado.Email = usuario.Email;

                usuarioBuscado.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Usuario.Update(usuarioBuscado);

                ctx.SaveChanges();


            }
            return ("Email ou senha invalidos");




        }
    }
}
