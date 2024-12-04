using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Application.Contents.Command.CreateContents;

public class CreateContentCommand : IRequest<int>
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;

    [FromForm(Name = "MediaDtos")]
    public string MediaDtos { get; set; } = string.Empty;

}
