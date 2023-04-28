namespace SocialNetwork.Api.Subscriptions;

public class Subscription
{
    protected bool Equals(Subscription other)
    {
        return User == other.User && Subscriber == other.Subscriber;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Subscription)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(User, Subscriber);
    }

    public string? User { get; set; }
    public string? Subscriber { get; set; }
}