using TestSignalR.Database.Models;

namespace TestSignalR.Database.Repository.Interfaces
{
    public interface IDialogRepository
    {
        Dialog GetById(int id);
        List<Dialog> GetAll();
        void Add(Dialog entity);
        void Update(Dialog entity);
        void Delete(Dialog entity);
    }
}
