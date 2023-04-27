using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Api.Messages;

[ApiController]
[Route("[controller]")]
public class WallController : ControllerBase
{
    private readonly IMessagesRepository _messagesRepository;

    public WallController(IMessagesRepository messagesRepository)
    {
        _messagesRepository = messagesRepository;
    }

    [HttpGet ("{author}")]
    public async Task<IEnumerable<Message>> Get(string author)
    {
        return await _messagesRepository.GetByAuthorAndSubscriptions(author);
    }
}