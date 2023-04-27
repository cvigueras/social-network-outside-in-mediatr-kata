using MediatR;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Api.Messages.Commands;
using SocialNetwork.Api.Messages.Queries;

namespace SocialNetwork.Api.Messages;

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
        return _sender.Send(new GetMessagesByAuthorQuery(author), default);
    }

    [HttpPost("{author}")]
    public Task Post(string author, MessageDto messageDto)
    {
        return _sender.Send(new CreateMessageCommand(messageDto, author), default);
    }
}