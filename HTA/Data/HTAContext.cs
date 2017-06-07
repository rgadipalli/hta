using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HTA.ViewModels;

namespace HTA.Models
{
    public class HTAContext : DbContext
    {
        public HTAContext (DbContextOptions<HTAContext> options)
            : base(options)
        {
        }

        public DbSet<HTA.Models.Devotee> Devotees { get; set; }
        public DbSet<HTA.Models.DevoteeMember> DevoteeMembers { get; set; }
        public DbSet<HTA.Models.ServiceGroup> ServiceGroups { get; set; }
        public DbSet<HTA.Models.Service> Services { get; set; }
        public DbSet<HTA.Models.Booking> Bookings { get; set; }
        public DbSet<HTA.Models.BookingItem> BookingItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<ServiceGroup>().ToTable("tbl_servicegroup");
            modelBuilder.Entity<Service>().ToTable("tbl_service");
            modelBuilder.Entity<Devotee>().ToTable("tbl_devotee");
            modelBuilder.Entity<DevoteeMember>().ToTable("tbl_Devotee_Member");
            modelBuilder.Entity<Booking>().ToTable("tbl_booking");
            modelBuilder.Entity<BookingItem>().ToTable("tbl_bookingitem");
            
        }
        
        
    }
}
