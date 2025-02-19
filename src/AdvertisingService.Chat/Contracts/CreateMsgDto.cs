namespace AdvertisingService.Chat.Contracts
{
    public record CreateMsgDto(string SenderId, string Text, string ReceiverId);
}
