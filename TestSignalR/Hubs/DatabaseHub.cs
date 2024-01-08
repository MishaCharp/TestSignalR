using Microsoft.AspNetCore.SignalR;
using TestSignalR.Database.Models;
using TestSignalR.Database.Repository.Interfaces;

namespace TestSignalR.Hubs
{
    public class DatabaseHub : Hub
    {
        private IUserRepository _userRepository;
        private IFriendshipRepository _friendshipRepository;
        private IDialogRepository _dialogRepository;

        public DatabaseHub(IUserRepository userRepository, IFriendshipRepository friendshipRepository, IDialogRepository dialogRepository)
        {
            _userRepository = userRepository;
            _friendshipRepository = friendshipRepository;
            _dialogRepository = dialogRepository;

        }

        #region User
        public async Task<List<User>> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            await Clients.Client(Context.ConnectionId).SendAsync("RecieveAllUsers", users.ToString());
            return users;
        }

        public async Task<User> GetUser(int id)
        {
            var user = _userRepository.GetById(id);
            await Clients.Client(Context.ConnectionId).SendAsync("RecieveUser", user);

            return user;
        }
        #endregion

        #region Friendship
        public async Task<List<Friendship>> GetAllFriendship()
        {
            var friendships = _friendshipRepository.GetAll();
            await Clients.Client(Context.ConnectionId).SendAsync("RecieveAllFriendship", friendships);

            return friendships;
        }
        #endregion

        #region Dialog
        public async Task<List<Dialog>> GetAllDialog()
        {

            var dialogs = _dialogRepository.GetAll();
            await Clients.Client(Context.ConnectionId).SendAsync("RecieveAllDialogs", dialogs);

            return dialogs;
        }
        #endregion
    }
}
