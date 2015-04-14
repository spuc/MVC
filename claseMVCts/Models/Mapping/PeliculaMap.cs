using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace claseMVCts.Models.Mapping
{
    public class PeliculaMap : EntityTypeConfiguration<Pelicula>
    {
        public PeliculaMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ActorPrincipal)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.otro)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Peliculas");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Titulo).HasColumnName("Titulo");
            this.Property(t => t.ActorPrincipal).HasColumnName("ActorPrincipal");
            this.Property(t => t.Estreno).HasColumnName("Estreno");
            this.Property(t => t.Precio).HasColumnName("Precio");
            this.Property(t => t.otro).HasColumnName("otro");
        }
    }
}
