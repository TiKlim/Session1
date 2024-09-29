using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TheSchoolsClients.Models;

namespace TheSchoolsClients.Context;

public partial class KlimBaseContext : DbContext
{
    public KlimBaseContext()
    {
    }

    public KlimBaseContext(DbContextOptions<KlimBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Agenttype> Agenttypes { get; set; }

    public virtual DbSet<AttachedFile> AttachedFiles { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Priority> Priorities { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TagList> TagLists { get; set; }

    public virtual DbSet<VisitingList> VisitingLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.110.53.87; Database=klim_base; Username=klim; Port=5522; Password=nissan");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("agent_pk");

            entity.ToTable("agent");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Adress)
                .HasColumnType("character varying")
                .HasColumnName("adress");
            entity.Property(e => e.Countofrealizationyear).HasColumnName("countofrealizationyear");
            entity.Property(e => e.Directorname)
                .HasColumnType("character varying")
                .HasColumnName("directorname");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Inn)
                .HasColumnType("character varying")
                .HasColumnName("inn");
            entity.Property(e => e.Kpp).HasColumnName("kpp");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Prioritet).HasColumnName("prioritet");
            entity.Property(e => e.Sale).HasColumnName("sale");
            entity.Property(e => e.Typeofagent).HasColumnName("typeofagent");

            entity.HasOne(d => d.PrioritetNavigation).WithMany(p => p.Agents)
                .HasForeignKey(d => d.Prioritet)
                .HasConstraintName("agent_priority_fk");

            entity.HasOne(d => d.TypeofagentNavigation).WithMany(p => p.Agents)
                .HasForeignKey(d => d.Typeofagent)
                .HasConstraintName("agent_agenttype_fk");
        });

        modelBuilder.Entity<Agenttype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("agenttype_pk");

            entity.ToTable("agenttype");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nametype)
                .HasColumnType("character varying")
                .HasColumnName("nametype");
        });

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
            entity.Property(e => e.DateOfRegistration)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_of_registration");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
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

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Gender)
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
            entity.HasKey(e => e.Id).HasName("gender_pk");

            entity.ToTable("gender");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Priority>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("priority_pk");

            entity.ToTable("priority");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Numberprioritet).HasColumnName("numberprioritet");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tag_pk");

            entity.ToTable("tag");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.TagColor)
                .HasColumnType("character varying")
                .HasColumnName("tag_color");
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
