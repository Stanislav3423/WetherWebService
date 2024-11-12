using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WeatherWebService.Api.Models;

public partial class OldWeatherDbContext : DbContext
{
    public OldWeatherDbContext()
    {
    }

    public OldWeatherDbContext(DbContextOptions<OldWeatherDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Observation> Observations { get; set; }

    public virtual DbSet<PrecipitationType> PrecipitationTypes { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
