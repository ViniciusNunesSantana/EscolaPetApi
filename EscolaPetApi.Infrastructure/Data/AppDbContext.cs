using EscolaPetApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EscolaPetApi.Infrastructure.Data;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<EscolaPet> EscolaPets { get; set; }
    public DbSet<Tutor> Tutores { get; set; }
    public DbSet<Pet> Pets { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EscolaPet>() //Escola Pet
          .HasMany(e => e.Tutores)
          .WithOne(t => t.EscolaPet)
          .HasForeignKey(t => t.EscolaId)
          .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Tutor>() // Tutor
        .HasMany(t => t.Pets)
        .WithOne(p => p.Tutor)
        .HasForeignKey(p => p.TutorId)
        .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}
