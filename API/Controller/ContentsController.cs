using Application.Contents.Command.CreateContents;
using Application.Contents.Command.CreateMedia;
using Application.Contents.DTO;
using Application.Contents.Queries.GetAllContents;
using Application.Contents.Queries.GetContentById;
using Application.Contents.Queries.GetContentMedia;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller;

[Route("api/contents")]
[ApiController]
public class ContentsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateContent([FromForm] CreateContentCommand command)
    {
        int id = await mediator.Send(command);
        return Ok(id);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllContent([FromQuery] GetAllContentQuery query)
    {
        var contents = await mediator.Send(query);
        return Ok(contents);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ContentDto>> GetContentById([FromRoute] int id)
    {
        var contentdto = await mediator.Send(new GetContentByIdQuery(id));
        return Ok(contentdto);
    }

    [HttpPost("/api/content/upload-media")]
    public async Task<IActionResult> UploadChunk([FromForm] UploadMediaCommand createMediaCommand)
    {
        var result = await mediator.Send(createMediaCommand);
        return Ok(result);
    }

    [HttpGet("/api/content/{contentId}/medias")]
    public async Task<IActionResult> GetContentMedia([FromRoute] int contentId)
    {
        var query = new GetContentMediaQuery(contentId);
        var contents = await mediator.Send(query);
        return Ok(contents);
    }
}
