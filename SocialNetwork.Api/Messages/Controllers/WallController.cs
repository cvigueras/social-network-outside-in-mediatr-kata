using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Api.Messages.Models;
using SocialNetwork.Api.Messages.Queries;

namespace SocialNetwork.Api.Messages.Controllers;

[ApiController]
[Route("[controller]")]
public class WallController : ControllerBase
{
    private readonly ISender _sender;

    public WallController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{user}")]
    public async Task<IEnumerable<Message>> Get(string user)
    {
        return await _sender.Send(new GetWallByAuthorQuery(user));
    }
}