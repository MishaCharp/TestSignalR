using Microsoft.EntityFrameworkCore;
using TestSignalR.Database.Models;
using TestSignalR.Database.Repository.Interfaces;

namespace TestSignalR.Database.Repository.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository { }
    public class RequestOfFriendshipRepository : BaseRepository<RequestOfFriendship>, IRequestOfFriendshipRepository { }
    public class MessageRepository : BaseRepository<Message>, IMessageRepository { }
    public class FriendshipRepository : BaseRepository<Friendship>, IFriendshipRepository { }
    public class DialogMessageRepository : BaseRepository<DialogMessage>, IDialogMessageRepository
    {
        public List<DialogMessage> GetAll() => dbSet.Include(x => x.Message).ToList();
    }
    public class DialogRepository : BaseRepository<Dialog>, IDialogRepository
    {
        public List<Dialog> GetAll() => dbSet.Include(x => x.LastMessage).ToList();
    }
}
