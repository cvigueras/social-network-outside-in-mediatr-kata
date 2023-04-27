using MediatR;

namespace SocialNetwork.Api.Messages;

public class CreateMessageCommand : IRequest
{
    public CreateMessageCommand(MessageDto messageDto, string author)
    {
        MessageDto = messageDto;
        Author = author;
    }

    public string Author { get; set; }
    public MessageDto MessageDto { get; set; }
}