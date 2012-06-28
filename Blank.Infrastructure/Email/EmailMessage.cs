using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blank.Infrastructure.Validation.Helpers;
using System.Net.Mail;
using System.IO;

namespace Blank.Infrastructure.Email
{
    public class EmailMessage
    {
        public string Remetente { get; private set; }
        public string Destino {get; private set;}
        public string Assunto {get; private set;}
        public string Corpo {get; private set;}
        public AttachmentCollection Anexos { get; private set; }

        public EmailMessage From(string from)
        {
            if(!from.isValidEmail())
            {
                throw new ArgumentException("Remetente não está no formato correto de e-mail");
            }
            this.Remetente = from;
            return this;
        }

        public EmailMessage To(string to)
        {
            if (!to.isValidEmail())
            {
                throw new ArgumentException("Destino não está no formato correto de e-mail");
            }
            this.Destino = to;
            return this;
        }

        public EmailMessage WithSubject(string subject)
        {
            this.Assunto = subject;
            return this;
        }

        public EmailMessage WithBody(string body)
        {
            this.Corpo = body;
            return this;
        }

        public EmailMessage AddAttachement(byte[] bytes, string fileName)
        {
            this.Anexos.Add(new Attachment(new MemoryStream(bytes), fileName));
            return this;
        }
    }
}
