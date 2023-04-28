using MediatR;

namespace SocialNetwork.Api.Messages.Queries;

public class GetWallByAuthorQuery : IRequest<IEnumerable<Message>>
{
    public GetWallByAuthorQuery(string user)
    {
        User = user;
    }

    public string User { get; set; }
}