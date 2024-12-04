using Domain.Constants;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class ContentRepository(AppDbContext dbContext) : IContentRepository
{
    public async Task<int> CreateAsync(Content entity)
    {
        await dbContext.Contents.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<(List<Content>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pageNumber, string? sortBy, SortDirection sortDirection)
    {
        var search = searchPhrase?.ToLower();
        //query
        var baseQuery = dbContext.Contents.Include(r => r.Media)
            .Where(r => search == null ||  r.Status.ToLower().Contains(search));
        //total items
        var totalCount = await baseQuery.CountAsync();
        // sort
        if (sortBy != null)
        {
            var columsSelector = new Dictionary<string, Expression<Func<Content, object>>>
                {
                    {nameof(Content.Title),r=>r.Title},
                    {nameof(Content.CreatedAt),r=>r.CreatedAt},
                };
            var selectedColum = columsSelector[sortBy];
            baseQuery = sortDirection == SortDirection.Ascending
                ? baseQuery.OrderBy(selectedColum)
                : baseQuery.OrderByDescending(selectedColum);
        }
        else
        {
            baseQuery = baseQuery.OrderByDescending(r => r.Id);
        }
        //pagination
        var contents = await baseQuery.Skip(pageSize * (pageNumber - 1))
             .Take(pageSize).ToListAsync();
        return (contents, totalCount);
    }

    public async Task<Content> GetByIdAsync(int id)
    {
        var content = await dbContext.Contents.Include(c => c.Media).FirstOrDefaultAsync(x => x.Id == id);
        return content;
    }

    public async Task<int> UpdateAsync(Content entity)
    {
        dbContext.Contents.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }
}
