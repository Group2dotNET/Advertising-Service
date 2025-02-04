namespace AdvertisingService.Chat.Entities
{
    public class Chat
    {
        public long Id { get; set; }
        public string Sender { get; set; } = string.Empty;
        public string Receiver { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public bool Muted { get; set; } = false;
        public virtual List<Message> Messages { get; set; }
    }
}
