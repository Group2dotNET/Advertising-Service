using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvertisingService.Chat.Entities
{
    public class Chat
    {
        public long Id { get; set; }
        public required string SenderId { get; set; }
        [ForeignKey("SenderId")]
        public virtual User Sender { get; set; }
        public required string ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public virtual User Receiver { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Muted { get; set; } = false;
        public virtual List<Message> Messages { get; set; }
    }
}
