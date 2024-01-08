namespace TestSignalR.Services
{
    public class UserService : IUserService
    {
        public Dictionary<int, string> connectedUsers { get; set; } = new Dictionary<int, string>();
    }
}
