namespace TestSignalR.Services
{
    public interface IUserService
    {
        public Dictionary<int, string> connectedUsers { get; set; }
    }
}