using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace gestionBiblioteca.Models;

public partial class Bfkxytwn9bgzdtfvozeuContext : DbContext
{
    public Bfkxytwn9bgzdtfvozeuContext()
    {
    }

    public Bfkxytwn9bgzdtfvozeuContext(DbContextOptions<Bfkxytwn9bgzdtfvozeuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Record> Records { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolesPermission> RolesPermissions { get; set; }

    public virtual DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.IdAuthor).HasName("PRIMARY");

            entity.Property(e => e.IdAuthor)
                .HasColumnType("int(11)")
                .HasColumnName("id_author");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.IdBook).HasName("PRIMARY");

            entity.HasIndex(e => e.IdAuthor, "id_author");

            entity.HasIndex(e => e.IdCategory, "id_category");

            entity.Property(e => e.IdBook)
                .HasColumnType("int(11)")
                .HasColumnName("id_book");
            entity.Property(e => e.IdAuthor)
                .HasColumnType("int(11)")
                .HasColumnName("id_author");
            entity.Property(e => e.IdCategory)
                .HasColumnType("int(11)")
                .HasColumnName("id_category");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdAuthor)
                .HasConstraintName("Books_ibfk_1");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Books)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("Books_ibfk_2");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PRIMARY");

            entity.Property(e => e.IdCategory)
                .HasColumnType("int(11)")
                .HasColumnName("id_category");
            entity.Property(e => e.TypeCategory)
                .HasMaxLength(100)
                .HasColumnName("type_category");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PRIMARY");

            entity.HasIndex(e => e.Document, "document").IsUnique();

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.IdClient)
                .HasColumnType("int(11)")
                .HasColumnName("id_client");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Document)
                .HasMaxLength(50)
                .HasColumnName("document");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.TypeDocument)
                .HasMaxLength(50)
                .HasColumnName("type_document");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee).HasName("PRIMARY");

            entity.HasIndex(e => e.Document, "document").IsUnique();

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.Property(e => e.IdEmployee)
                .HasColumnType("int(11)")
                .HasColumnName("id_employee");
            entity.Property(e => e.Document)
                .HasMaxLength(50)
                .HasColumnName("document");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .HasColumnName("phone_number");
            entity.Property(e => e.TypeDocument)
                .HasMaxLength(50)
                .HasColumnName("type_document");
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.IdLoan).HasName("PRIMARY");

            entity.HasIndex(e => e.IdBook, "id_book");

            entity.HasIndex(e => e.IdClient, "id_client");

            entity.Property(e => e.IdLoan)
                .HasColumnType("int(11)")
                .HasColumnName("id_loan");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.IdBook)
                .HasColumnType("int(11)")
                .HasColumnName("id_book");
            entity.Property(e => e.IdClient)
                .HasColumnType("int(11)")
                .HasColumnName("id_client");
            entity.Property(e => e.ReturnDate).HasColumnName("return_date");

            entity.HasOne(d => d.IdBookNavigation).WithMany(p => p.Loans)
                .HasForeignKey(d => d.IdBook)
                .HasConstraintName("Loans_ibfk_1");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Loans)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("Loans_ibfk_2");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.IdPermission).HasName("PRIMARY");

            entity.Property(e => e.IdPermission)
                .HasColumnType("int(11)")
                .HasColumnName("id_permission");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Record>(entity =>
        {
            entity.HasKey(e => e.IdRecord).HasName("PRIMARY");

            entity.HasIndex(e => e.IdLoan, "id_loan");

            entity.Property(e => e.IdRecord)
                .HasColumnType("int(11)")
                .HasColumnName("id_record");
            entity.Property(e => e.IdLoan)
                .HasColumnType("int(11)")
                .HasColumnName("id_loan");
            entity.Property(e => e.Quantity)
                .HasColumnType("int(11)")
                .HasColumnName("quantity");

            entity.HasOne(d => d.IdLoanNavigation).WithMany(p => p.Records)
                .HasForeignKey(d => d.IdLoan)
                .HasConstraintName("Records_ibfk_1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity.Property(e => e.IdRol)
                .HasColumnType("int(11)")
                .HasColumnName("id_rol");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<RolesPermission>(entity =>
        {
            entity.HasKey(e => e.IdRolPermission).HasName("PRIMARY");

            entity.ToTable("Roles_Permissions");

            entity.HasIndex(e => e.IdPermission, "id_permission");

            entity.HasIndex(e => e.IdRol, "id_rol");

            entity.Property(e => e.IdRolPermission)
                .HasColumnType("int(11)")
                .HasColumnName("id_rol_permission");
            entity.Property(e => e.IdPermission)
                .HasColumnType("int(11)")
                .HasColumnName("id_permission");
            entity.Property(e => e.IdRol)
                .HasColumnType("int(11)")
                .HasColumnName("id_rol");

            entity.HasOne(d => d.IdPermissionNavigation).WithMany(p => p.RolesPermissions)
                .HasForeignKey(d => d.IdPermission)
                .HasConstraintName("Roles_Permissions_ibfk_2");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolesPermissions)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("Roles_Permissions_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.IdRol, "id_rol");

            entity.Property(e => e.IdUser)
                .HasColumnType("int(11)")
                .HasColumnName("id_user");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.IdRol)
                .HasColumnType("int(11)")
                .HasColumnName("id_rol");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("Users_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
