namespace AdvertisingService.Chat.Interfaces
{
    public interface IUnitOfWork
    {
        IChat ChatRepository { get; }
        IMessage MessageRepository { get; }
    }
}
