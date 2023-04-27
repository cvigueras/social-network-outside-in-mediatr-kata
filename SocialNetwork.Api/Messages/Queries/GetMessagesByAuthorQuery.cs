using MediatR;

namespace SocialNetwork.Api.Messages.Queries;

public class GetMessagesByAuthorQuery : IRequest<IEnumerable<Message>>
{
    public GetMessagesByAuthorQuery(string? author)
    {
        Author = author;
    }

    public string? Author { get; set; }
}