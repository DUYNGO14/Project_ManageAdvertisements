using Domain.Entities;

namespace Domain.Repositories;

public interface IMediaRepository
{
    public Task<int> Create(Media entity);
    public Task<List<Media>> GetByContentId(int contentId);
    public Task<int> Update(Media entity);
}
