using TestSignalR.Database.Models;

namespace TestSignalR.Database.Repository.Interfaces
{
    public interface IMessageRepository
    {
        Message GetById(int id);
        List<Message> GetAll();
        void Add(Message entity);
        void Update(Message entity);
        void Delete(Message entity);
    }
}
