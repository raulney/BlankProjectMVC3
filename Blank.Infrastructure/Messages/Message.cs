using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blank.Infrastructure.Messages
{
    public class Message
    {
        public String Text { get; private set; }
        public MessageType Type { get; private set; }

        public Message Of(MessageType type)
        {
            this.Type = type;
            return this;
        }

        public Message Containing(String text)
        {
            this.Text = text;
            return this;
        }

    }
}
