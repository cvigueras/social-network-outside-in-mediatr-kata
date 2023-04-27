using System.Data.SQLite;
using Dapper;

namespace SocialNetwork.Api.Messages
{
    public class MessageRepository : IMessagesRepository
    {
        private readonly SQLiteConnection _connection;

        public MessageRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }

        public async Task Add(Message message)
        {
            await _connection.ExecuteAsync($"INSERT INTO Messages(Author, Post, Timestamp) VALUES('{message.Author}', '{message.Post}', '{message.Timestamp:O}')");
        }

        public Task<IEnumerable<Message>> GetByAuthor(string author)
        {
            return _connection.QueryAsync<Message>($"SELECT Author, Post, Timestamp FROM Messages WHERE Author = '{author}' ORDER BY Timestamp DESC");
        }

        public async Task<IEnumerable<Message>> GetByAuthorAndSubscriptions(string user)
        {
            var messagesSubscription = await _connection.QueryAsync<Message>($"SELECT M.Author, M.Post, M.Timestamp FROM Messages M JOIN Subscriptions S ON M.Author = S.User WHERE S.Subscriber = '{user}'");

            var ownMessages = await _connection.QueryAsync<Message>($"SELECT Author, Post, Timestamp FROM Messages WHERE Author = '{user}'");

            return messagesSubscription.Concat(ownMessages).OrderByDescending(message => message.Timestamp);
        }
    }
}
