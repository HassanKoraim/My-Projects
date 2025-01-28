using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class DoctorsDbContext : DbContext
    {
        public DoctorsDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>().ToTable("Cities");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            //Seed to Countries
            string citiesJson = System.IO.File.ReadAllText("Cities.json");
            List<City> cities = System.Text.Json.JsonSerializer.Deserialize<List<City>>(citiesJson);

            foreach (City city in cities)
                modelBuilder.Entity<City>().HasData(city);


            //Seed to Persons
            string doctorsJson = System.IO.File.ReadAllText("Doctors.json");
            List<Doctor> doctors = System.Text.Json.JsonSerializer.Deserialize<List<Doctor>>(doctorsJson);

            foreach (Doctor doctor in doctors)
                modelBuilder.Entity<Doctor>().HasData(doctor);
        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().ToTable("Cities");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");

            //Seed to Countries
            string citiesJson = System.IO.File.ReadAllText("Cities.json");
            List<City> cities = System.Text.Json.JsonSerializer.Deserialize<List<City>>(citiesJson);

            foreach (City city in cities)
                modelBuilder.Entity<City>().HasData(city);


            //Seed to Persons
            string doctorsJson = System.IO.File.ReadAllText("Doctors.json");
            List<Doctor> doctors = System.Text.Json.JsonSerializer.Deserialize<List<Doctor>>(doctorsJson);

            foreach (Doctor doctor in doctors)
                modelBuilder.Entity<Doctor>().HasData(doctor);
        }*/
    }
}