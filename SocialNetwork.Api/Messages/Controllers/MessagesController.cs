using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Api.Messages.Commands;
using SocialNetwork.Api.Messages.Models;
using SocialNetwork.Api.Messages.Queries;

namespace SocialNetwork.Api.Messages.Controllers;

[ApiController]
[Route("[controller]")]
public class MessagesController : ControllerBase
{
    private readonly ISender _sender;

    public MessagesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{author}")]
    public Task<IEnumerable<Message>> Get(string? author)
    {
        return _sender.Send(new GetMessagesByAuthorQuery(author));
    }

    [HttpPost("{author}")]
    public Task Post(string author, MessageDto messageDto)
    {
        return _sender.Send(new CreateMessageCommand(messageDto, author));
    }
}