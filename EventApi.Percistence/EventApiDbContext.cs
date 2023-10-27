using EventApi.Domain.Common;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventApi.Percistence;
public class EventApiDbContext : DbContext
{
    private readonly ITokenService tokenRepository;
    public EventApiDbContext(DbContextOptions<EventApiDbContext> options, ITokenService tokenRepository)
    {
        this.tokenRepository = tokenRepository;
    }
    public DbSet<Activities> Activities { get; set; }
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
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = tokenRepository.GetTokenData().Result.UserName; ;
                        break;

                }
            }
            return base.SaveChangesAsync(cancellationToken);

        }
    
}

