using MediatR;
using SocialNetwork.Api.Messages.Models;
using SocialNetwork.Api.Messages.Repositories;

namespace SocialNetwork.Api.Messages.Queries;

public class GetWallByAuthorQueryHandler : IRequestHandler<GetWallByAuthorQuery, IEnumerable<Message>>
{
    private readonly IMessagesRepository _messagesRepository;

    public GetWallByAuthorQueryHandler(IMessagesRepository messagesRepository)
    {
        _messagesRepository = messagesRepository;
    }


    public Task<IEnumerable<Message>> Handle(GetWallByAuthorQuery request, CancellationToken cancellationToken)
    {
        return _messagesRepository.GetByAuthorAndSubscriptions(request.User);
    }
}