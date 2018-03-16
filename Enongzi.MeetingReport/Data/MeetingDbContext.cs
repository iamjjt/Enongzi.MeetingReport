using Enongzi.MeetingReport.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enongzi.MeetingReport.Data
{
    public class MeetingDbContext:IdentityDbContext<Manager,ManagerRole,int>
    {
        public MeetingDbContext(DbContextOptions<MeetingDbContext> options):base(options)
        {

        }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meeting>().ToTable("meeting").HasKey(m => m.Id);
            modelBuilder.Entity<Subject>().ToTable("subject").HasKey(m => m.Id);
            modelBuilder.Entity<Teacher>().ToTable("teacher").HasKey(m => m.Id);
            modelBuilder.Entity<User>().ToTable("user").HasKey(m => m.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
