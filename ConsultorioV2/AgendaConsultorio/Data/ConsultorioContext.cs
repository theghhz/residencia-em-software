using Microsoft.EntityFrameworkCore;

    public class ConsultorioContext : DbContext
    {
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        public ConsultorioContext(DbContextOptions<ConsultorioContext> options) 
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("Pacientes");
                entity.HasKey(p => p.CPF); // CPF como chave primária
                entity.Property(p => p.CPF).HasMaxLength(11).IsRequired();
                entity.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            });


            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.ToTable("Agendamentos");
                entity.HasKey(a => a.AgendamentoId); // Chave primária do agendamento
                entity.Property(a => a.CPF).HasMaxLength(11).IsRequired();

                // Relacionamento Agendamento -> Paciente
                entity.HasOne(a => a.Paciente)
                      .WithMany(p => p.Agendamentos)
                      .HasForeignKey(a => a.CPF)
                      .OnDelete(DeleteBehavior.Restrict); // Evitar exclusão em cascata
            });
        }
    }

// dotnet ef migrations add UpdateCPFAsPrimaryKey
// dotnet ef database update

// dotnet ef migrations add InitialCreate
// dotnet ef database update

//psql -h localhost -U consultorio_user -d consultorio


