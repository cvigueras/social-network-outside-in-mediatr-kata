using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Api.Messages.Queries;
using SocialNetwork.Api.Time;

namespace SocialNetwork.Api.Messages;

[ApiController]
[Route("[controller]")]
public class MessagesController : ControllerBase
{
    private readonly IMessagesRepository _messagesRepository;
    private readonly ITime _time;
    private readonly GetMessagesByAuthorQueryHandler _getMessagesByAuthorQueryHandler;

    public MessagesController(IMessagesRepository messagesRepository, ITime time)
    {
        _messagesRepository = messagesRepository;
        _time = time;
        _getMessagesByAuthorQueryHandler = new GetMessagesByAuthorQueryHandler(messagesRepository);
    }

    [HttpGet("{author}")]
    public Task<IEnumerable<Message>> Get(string? author)
    {
        return _getMessagesByAuthorQueryHandler.Handle(new GetMessagesByAuthorQuery(author), default);
    }

    [HttpPost("{author}")]
    public Task Post(string author, MessageDto messageDto)
    {
        _messagesRepository.Add(
            new Message
            {
                Timestamp = _time.Timestamp(),
                Post = messageDto.Post,
                Author = author,
            }
        );
        return Task.CompletedTask;
    }
}