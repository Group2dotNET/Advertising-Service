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
        public string Sender { get; set; }
        public string Text { get; set; }
        public string Receiver { get; set; }
        public DateTime DateSent { get; set; }
        public DateTime? DateRead { get; set; }
        public bool SenderDeleted { get; set; }
        public bool RecipientDeleted { get; set; }
    }
}
