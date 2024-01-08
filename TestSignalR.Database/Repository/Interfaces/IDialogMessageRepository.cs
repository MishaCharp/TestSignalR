using TestSignalR.Database.Models;

namespace TestSignalR.Database.Repository.Interfaces
{
    public interface IDialogMessageRepository
    {
        DialogMessage GetById(int id);
        List<DialogMessage> GetAll();
        void Add(DialogMessage entity);
        void Update(DialogMessage entity);
        void Delete(DialogMessage entity);
    }
}
