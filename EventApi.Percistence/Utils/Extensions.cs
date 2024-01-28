using Microsoft.EntityFrameworkCore;

namespace EventApi.Percistence.Utils
{
    public static class ExtensionsList<T>
    {

        public async static Task<List<T>> ToPagination(IQueryable<T> list, int page)
        {

            var result = await list.Skip((page - 1) * ContantsApi.MAX_SIZE)
                 .Take(ContantsApi.MAX_SIZE)
                 // .AsNoTracking()
                 .ToListAsync();
            return result;
        }
    }

}
