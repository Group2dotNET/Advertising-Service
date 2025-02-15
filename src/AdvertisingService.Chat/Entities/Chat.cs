namespace AdvertisingService.Chat.Entities
{
    public class Chat
    {
        public long Id { get; set; }
        public required string Sender { get; set; }
        public required string Receiver { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Muted { get; set; } = false;
        public virtual List<Message> Messages { get; set; }
    }
}
