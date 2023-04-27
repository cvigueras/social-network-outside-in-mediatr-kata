namespace SocialNetwork.Api.Time
{
    public class Time : ITime
    {
        public DateTime Timestamp()
        {
            return DateTime.Now;
        }
    }
}