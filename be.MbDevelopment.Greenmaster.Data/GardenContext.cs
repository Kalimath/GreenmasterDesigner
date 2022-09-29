using be.MbDevelopment.Greenmaster.Data.Extensions;
using be.MbDevelopment.Greenmaster.Models.Entities.Arboretum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace be.MbDevelopment.Greenmaster.Data;

public class GardenContext : DbContext
{
    public GardenContext(DbContextOptions<GardenContext> dbContextOptions) : base(dbContextOptions)
    {
        #pragma warning disable EF1001
        Species = new InternalDbSet<Specie>(this, typeof(Specie).ToString());
        #pragma warning restore EF1001
    }

    public override int SaveChanges()
    {
        this.AddAuditInfo();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        this.AddAuditInfo();
        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<Specie> Species { get; set; }
}