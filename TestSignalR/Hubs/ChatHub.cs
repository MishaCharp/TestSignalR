using Microsoft.AspNetCore.SignalR;
using TestSignalR.Database.Models;
using TestSignalR.Database.Repository.Interfaces;
using TestSignalR.Database.Repository.Repositories;
using TestSignalR.Services;

namespace TestSignalR.Hubs
{
    public class ChatHub : Hub
    {

        private IMessageRepository _messageRepository;
        private IDialogMessageRepository _dialogMessageRepository;
        private IUserService _userService;

        public ChatHub(IMessageRepository messageRepository, IDialogMessageRepository dialogMessageRepository, IUserService userService)
        {
            _messageRepository = messageRepository;
            _dialogMessageRepository = dialogMessageRepository;
            _userService = userService;
        }

        public async void Login(int userId)
        {
            _userService.connectedUsers.Add(userId, Context.ConnectionId);

            await Clients.All.SendAsync("OnOnline", userId, true);
        }

        public override Task OnConnectedAsync()
        {
            //по идее, мы должны уповестить пользователей, что пользователь зашел в сеть
            //а также сообщить тому, кто зашел, кто в сети
            var onlineUsers = _userService.connectedUsers.Select(x=>x.Key).ToList();
            Clients.Client(Context.ConnectionId).SendAsync("OnFirstOnline", onlineUsers);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var userId = _userService.connectedUsers.FirstOrDefault(x => x.Value == Context.ConnectionId).Key;
            if (userId != 0) _userService.connectedUsers.Remove(userId);

            //уповестить, что вышел из сети
            Clients.All.SendAsync("OnOnline", userId, false);

            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendPrivateMessage(int toUserId, int fromUserId, string message)
        {
            var dateTime = DateTime.Now;
            //Если сейчас подключен - уповещаем
            _userService.connectedUsers.TryGetValue(toUserId, out var connectedId);

                await Clients.Clients(connectedId, Context.ConnectionId).SendAsync("Receive" ,message, fromUserId, dateTime);
            //В любом случае закидываем сообщение в бд

        }

        public async Task<List<Message>> GetMessageHistory(int dialogId)
        {
            var allMessages = _dialogMessageRepository.GetAll();
            var needDialogs = allMessages.Where(x => x.Dialog.Id == dialogId);
            var needMessages = needDialogs.Select(x => x.Message).ToList();

            await Clients.Client(Context.ConnectionId).SendAsync("RecieveMessageHistory", needMessages);

            return needMessages;
        }

    }
}
