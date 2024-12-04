using Application.Contents.DTO;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Application.Contents.Command.CreateContents;

public class CreateContentCommandHandler(
    ILogger<CreateContentCommandHandler> logger,
    IMapper mapper,
    IMediaRepository mediaRepository,
    IContentRepository contentRepository
    ) : IRequestHandler<CreateContentCommand, int>
{
    public async Task<int> Handle(CreateContentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var MediaDtos = JsonSerializer.Deserialize<List<CreateMediaDto>>(request.MediaDtos, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
            if (MediaDtos is null || MediaDtos.Count <= 0)
            {
                throw new Exception("Invalid Media Meta data");
            }
            var content = mapper.Map<Content>(request);
            content.CreatedAt = DateTime.Now;

            var id = await contentRepository.CreateAsync(content);

            foreach (var mediaDto in MediaDtos)
            {
                var media = mapper.Map<Media>(mediaDto);
                media.ContentId = id;
                await mediaRepository.Create(media);
            }
            return id;
        }
        catch (Exception ex) 
        {
            // Ghi log lỗi và trả về thông tin chi tiết
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}
