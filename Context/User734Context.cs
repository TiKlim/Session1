using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TheSchoolsClients.Models;

namespace TheSchoolsClients.Context;

public partial class User734Context : DbContext
{
    public User734Context()
    {
    }

    public User734Context(DbContextOptions<User734Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AttachedFile> AttachedFiles { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TagList> TagLists { get; set; }

    public virtual DbSet<VisitingList> VisitingLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.2.159;Database=user734;Username=user734;password=13245");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AttachedFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("attached_files_pk");

            entity.ToTable("attached_files");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdClients).HasColumnName("id_clients");
            entity.Property(e => e.IdFiles).HasColumnName("id_files");

            entity.HasOne(d => d.IdClientsNavigation).WithMany(p => p.AttachedFiles)
                .HasForeignKey(d => d.IdClients)
                .HasConstraintName("attached_files_client_fk");

            entity.HasOne(d => d.IdFilesNavigation).WithMany(p => p.AttachedFiles)
                .HasForeignKey(d => d.IdFiles)
                .HasConstraintName("attached_files_files_fk");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("client_pk");

            entity.ToTable("client");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.DateOfRegistration).HasColumnName("date_of_registration");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.IdGender).HasColumnName("id_gender");
            entity.Property(e => e.IdTag).HasColumnName("id_tag");
            entity.Property(e => e.Image)
                .HasColumnType("character varying")
                .HasColumnName("image");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnName("middle_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdGender)
                .HasConstraintName("client_gender_fk");
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("files_pk");

            entity.ToTable("files");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.File1)
                .HasColumnType("character varying")
                .HasColumnName("file");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("пол_pk");

            entity.ToTable("gender");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tag_pk");

            entity.ToTable("tag");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TagName)
                .HasColumnType("character varying")
                .HasColumnName("tag_name");
        });

        modelBuilder.Entity<TagList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tag_list_pk");

            entity.ToTable("tag_list");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdTag).HasColumnName("id_tag");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.TagLists)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("tag_list_client_fk");

            entity.HasOne(d => d.IdTagNavigation).WithMany(p => p.TagLists)
                .HasForeignKey(d => d.IdTag)
                .HasConstraintName("tag_list_tag_fk");
        });

        modelBuilder.Entity<VisitingList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visitinglist_pk");

            entity.ToTable("visiting_list");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.Time).HasColumnName("time");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.VisitingLists)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("visitinglist_client_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
