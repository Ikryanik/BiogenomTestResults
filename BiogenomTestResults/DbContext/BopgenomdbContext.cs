using System;
using System.Collections.Generic;
using BiogenomTestResults.Models;
using Microsoft.EntityFrameworkCore;

namespace BiogenomTestResults.DbContext;

public partial class BopgenomdbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public BopgenomdbContext()
    {
    }

    public BopgenomdbContext(DbContextOptions<BopgenomdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FoodInfluence> FoodInfluences { get; set; }

    public virtual DbSet<FoodSupplement> FoodSupplements { get; set; }

    public virtual DbSet<FoodSupplementImage> FoodSupplementImages { get; set; }

    public virtual DbSet<FoodSupplementInfluence> FoodSupplementInfluences { get; set; }

    public virtual DbSet<HealthIndicator> HealthIndicators { get; set; }

    public virtual DbSet<HealthIndicatorResult> HealthIndicatorResults { get; set; }

    public virtual DbSet<NecessaryFood> NecessaryFoods { get; set; }

    public virtual DbSet<NecessaryFoodSupplement> NecessaryFoodSupplements { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<TestResult> TestResults { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=1578;Database=bopgenomdb;Username=biogenomuser;Password=biogenompassword");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("food_pk");

            entity.ToTable("food");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<FoodInfluence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("food_influence_pk");

            entity.ToTable("food_influence");

            entity.HasIndex(e => new { e.FoodId, e.HealthIndicatorId }, "food_influence_un").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.FoodId).HasColumnName("food_id");
            entity.Property(e => e.HealthIndicatorId).HasColumnName("health_indicator_id");
            entity.Property(e => e.SubstanceAmount).HasColumnName("substance_amount");

            entity.HasOne(d => d.Food).WithMany(p => p.FoodInfluences)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("food_influence_fk");

            entity.HasOne(d => d.HealthIndicator).WithMany(p => p.FoodInfluences)
                .HasForeignKey(d => d.HealthIndicatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("food_influence_fk2");
        });

        modelBuilder.Entity<FoodSupplement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("food_supplement_pk");

            entity.ToTable("food_supplement");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<FoodSupplementImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("food_supplement_image_pk");

            entity.ToTable("food_supplement_image");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.FoodSupplementId).HasColumnName("food_supplement_id");
            entity.Property(e => e.Url)
                .HasColumnType("character varying")
                .HasColumnName("url");

            entity.HasOne(d => d.FoodSupplement).WithMany(p => p.FoodSupplementImages)
                .HasForeignKey(d => d.FoodSupplementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("food_supplement_image_fk");
        });

        modelBuilder.Entity<FoodSupplementInfluence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("food_supplement_influence_pk");

            entity.ToTable("food_supplement_influence");

            entity.HasIndex(e => new { e.FoodSupplementId, e.HealthIndicatorId }, "food_supplement_influence_un").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.FoodSupplementId).HasColumnName("food_supplement_id");
            entity.Property(e => e.HealthIndicatorId).HasColumnName("health_indicator_id");
            entity.Property(e => e.SubstanceAmount).HasColumnName("substance_amount");

            entity.HasOne(d => d.FoodSupplement).WithMany(p => p.FoodSupplementInfluences)
                .HasForeignKey(d => d.FoodSupplementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("food_supplement_influence_fk");

            entity.HasOne(d => d.HealthIndicator).WithMany(p => p.FoodSupplementInfluences)
                .HasForeignKey(d => d.HealthIndicatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("food_supplement_influence_fk_1");
        });

        modelBuilder.Entity<HealthIndicator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("health_indicator_pk");

            entity.ToTable("health_indicator");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Norm).HasColumnName("norm");
        });

        modelBuilder.Entity<HealthIndicatorResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("health_indicator_result_pk");

            entity.ToTable("health_indicator_result");

            entity.HasIndex(e => new { e.TestResultId, e.HealthIndicatorid }, "health_indicator_result_un").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.HealthIndicatorid).HasColumnName("health_indicatorid");
            entity.Property(e => e.Result).HasColumnName("result");
            entity.Property(e => e.TestResultId).HasColumnName("test_result_id");

            entity.HasOne(d => d.HealthIndicator).WithMany(p => p.HealthIndicatorResults)
                .HasForeignKey(d => d.HealthIndicatorid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("health_indicator_result_fk_1");

            entity.HasOne(d => d.TestResult).WithMany(p => p.HealthIndicatorResults)
                .HasForeignKey(d => d.TestResultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("health_indicator_result_fk");
        });

        modelBuilder.Entity<NecessaryFood>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("necessary_food_pk");

            entity.ToTable("necessary_food");

            entity.HasIndex(e => new { e.TestResultId, e.FoodId }, "necessary_food_un").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.FoodId).HasColumnName("food_id");
            entity.Property(e => e.TestResultId).HasColumnName("test_result_id");

            entity.HasOne(d => d.Food).WithMany(p => p.NecessaryFoods)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("necessary_food_fk_1");

            entity.HasOne(d => d.TestResult).WithMany(p => p.NecessaryFoods)
                .HasForeignKey(d => d.TestResultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("necessary_food_fk");
        });

        modelBuilder.Entity<NecessaryFoodSupplement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("necessary_food_supplement_pk");

            entity.ToTable("necessary_food_supplement");

            entity.HasIndex(e => new { e.TestResultId, e.FoodSupplementId }, "necessary_food_supplement_un").IsUnique();

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.FoodSupplementId).HasColumnName("food_supplement_id");
            entity.Property(e => e.TestResultId).HasColumnName("test_result_id");

            entity.HasOne(d => d.FoodSupplement).WithMany(p => p.NecessaryFoodSupplements)
                .HasForeignKey(d => d.FoodSupplementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("necessary_food_supplement_fk_1");

            entity.HasOne(d => d.TestResult).WithMany(p => p.NecessaryFoodSupplements)
                .HasForeignKey(d => d.TestResultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("necessary_food_supplement_fk");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("test_pk");

            entity.ToTable("test");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<TestResult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("test_result_pk");

            entity.ToTable("test_result");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.TestId).HasColumnName("test_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Test).WithMany(p => p.TestResults)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("test_result_fk");

            entity.HasOne(d => d.User).WithMany(p => p.TestResults)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("test_result_fk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pk");

            entity.ToTable("user");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
