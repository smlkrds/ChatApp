using SignalRChat.Dtos;

namespace SignalRChat.Services.Interfaces
{
    public interface IMessageService
    {
        Task InsertMessage(MessageDto message);
    }
}
