using SocialNetwork.Api.Time;

namespace SocialNetwork.Api.Messages;

public class CreateMessageCommandHandler
{
    private readonly IMessagesRepository _messagesRepository;
    private readonly ITime _time;

    public CreateMessageCommandHandler(IMessagesRepository messagesRepository,
        ITime time)
    {
        _messagesRepository = messagesRepository;
        _time = time;
    }

    public Task Handle(string author, MessageDto messageDto)
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