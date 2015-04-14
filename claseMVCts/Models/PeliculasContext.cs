using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using claseMVCts.Models.Mapping;

namespace claseMVCts.Models
{
    public partial class PeliculasContext : DbContext
    {
        static PeliculasContext()
        {
            Database.SetInitializer<PeliculasContext>(null);
        }

        public PeliculasContext()
            : base("Name=PeliculasContext")
        {
        }

        public DbSet<Pelicula> Peliculas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PeliculaMap());
        }
    }
}
