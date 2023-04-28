using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Api.Messages.Queries;

namespace SocialNetwork.Api.Messages;

[ApiController]
[Route("[controller]")]
public class WallController : ControllerBase
{
    private readonly IMessagesRepository _messagesRepository;
    private readonly GetWallByAuthorQueryHandler _getWallByAuthorQueryHandler;

    public WallController(IMessagesRepository messagesRepository)
    {
        _messagesRepository = messagesRepository;
        _getWallByAuthorQueryHandler = new GetWallByAuthorQueryHandler(messagesRepository);
    }

    [HttpGet ("{author}")]
    public async Task<IEnumerable<Message>> Get(string author)
    {
        return await _getWallByAuthorQueryHandler.Handle(author);
    }
}