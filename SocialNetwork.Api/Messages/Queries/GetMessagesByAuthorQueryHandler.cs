using MediatR;

namespace SocialNetwork.Api.Messages.Queries;

public class GetMessagesByAuthorQueryHandler : IRequestHandler<GetMessagesByAuthorQuery, IEnumerable<Message>>
{
    private readonly IMessagesRepository _messagesRepository;

    public GetMessagesByAuthorQueryHandler(IMessagesRepository messagesRepository)
    {
        _messagesRepository = messagesRepository;
    }

    public Task<IEnumerable<Message>> Handle(GetMessagesByAuthorQuery request, CancellationToken cancellationToken)
    {
        return _messagesRepository.GetByAuthor(request.Author);
    }
}