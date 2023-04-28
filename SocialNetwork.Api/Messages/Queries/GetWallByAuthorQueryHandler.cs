namespace SocialNetwork.Api.Messages.Queries;

public class GetWallByAuthorQueryHandler
{
    private readonly IMessagesRepository _messagesRepository;

    public GetWallByAuthorQueryHandler(IMessagesRepository messagesRepository)
    {
        _messagesRepository = messagesRepository;
    }

    public async Task<IEnumerable<Message>> Handle(string author)
    {
        return await _messagesRepository.GetByAuthorAndSubscriptions(author);
    }
}