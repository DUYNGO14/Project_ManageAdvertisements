using Domain.Constants;
using Domain.Entities;

namespace Domain.Repositories;

public interface IContentRepository
{
    Task<int> CreateAsync(Content entity);
    Task<Content> GetByIdAsync(int id);
    Task<int> UpdateAsync(Content entity);
    Task<(List<Content>, int)> GetAllMatchingAsync(string? searchPhrase, int pageSize, int pagenumber, string? sortBy, SortDirection sortDirection);
}
