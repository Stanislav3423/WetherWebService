using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WeatherWebService.Api.Models;

public partial class WeatherDbContext : DbContext
{
    public WeatherDbContext()
    {
    }

    public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Observation> Observations { get; set; }

    public virtual DbSet<PrecipitationType> PrecipitationTypes { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WeatherStation> WeatherStations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-QCLUDR4;Initial Catalog=weather_db;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cities__3213E83FDBFBDEF4");

            entity.ToTable("cities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Latitude)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("longitude");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.RegionId).HasColumnName("region_id");

            entity.HasOne(d => d.Region).WithMany(p => p.Cities)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__cities__region_i__398D8EEE");
        });

        modelBuilder.Entity<Observation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__observat__3213E83F8D9ECA23");

            entity.ToTable("observations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Humidity)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("humidity");
            entity.Property(e => e.ObservationDate)
                .HasColumnType("datetime")
                .HasColumnName("observation_date");
            entity.Property(e => e.Precipitation)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("precipitation");
            entity.Property(e => e.PrecipitationTypeId).HasColumnName("precipitation_type_id");
            entity.Property(e => e.StationId).HasColumnName("station_id");
            entity.Property(e => e.Temperature)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("temperature");
            entity.Property(e => e.WindSpeed)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("wind_speed");

            entity.HasOne(d => d.PrecipitationType).WithMany(p => p.Observations)
                .HasForeignKey(d => d.PrecipitationTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__observati__preci__47DBAE45");

            entity.HasOne(d => d.Station).WithMany(p => p.Observations)
                .HasForeignKey(d => d.StationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__observati__stati__46E78A0C");
        });

        modelBuilder.Entity<PrecipitationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__precipit__3213E83F7BFC1739");

            entity.ToTable("precipitation_types");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.TypeName)
                .HasMaxLength(45)
                .HasColumnName("type_name");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__regions__3213E83F9DACBC9D");

            entity.ToTable("regions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country)
                .HasMaxLength(45)
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__seasons__3213E83FB0B460DB");

            entity.ToTable("seasons");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.RegionId).HasColumnName("region_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.Region).WithMany(p => p.Seasons)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__seasons__region___3F466844");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F4322EB6C");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RegionId).HasColumnName("region_id");
            entity.Property(e => e.Role)
                .HasMaxLength(45)
                .HasColumnName("role");
            entity.Property(e => e.Username)
                .HasMaxLength(45)
                .HasColumnName("username");

            entity.HasOne(d => d.Region).WithMany(p => p.Users)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__users__region_id__4222D4EF");
        });

        modelBuilder.Entity<WeatherStation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__weather___3213E83FD8E525F1");

            entity.ToTable("weather_stations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.InstallationDate).HasColumnName("installation_date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.City).WithMany(p => p.WeatherStations)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__weather_s__city___3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
