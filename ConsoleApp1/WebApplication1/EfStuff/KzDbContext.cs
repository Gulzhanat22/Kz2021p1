﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.EfStuff.Model;
using WebApplication1.Models;
using WebApplication1.EfStuff.Model.Firemen;
using WebApplication1.EfStuff.Model.Airport;
using WebApplication1.EfStuff.Model.Television;

namespace WebApplication1.EfStuff
{
    public class KzDbContext : DbContext
    {
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Adress> Adress { get; set; }
        public DbSet<SportComplex> SportComplex { get; set; }
        public DbSet<SportEvent> SportEvent { get; set; }
        public DbSet<Fireman> Firemen { get; set; }
        public DbSet<FireTruck> FireTrucks { get; set; }
        public DbSet<FiremanTeam> FiremanTeams { get; set; }
        public DbSet<FireIncident> FireIncidents { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<TripRoute> TripRoute { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<Ballot> Ballots { get; set; }
        public DbSet<Policeman> Policemen { get; set; }
        public DbSet<PoliceCallHistory> PoliceCallHistory { get; set; }
        public DbSet<Violations> Violations { get; set; }
        public DbSet<PoliceAcademy> PoliceAcademy { get; set; }
        public DbSet<PoliceQuizAnswer> Answers { get; set; }
        public DbSet<PoliceQuizQuestion> Qestions { get; set; }
        public DbSet<PoliceShift> Shifts { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<HCEstablishments> HCEstablishments { get; set; }
        public DbSet<HCWorker> HCWorker { get; set; }

        public DbSet<TvProgramme> TvProgrammes { get; set; }
        public DbSet<TvSchedule> TvSchedules { get; set; }
        public DbSet<TvStaff> TvStaff { get; set; }
        public DbSet<TvProgrammeStaff> TvProgrammeStaff { get; set; }
        public DbSet<TvChannel> TvChannels { get; set; }
        public DbSet<TvCelebrity> TvCelebrities { get; set; }
        public DbSet<TvProgrammeCelebrity> TvProgrammeCelebrities { get; set; }
        public DbSet<CelebrityNews> CelebrityNews { get; set; }
        public DbSet<Translation> Translations { get; set; }

        public KzDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citizen>()
                .HasOne(x => x.House)
                .WithMany(x => x.Citizens);

            modelBuilder.Entity<Citizen>()
               .HasOne(x => x.Fireman)
               .WithOne(x => x.Citizen)
               .HasForeignKey<Fireman>(x => x.CitizenId);
            modelBuilder.Entity<FireTruck>()
                .HasOne(x => x.FiremanTeam)
                .WithOne(x => x.FireTruck);               
            modelBuilder.Entity<Fireman>()
                .HasOne(x => x.FiremanTeam)
                .WithMany(x => x.Firemen);
            modelBuilder.Entity<FireIncident>()
                .HasOne(x => x.FiremanTeam)
                .WithMany(x => x.FireIncidents);

            modelBuilder.Entity<Policeman>()
                .HasOne(c => c.Citizen)
                .WithOne(p => p.Policeman);

            modelBuilder.Entity<Student>()
                       .HasIndex(u => u.Email)
                       .IsUnique();

            modelBuilder.Entity<University>()
                      .HasIndex(u => u.Name)
                      .IsUnique();

            modelBuilder.Entity<School>()
                     .HasIndex(u => u.Name)
                     .IsUnique();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bus>()
                .HasOne(x => x.RoutePlan)
                .WithMany(x => x.Buses);

            modelBuilder.Entity<Order>()
                      .HasIndex(x => x.Name)
                      .IsUnique();

            modelBuilder.Entity<Policeman>()
                .HasMany(v => v.Violations)
                .WithOne(v => v.Policeman)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Citizen>()
                .HasMany(v => v.Violations)
                .WithOne(c => c.Citizen);

            modelBuilder.Entity<PoliceAcademy>()
                .HasOne(c => c.Citizen)
                .WithOne(p => p.PoliceAcademy);

            modelBuilder.Entity<Policeman>()
                .HasMany(pc => pc.PoliceCallHistories)
                .WithOne(p => p.Policeman)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Citizen>()
                .HasMany(pc => pc.PoliceCallHistories)
                .WithOne(c => c.Citizen);
            
            modelBuilder.Entity<Citizen>()
                .HasMany(pc => pc.Candidates)
                .WithOne(c => c.Citizen);

            modelBuilder.Entity<Candidate>()
                .HasOne(c => c.Election)
                .WithMany(b => b.Candidates)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Election>()
                .HasOne(c => c.Candidate)
                .WithMany(b => b.Elections)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Ballot>()
                .HasOne(c => c.Citizen)
                .WithMany(b => b.Ballots);

            modelBuilder.Entity<Citizen>()
                .HasOne(c => c.Ballot)
                .WithMany(b => b.Citizens);


            modelBuilder.Entity<Ballot>()
                .HasOne(c => c.Election)
                .WithMany(b => b.Ballots)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ballot>()
                .HasOne(c => c.Candidate)
                .WithMany(b => b.Ballots)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Candidate>()
                .HasOne(b => b.Ballot)
                .WithMany(c => c.Candidates);

            modelBuilder.Entity<PoliceShift>()
                .HasOne(p => p.Policeman)
                .WithMany(s => s.Shifts);

            modelBuilder.Entity<Passenger>()
                .HasMany(p => p.Flights)
                .WithMany(f => f.Passengers);
            modelBuilder.Entity<Flight>()
                .HasMany(f => f.Passengers)
                .WithMany(p => p.Flights);
            modelBuilder.Entity<Passenger>()
                .HasOne(p => p.Citizen)
                .WithOne(c => c.Passenger)
                .HasForeignKey<Passenger>(p => p.CitizenId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HCWorker>()
                .HasOne(x => x.Facility)
                .WithMany(x => x.Workers)
                .HasForeignKey(x => x.FacilityId);

            modelBuilder.Entity<Citizen>()
                .HasOne(x => x.HCWorker)
                .WithOne(x => x.Citizen)
                .HasForeignKey<HCWorker>(x => x.CitizenId);

            modelBuilder.Entity<TvProgramme>()
               .HasMany(x => x.Schedules)
               .WithOne(x => x.Programme);

            modelBuilder.Entity<TvStaff>()
               .HasOne(x => x.Citizen)
               .WithOne(x => x.TvStaff);

            modelBuilder.Entity<TvProgrammeStaff>()
               .HasOne(x => x.Staff)
               .WithMany(x => x.Programme);

            modelBuilder.Entity<TvProgrammeStaff>()
              .HasOne(x => x.Programme)
              .WithMany(x => x.Staff);

            modelBuilder.Entity<TvProgramme>()
                .HasOne(x => x.Channel)
                .WithMany(x => x.Programmes);

            modelBuilder.Entity<TvStaff>()
                .HasOne(x => x.Channel)
                .WithMany(x => x.Staff);
            modelBuilder.Entity<TvCelebrity>()
               .HasOne(x => x.Citizen)
               .WithOne(x => x.TvCelebrity);

            modelBuilder.Entity<TvProgrammeCelebrity>()
               .HasOne(x => x.Celebrity)
               .WithMany(x => x.Programme);

            modelBuilder.Entity<TvProgrammeCelebrity>()
              .HasOne(x => x.Programme)
              .WithMany(x => x.Celebrities);

            modelBuilder.Entity<CelebrityNews>()
              .HasOne(x => x.Celebrity)
              .WithMany(x => x.CelebrityNews);

            modelBuilder.Entity<CelebrityNews>()
              .HasOne(x => x.Programme)
              .WithMany(x => x.CelebrityNews);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

    }
}