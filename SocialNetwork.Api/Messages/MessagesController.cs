using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Api.Messages.Commands;
using SocialNetwork.Api.Messages.Queries;
using SocialNetwork.Api.Time;

namespace SocialNetwork.Api.Messages;

[ApiController]
[Route("[controller]")]
public class MessagesController : ControllerBase
{
    private readonly GetMessagesByAuthorQueryHandler _getMessagesByAuthorQueryHandler;
    private readonly CreateMessageCommandHandler _createMessageCommandHandler;

    public MessagesController(IMessagesRepository messagesRepository, ITime time)
    {
        _getMessagesByAuthorQueryHandler = new GetMessagesByAuthorQueryHandler(messagesRepository);
        _createMessageCommandHandler = new CreateMessageCommandHandler(messagesRepository, time);
    }

    [HttpGet("{author}")]
    public Task<IEnumerable<Message>> Get(string? author)
    {
        return _getMessagesByAuthorQueryHandler.Handle(new GetMessagesByAuthorQuery(author), default);
    }

    [HttpPost("{author}")]
    public Task Post(string author, MessageDto messageDto)
    {
        return _createMessageCommandHandler.Handle(new CreateMessageCommand(messageDto, author), default);
    }
}