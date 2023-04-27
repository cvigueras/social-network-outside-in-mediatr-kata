using MediatR;
using SocialNetwork.Api.Time;

namespace SocialNetwork.Api.Messages;

public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand>
{
    private readonly IMessagesRepository _messagesRepository;
    private readonly ITime _time;

    public CreateMessageCommandHandler(IMessagesRepository messagesRepository,
        ITime time)
    {
        _messagesRepository = messagesRepository;
        _time = time;
    }

    public Task Handle(CreateMessageCommand request, CancellationToken cancellationToken)
    {
        _messagesRepository.Add(
            new Message
            {
                Timestamp = _time.Timestamp(),
                Post = request.MessageDto.Post,
                Author = request.Author,
            }
        );
        return Task.CompletedTask;
    }
}