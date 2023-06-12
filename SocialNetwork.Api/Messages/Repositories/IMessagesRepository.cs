using SocialNetwork.Api.Messages.Models;

namespace SocialNetwork.Api.Messages.Repositories;

public interface IMessagesRepository
{
    public Task Add(Message message);
    Task<IEnumerable<Message>> GetByAuthor(string? author);
    Task<IEnumerable<Message>> GetByAuthorAndSubscriptions(string user);
}