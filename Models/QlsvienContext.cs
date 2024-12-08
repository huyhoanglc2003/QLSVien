using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLySinhVien.Models;

public partial class QlsvienContext : DbContext
{
    public QlsvienContext()
    {
    }

    public QlsvienContext(DbContextOptions<QlsvienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Diem> Diems { get; set; }

    public virtual DbSet<Giaovien> Giaoviens { get; set; }

    public virtual DbSet<Loptinchi> Loptinchis { get; set; }

    public virtual DbSet<Monhoc> Monhocs { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Hoang-TUF\\SQLEXPRESS;Initial Catalog=qlsvien;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Diem>(entity =>
        {
            entity.HasKey(e => new { e.Maloptc, e.Mamh, e.Masv }).HasName("PK__diem__1BCE7D965DE324E6");

            entity.ToTable("diem");

            entity.Property(e => e.Maloptc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maloptc");
            entity.Property(e => e.Mamh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mamh");
            entity.Property(e => e.Masv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("masv");
            entity.Property(e => e.Diem1)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("diem");

            entity.HasOne(d => d.MaloptcNavigation).WithMany(p => p.Diems)
                .HasForeignKey(d => d.Maloptc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("diem_loptc");

            entity.HasOne(d => d.MamhNavigation).WithMany(p => p.Diems)
                .HasForeignKey(d => d.Mamh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("diem_monhoc");

            entity.HasOne(d => d.MasvNavigation).WithMany(p => p.Diems)
                .HasForeignKey(d => d.Masv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("diem_sinhvien");
        });

        modelBuilder.Entity<Giaovien>(entity =>
        {
            entity.HasKey(e => e.Magv).HasName("PK__giaovien__7A2118CDCE94E61D");

            entity.ToTable("giaovien");

            entity.Property(e => e.Magv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("magv");
            entity.Property(e => e.Khoa)
                .HasMaxLength(50)
                .HasColumnName("khoa");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("matkhau");
            entity.Property(e => e.Tengv)
                .HasMaxLength(50)
                .HasColumnName("tengv");
        });

        modelBuilder.Entity<Loptinchi>(entity =>
        {
            entity.HasKey(e => e.Maloptc).HasName("PK__loptinch__9116405817A6662A");

            entity.ToTable("loptinchi");

            entity.Property(e => e.Maloptc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("maloptc");
            entity.Property(e => e.Hocki).HasColumnName("hocki");
            entity.Property(e => e.Magv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("magv");
            entity.Property(e => e.Mamh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mamh");
            entity.Property(e => e.Nienkhoa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nienkhoa");
            entity.Property(e => e.SoSvtoithieu).HasColumnName("soSVtoithieu");
            entity.Property(e => e.Tenloptc)
                .HasMaxLength(30)
                .HasColumnName("tenloptc");
            entity.Property(e => e.Thoikhoabieu)
                .HasMaxLength(30)
                .HasColumnName("thoikhoabieu");

            entity.HasOne(d => d.MagvNavigation).WithMany(p => p.Loptinchis)
                .HasForeignKey(d => d.Magv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("loptinchi_giaovien");

            entity.HasOne(d => d.MamhNavigation).WithMany(p => p.Loptinchis)
                .HasForeignKey(d => d.Mamh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("loptinchi_monhoc");
        });

        modelBuilder.Entity<Monhoc>(entity =>
        {
            entity.HasKey(e => e.Mamh).HasName("PK__monhoc__7A21CB8E232A9D20");

            entity.ToTable("monhoc");

            entity.Property(e => e.Mamh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("mamh");
            entity.Property(e => e.Sotietlythuyet).HasColumnName("sotietlythuyet");
            entity.Property(e => e.Sotietthucthanh).HasColumnName("sotietthucthanh");
            entity.Property(e => e.Sotinchi).HasColumnName("sotinchi");
            entity.Property(e => e.Tenmh)
                .HasMaxLength(30)
                .HasColumnName("tenmh");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.Masv).HasName("PK__sinhvien__7A21767C2C075AE9");

            entity.ToTable("sinhvien");

            entity.Property(e => e.Masv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("masv");
            entity.Property(e => e.Khoa)
                .HasMaxLength(50)
                .HasColumnName("khoa");
            entity.Property(e => e.Lophanhchinh)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("lophanhchinh");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("matkhau");
            entity.Property(e => e.Tensv)
                .HasMaxLength(30)
                .HasColumnName("tensv");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
