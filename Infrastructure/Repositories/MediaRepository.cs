using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MediaRepository(AppDbContext dbContext) : IMediaRepository
{
    public async Task<int> Create(Media entity)
    {
        dbContext.Medias.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<List<Media>> GetByContentId(int contentId)
    {
        var mediaList = await dbContext.Medias
             .Where(m => m.ContentId == contentId)
             .ToListAsync();

        return mediaList;
    }

    public async Task<int> Update(Media entity)
    {
        dbContext.Medias.Update(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }
}
