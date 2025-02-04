namespace AdvertisingService.Chat.Entities
{
    public class Message
    {
        public long Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime DateSent { get; set; }
        public DateTime? DateRead { get; set; }
        public bool SenderDeleted { get; set; } = false;
        public bool ReceiverDeleted { get; set; } = false;
        public long ChatId { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
