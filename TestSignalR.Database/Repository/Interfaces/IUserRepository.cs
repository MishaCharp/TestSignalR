using TestSignalR.Database.Models;

namespace TestSignalR.Database.Repository.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);
        List<User> GetAll();
        void Add(User entity);
        void Update(User entity);
        void Delete(User entity);
    }
}
