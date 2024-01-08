using Microsoft.EntityFrameworkCore;
using TestSignalR.Database.Models;

namespace TestSignalR.Database
{
    public class ApplicationContext : DbContext
    {

        private static ApplicationContext instance;
        public static ApplicationContext Instance
        {
            get => instance ?? (instance = new ApplicationContext());
        }

        public DbSet<Dialog> Dialog { get; set; }
        public DbSet<DialogMessage> DialogMessage { get; set; }
        public DbSet<Friendship> Friendship { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<RequestOfFriendship> RequestOfFriendship { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friendship>()
            .HasOne(f => f.FirstFriend)
            .WithMany(u => u.Friendship)
            .HasForeignKey(f => f.FirstFriendUserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friendship>()
            .HasOne(f => f.SecondFriend)
            .WithMany(u => u.Friendship1)
            .HasForeignKey(f => f.SecondFriendUserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RequestOfFriendship>()
            .HasOne(f => f.SenderUser)
            .WithMany(u => u.RequestOfFriendship)
            .HasForeignKey(f => f.SenderUserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RequestOfFriendship>()
            .HasOne(f => f.ReceiverUser)
            .WithMany(u => u.RequestOfFriendship1)
            .HasForeignKey(f => f.ReceiverUserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DialogMessage>()
            .HasOne(f => f.Message)
            .WithMany(u => u.DialogMessages)
            .HasForeignKey(f => f.MessageId)
            .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=stud-mssql.sttec.yar.ru,38325;Database=user299_db;User Id=user299_db; Password=user299;TrustServerCertificate=True");
        }

    }
}
