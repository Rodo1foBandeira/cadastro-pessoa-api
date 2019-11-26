using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cadastro_pessoa_api.Models
{
    public partial class PBD_Prj03Context : DbContext
    {
        public PBD_Prj03Context()
        {
            //Database.AutoTransactionsEnabled = false;
        }

        public PBD_Prj03Context(DbContextOptions<PBD_Prj03Context> options)
            : base(options)
        {
            //options.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Bairro> Bairro { get; set; }
        public virtual DbSet<Cidade> Cidade { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<Fone> Fone { get; set; }
        public virtual DbSet<LogPessoa> LogPessoa { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Uf> Uf { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=rodolfo;password=123;database=PBD_Prj03");
            }            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");            

            modelBuilder.Entity<Bairro>(entity =>
            {
                entity.ToTable("bairro", "PBD_Prj03");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.ToTable("cidade", "PBD_Prj03");

                entity.HasIndex(e => e.UfId)
                    .HasName("cid_uf_id");
                
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);
                
                entity.Property(e => e.UfId)
                    .HasColumnName("uf_id")
                    .HasColumnType("int(11)");
                /*
                entity.HasOne(d => d.Uf)
                    .WithMany(p => p.Cidades)
                    .HasForeignKey("uf_id");
                    */
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.ToTable("email", "PBD_Prj03");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("ema_pes_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email1)
                    .HasColumnName("email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PessoaId)
                    .HasColumnName("pessoa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasMaxLength(20)
                    .IsUnicode(false);
                /*
                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ema_pes_id");
                    */
            });

            modelBuilder.Entity<Fone>(entity =>
            {
                entity.ToTable("fone", "PBD_Prj03");

                entity.HasIndex(e => e.PessoaId)
                    .HasName("fon_pes_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ddd)
                    .HasColumnName("ddd")
                    .HasColumnType("int(3)");

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("int(9)");

                entity.Property(e => e.PessoaId)
                    .HasColumnName("pessoa_id")
                    .HasColumnType("int(11)");
                /*
                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Fones)
                    .HasForeignKey(d => d.PessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fon_pes_id");
                */
            });

            modelBuilder.Entity<LogPessoa>(entity =>
            {
                entity.HasKey(e => e.IdLog);

                entity.ToTable("log_pessoa", "PBD_Prj03");

                entity.Property(e => e.IdLog)
                    .HasColumnName("id_log")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BairroId)
                    .HasColumnName("bairro_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cep)
                    .HasColumnName("cep")
                    .HasColumnType("char(9)");

                entity.Property(e => e.CidadeId)
                    .HasColumnName("cidade_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CpfCnpj)
                    .HasColumnName("cpf_cnpj")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.DataModificacao).HasColumnName("data_modificacao");

                entity.Property(e => e.Endereco)
                    .HasColumnName("endereco")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NomeRazao)
                    .HasColumnName("nome_razao")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPessoa)
                    .HasColumnName("tipo_pessoa")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("pessoa", "PBD_Prj03");

                entity.HasIndex(e => e.BairroId)
                    .HasName("pes_bai_id");

                entity.HasIndex(e => e.CidadeId)
                    .HasName("pes_cid_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BairroId)
                    .HasColumnName("bairro_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cep)
                    .HasColumnName("cep")
                    .HasColumnType("char(9)");

                entity.Property(e => e.CidadeId)
                    .HasColumnName("cidade_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CpfCnpj)
                    .HasColumnName("cpf_cnpj")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .HasColumnName("endereco")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeRazao)
                    .HasColumnName("nome_razao")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoPessoa)
                    .HasColumnName("tipo_pessoa")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                /*
                entity.HasOne(d => d.Bairro)
                    .WithMany(p => p.Pessoa)
                    .HasForeignKey(d => d.BairroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pes_bai_id");

                entity.HasOne(d => d.Cidade)
                    .WithMany(p => p.Pessoa)
                    .HasForeignKey(d => d.CidadeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pes_cid_id");
                    */
            });

            modelBuilder.Entity<Uf>(entity =>
            {
                entity.ToTable("uf", "PBD_Prj03");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sigla)
                    .HasColumnName("sigla")
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });
        }
    }
}
