using EventApi.Application.Contract;
using EventApi.Domain.Entities;
using EventApi.Infrasestructure.Contract;
using EventApi.Percistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(EventApiDbContext context, ITokenService token) : base(context, token)
        {

        }

        public async Task<bool> ExistCompany(string name)
        {
            return await _dbContext.Company.AnyAsync(c => c.Name == name);
        }
        public override Task<Company> AddAsync(Company entity)
        {
            try
            {
                entity.Country = null;
                return base.AddAsync(entity);
            }
            catch (Exception A)
            {

                throw A;
            }

        }
    }
}
