namespace AdvertisingService.Chat.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUser UserRepository { get; }
        IChat ChatRepository { get; }
        IMessage MessageRepository { get; }

        Task Commit();
    }
}
