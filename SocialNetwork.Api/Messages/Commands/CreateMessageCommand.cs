using MediatR;
using SocialNetwork.Api.Messages.Models;

namespace SocialNetwork.Api.Messages.Commands;

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