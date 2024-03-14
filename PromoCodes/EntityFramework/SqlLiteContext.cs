using Microsoft.EntityFrameworkCore;
using PromoCodes.Models;

namespace PromoCodes.EntityFramework;

public class SqlLiteContext : DbContext
{
    public DbSet<PromoCode> PromoCodes { get; set; }
    public DbSet<PromoCodeChangeHistory> PromoCodeChangeHistory { get; set; }

    public SqlLiteContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=./promocodes.db");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PromoCode>()
            .HasIndex(b => b.Name)
            .IsUnique();
    }
}