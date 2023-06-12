using MediatR;
using SocialNetwork.Api.Messages.Models;

namespace SocialNetwork.Api.Messages.Queries;

public class GetWallByAuthorQuery : IRequest<IEnumerable<Message>>
{
    public GetWallByAuthorQuery(string user)
    {
        User = user;
    }

    public string User { get; set; }
}