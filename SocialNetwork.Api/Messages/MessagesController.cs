using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Api.Time;

namespace SocialNetwork.Api.Messages;

[ApiController]
[Route("[controller]")]
public class MessagesController : ControllerBase
{
    private readonly IMessagesRepository _messagesRepository;
    private readonly ITime _time;

    public MessagesController(IMessagesRepository messagesRepository, ITime time)
    {
        _messagesRepository = messagesRepository;
        _time = time;
    }

    [HttpGet("{author}")]
    public Task<IEnumerable<Message>> Get(string author)
    {
        return _messagesRepository.GetByAuthor(author);
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