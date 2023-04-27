namespace SocialNetwork.Api.Messages;

public class Message
{
    protected bool Equals(Message other)
    {
        return Timestamp.Equals(other.Timestamp) && Author == other.Author && Post == other.Post;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Message)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Timestamp, Author, Post);
    }

    public DateTime Timestamp { get; set; }
    public string? Author { get; set; }
    public string? Post { get; set; }
}