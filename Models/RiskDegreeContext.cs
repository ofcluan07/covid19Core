using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiskDegree.Models;

namespace RiskDegree.Models
{
    public partial class RiskDegreeContext : DbContext
    {
        public RiskDegreeContext()
        {
        }

        public RiskDegreeContext(DbContextOptions<RiskDegreeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<Patologia> Patologia { get; set; }
        public virtual DbSet<Variacoes> Variacoes { get; set; }

        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=localhost;Database=RiskDegree;Integrated Security=True");
            }
        }*/

       /* public void ConfigureServices(IServiceCollection services)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
         .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configurationRoot = configurationBuilder.Build();

            var connection = configurationRoot.GetConnectionString("RiskDegreeDatabase");

            services.AddDbContext<RiskDegreeContext>(options => options.UseSqlServer(connection));
            services.AddControllersWithViews();

        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataHora).HasColumnType("datetime");

                entity.Property(e => e.Device).HasMaxLength(10);

                entity.Property(e => e.Idpatologia).HasColumnName("IDPatologia");

                entity.Property(e => e.Ip).HasColumnName("IP");

            });

            modelBuilder.Entity<Patologia>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome).HasMaxLength(200);
            });

            modelBuilder.Entity<Variacoes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idpatologia).HasColumnName("IDPatologia");

                entity.HasOne(d => d.IdpatologiaNavigation)
                    .WithMany(p => p.Variacoes)
                    .HasForeignKey(d => d.Idpatologia)
                    .HasConstraintName("FK_Variacoes_Patologia");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<RiskDegree.Models.VariacoesWeb> Covid19Brasil { get; set; }
    }
}
