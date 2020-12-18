using Microsoft.EntityFrameworkCore;
using MutantTest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutantTest.Infra.Repository
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>(adr =>
            {
                adr.HasKey(a => a.Id);
                adr.HasOne(a => a.Geo);                
            });

            modelBuilder.Entity<Company>().HasKey(comp => comp.Id);

            modelBuilder.Entity<Contact>(con =>
            {
                con.HasKey(c => c.Id);
                con.HasOne(c => c.Company).WithMany(c => c.Contacts);
            });

            modelBuilder.Entity<UserInfo>(usr =>
            {
                usr.HasKey(u => u.Id);
                usr.HasIndex(u => u.Email).IsUnique();
                usr.HasOne(u => u.Address).WithOne(a => a.UserInfo).HasForeignKey<Address>(a => a.Id);
                usr.HasOne(u => u.Contact).WithOne(c => c.UserInfo).HasForeignKey<Contact>(c => c.Id);
            });
        }
    }
}
