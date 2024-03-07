

using Informatics.MauiDbClientTest.Models;
using Microsoft.EntityFrameworkCore;


namespace Informatics.MauiDbClientTest.Contexts;
public class UniversityContext : DbContext
{
public DbSet<Pet> Pets { get; set; }
public DbSet<Owner> Owners { get; set; }
public UniversityContext(DbContextOptions<UniversityContext> options) : base(options) { }
}