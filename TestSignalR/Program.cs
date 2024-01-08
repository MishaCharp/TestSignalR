using TestSignalR.Database.Repository.Interfaces;
using TestSignalR.Database.Repository.Repositories;
using TestSignalR.Hubs;
using TestSignalR.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IRequestOfFriendshipRepository, RequestOfFriendshipRepository>();
builder.Services.AddSingleton<IMessageRepository, MessageRepository>();
builder.Services.AddSingleton<IFriendshipRepository, FriendshipRepository>();
builder.Services.AddSingleton<IDialogRepository, DialogRepository>();
builder.Services.AddSingleton<IDialogMessageRepository, DialogMessageRepository>();

builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapHub<ChatHub>("/chat");
app.MapHub<DatabaseHub>("/db");

app.Run();
