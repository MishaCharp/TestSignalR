using TestSignalR.Database.Models;

namespace TestSignalR.Database.Repository.Interfaces
{
    public interface IFriendshipRepository
    {
        Friendship GetById(int id);
        List<Friendship> GetAll();
        void Add(Friendship entity);
        void Update(Friendship entity);
        void Delete(Friendship entity);
    }
}
