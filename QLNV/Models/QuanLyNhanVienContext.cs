using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QLNV.Models;

public partial class QuanLyNhanVienContext : DbContext
{
    public QuanLyNhanVienContext()
    {
    }

    public QuanLyNhanVienContext(DbContextOptions<QuanLyNhanVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LEANHHIEUPC\\HIEU;Initial Catalog=QuanLyNhanVien;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3213E83FF50AE8C1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(100)
                .HasColumnName("department_code");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(255)
                .HasColumnName("department_name");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.NumberOfPersonnels).HasColumnName("number_of_personnels");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83F6D0BB8F9");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(100)
                .HasColumnName("employee_code");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(255)
                .HasColumnName("employee_name");
            entity.Property(e => e.Rank)
                .HasMaxLength(100)
                .HasColumnName("rank");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employees__depar__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
