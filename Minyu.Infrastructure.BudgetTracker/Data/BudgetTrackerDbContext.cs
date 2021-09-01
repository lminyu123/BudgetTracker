using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Minyu.ApplicationCore.BudgetTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minyu.Infrastructure.BudgetTracker.Data
{
   public class BudgetTrackerDbContext:DbContext
    {
        public BudgetTrackerDbContext(DbContextOptions<BudgetTrackerDbContext> options) : base(options)
        {
            
        }
        //dbset create table
        public DbSet<User> Users { get; set; }
        public DbSet<Income>Incomes { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUsers);
            modelBuilder.Entity<Expenditure>(ConfigureExpenditure);
            modelBuilder.Entity<Income>(ConfigureIncomes);
        }

        private void ConfigureUsers(EntityTypeBuilder<User> builder)
        {
            //USE FLUENT API 
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).HasColumnType("varchar").IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.Property(u => u.Password).HasColumnType("varchar").IsRequired();
            builder.Property(u => u.Password).HasMaxLength(10);
            builder.Property(u => u.FullName).HasColumnType("varchar");
            builder.Property(u => u.FullName).HasMaxLength(50);
            
        }
        private void ConfigureExpenditure(EntityTypeBuilder<Expenditure> builder)
        {
            builder.ToTable("Expenditure");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Amount).HasColumnType("money").IsRequired();
            builder.Property(e => e.Description).HasColumnType("varchar");
            builder.Property(e => e.Description).HasMaxLength(100); 
            builder.Property(e => e.Remarks).HasColumnType("varchar");
            builder.Property(e => e.Remarks).HasMaxLength(500);
            builder.HasOne(e => e.User).WithMany(e =>e.Expenditures).HasForeignKey(e => e.UserId);
        }
        private void ConfigureIncomes(EntityTypeBuilder<Income> builder)
        {
            builder.ToTable("Income");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Amount).HasColumnType("money").IsRequired();
            builder.Property(i => i.Description).HasColumnType("varchar");
            builder.Property(i => i.Description).HasMaxLength(100);
            builder.Property(i => i.Remarks).HasColumnType("varchar");
            builder.Property(i => i.Remarks).HasMaxLength(500);
            // one to many relationship between user and Incomes
            builder.HasOne(i => i.User).WithMany(i => i.Incomes).HasForeignKey(i => i.UserId);
        }
    }
}
