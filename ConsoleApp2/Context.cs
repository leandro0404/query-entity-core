using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2
{
    public class Context : DbContext
    {
        public Context()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          // optionsBuilder.UseSqlServer("Server=localhost,11433;Database=Teste;User Id=Sa;Password=DockerSql2017!;");
           optionsBuilder.UseInMemoryDatabase(databaseName: "DataBaseMemory");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClasseTipoParte>(x =>
            {
                x.ToTable("ClasseTipoParte");
                x.HasKey(p => new { CodigoTipoParte = p.CodigoTipoParte });
                x.Property(p => p.Tipo).HasColumnName("Tipo");
                x.Ignore(b => b.ExisteVinculo);
                x.Ignore(b => b.TipoParte);
            });

            modelBuilder.Entity<TipoParte>(etd =>
            {
                etd.ToTable("TipoParte");
                etd.HasKey(p => p.CodigoTipoParte);
                etd.Property(p => p.Descricao).HasColumnName("Descricao");
            });

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ClasseTipoParte> ClasseTipoParte { get; set; }
        public DbSet<TipoParte> TipoParte { get; set; }
    }
}
