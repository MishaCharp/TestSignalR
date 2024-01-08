using TestSignalR.Database.Models;

namespace TestSignalR.Database.Repository.Interfaces
{
    public interface IRequestOfFriendshipRepository
    {
        RequestOfFriendship GetById(int id);
        List<RequestOfFriendship> GetAll();
        void Add(RequestOfFriendship entity);
        void Update(RequestOfFriendship entity);
        void Delete(RequestOfFriendship entity);
    }
}
