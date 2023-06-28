using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrabajoFinal.Models;

public partial class TrabajofinalContext : DbContext
{
    public TrabajofinalContext()
    {
    }

    public TrabajofinalContext(DbContextOptions<TrabajofinalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAlmuerzo> TbAlmuerzos { get; set; }

    public virtual DbSet<TbCena> TbCenas { get; set; }

    public virtual DbSet<TbDesayuno> TbDesayunos { get; set; }

    public virtual DbSet<TbSnack> TbSnacks { get; set; }

    public virtual DbSet<TbUtile> TbUtiles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SQL5106.site4now.net;Initial Catalog=db_a9ac47_trabajofinal;User Id=db_a9ac47_trabajofinal_admin;Password=KiraCc2603");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAlmuerzo>(entity =>
        {
            entity.HasKey(e => e.CodPro).HasName("PK__TB_ALMUE__28BE23B53FDC537D");

            entity.ToTable("TB_ALMUERZO");

            entity.Property(e => e.CodPro)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("COD_PRO");
            entity.Property(e => e.DesPro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DES_PRO");
            entity.Property(e => e.Img)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("IMG");
            entity.Property(e => e.PrePro)
                .HasColumnType("money")
                .HasColumnName("PRE_PRO");
            entity.Property(e => e.StkAct).HasColumnName("STK_ACT");
        });

        modelBuilder.Entity<TbCena>(entity =>
        {
            entity.HasKey(e => e.CodPro).HasName("PK__TB_CENA__28BE23B52B0A89B8");

            entity.ToTable("TB_CENA");

            entity.Property(e => e.CodPro)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("COD_PRO");
            entity.Property(e => e.DesPro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DES_PRO");
            entity.Property(e => e.Img)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("IMG");
            entity.Property(e => e.PrePro)
                .HasColumnType("money")
                .HasColumnName("PRE_PRO");
            entity.Property(e => e.StkAct).HasColumnName("STK_ACT");
        });

        modelBuilder.Entity<TbDesayuno>(entity =>
        {
            entity.HasKey(e => e.CodPro).HasName("PK__TB_DESAY__28BE23B5928FAE1A");

            entity.ToTable("TB_DESAYUNO");

            entity.Property(e => e.CodPro)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("COD_PRO");
            entity.Property(e => e.DesPro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DES_PRO");
            entity.Property(e => e.Img)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("IMG");
            entity.Property(e => e.PrePro)
                .HasColumnType("money")
                .HasColumnName("PRE_PRO");
            entity.Property(e => e.StkAct).HasColumnName("STK_ACT");
        });

        modelBuilder.Entity<TbSnack>(entity =>
        {
            entity.HasKey(e => e.CodPro).HasName("PK__TB_SNACK__28BE23B5F5D602DD");

            entity.ToTable("TB_SNACK");

            entity.Property(e => e.CodPro)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("COD_PRO");
            entity.Property(e => e.DesPro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DES_PRO");
            entity.Property(e => e.Img)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("IMG");
            entity.Property(e => e.PrePro)
                .HasColumnType("money")
                .HasColumnName("PRE_PRO");
            entity.Property(e => e.StkAct).HasColumnName("STK_ACT");
        });

        modelBuilder.Entity<TbUtile>(entity =>
        {
            entity.HasKey(e => e.CodPro).HasName("PK__TB_UTILE__28BE23B5B2601521");

            entity.ToTable("TB_UTILES");

            entity.Property(e => e.CodPro)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("COD_PRO");
            entity.Property(e => e.DesPro)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DES_PRO");
            entity.Property(e => e.Img)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("IMG");
            entity.Property(e => e.PrePro)
                .HasColumnType("money")
                .HasColumnName("PRE_PRO");
            entity.Property(e => e.StkAct).HasColumnName("STK_ACT");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIO__5B65BF97E563917E");

            entity.ToTable("USUARIO");

            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Imagen)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
