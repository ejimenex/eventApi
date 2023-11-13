using EventApi.Domain.Common;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence;
public class EventApiDbContext : DbContext
{
    private readonly ITokenService tokenRepository;
    public EventApiDbContext(DbContextOptions<EventApiDbContext> options, ITokenService tokenRepository) : base(options)
    {
        this.tokenRepository = tokenRepository;
    }
    public DbSet<Activities> Activities { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<Company> Company { get; set; }
    public DbSet<Permission> Permission { get; set; }
    public DbSet<PermissionUser> PermissionUser { get; set; }
    public DbSet<SubContractors> SubContractors { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EventApiDbContext).Assembly);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {

        foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.IsDeleted = false;
                    entry.Entity.CreatedBy = tokenRepository.GetTokenData().Result.UserName;
                    entry.Entity.TenantId = tokenRepository.GetTokenData().Result.TenantId;
                    entry.Entity.CreatedDate = DateTime.Now;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = tokenRepository.GetTokenData().Result.UserName;
                    break;

            }
        }
        return base.SaveChangesAsync(cancellationToken);

    }

}

