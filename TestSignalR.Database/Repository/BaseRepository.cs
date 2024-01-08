using Microsoft.EntityFrameworkCore;

namespace TestSignalR.Database.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : NativeEntity
    {
        internal ApplicationContext context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository()
        {
            context = ApplicationContext.Instance;
            dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public List<TEntity> GetAll() => dbSet.ToList();

        public TEntity GetById(int id) => dbSet.Find(id);

        public void Update(TEntity entity)
        {
            var item = dbSet.Find(entity.Id);
            item.UpdateProperties(entity);
            context.SaveChanges();
        }
    }
}
