using Microsoft.EntityFrameworkCore;
using webapi.event_.manha.Domains;

namespace webapi.event_.manha.Contexts
{
    public class EventContext : DbContext
    {

        public DbSet<ComentariosEvento> ComentariosEvento { get; set; }

        public DbSet<Evento> Evento { get; set; }

        public DbSet<Instituicao> Instituicao { get; set; }

        public DbSet<PresencasEvento> PresencasEvento { get; set; }

        public DbSet<TiposEvento> TiposEvento { get; set; }

        public DbSet<TiposUsuario> TiposUsuario { get; set; }

        public DbSet<Usuario> Usuario { get; set; }




        //Define as opcoes de construcao do banco(String Conexao)

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE01-S15; Database = Event+_Manha_CodeFirst; User Id = SA; Pwd = Senai@134; TrustServerCertificate = true;");
        }


    }
}
