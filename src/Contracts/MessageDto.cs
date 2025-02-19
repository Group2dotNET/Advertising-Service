using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class MessageDto
    {
        public long Id { get; set; }
        public string SenderId { get; set; }
        public string SenderUserName { get; set; }
        public string SenderName { get; set; }
        public string Text { get; set; }
        public string ReceiverId { get; set; }
        public string ReceiverUserName { get; set; }
        public string ReceiverName { get; set; }
        public DateTime DateSent { get; set; }
        public DateTime? DateRead { get; set; }
        public bool SenderDeleted { get; set; }
        public bool RecipientDeleted { get; set; }
    }
}
