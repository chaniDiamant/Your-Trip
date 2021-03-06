﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YourTrip.Models;

namespace YourTrip.Models
{
    public class YourTripContext : DbContext
    {
        public YourTripContext (DbContextOptions<YourTripContext> options)
            : base(options)
        {
        }

        public DbSet<YourTrip.Models.Customer> Customer { get; set; }

        public DbSet<YourTrip.Models.PlaneDepartment> PlaneDepartment { get; set; }

        public DbSet<YourTrip.Models.Department> Department { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaneDepartment>()
                .HasKey(t => new { t.PlaneId, t.DepartmentName });

            modelBuilder.Entity<PlaneDepartment>()
                .HasOne(pt => pt.Plane)
                .WithMany(p => p.PlaneDepartments)
                .HasForeignKey(pt => pt.PlaneId);

            modelBuilder.Entity<PlaneDepartment>()
                .HasOne(pt => pt.Department)
                .WithMany(t => t.PlaneDepartments)
                .HasForeignKey(pt => pt.DepartmentName);

        }

        public DbSet<YourTrip.Models.Flight> Flight { get; set; }

        public DbSet<YourTrip.Models.Destination> Destination { get; set; }

        public DbSet<YourTrip.Models.Order> Order { get; set; }

        public DbSet<YourTrip.Models.Plane> Plane { get; set; }

        public DbSet<YourTrip.Models.Seat> Seat { get; set; }

        public DbSet<YourTrip.Models.Terminal> Terminal { get; set; }

        public DbSet<YourTrip.Models.Ticket> Ticket { get; set; }
    }
}
