using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class MailSettings
    {
        public string SmtpServer { get; set; } = "smtp.gmail.com";
        public int SmtpPort { get; set; } = 587;
        public bool SmtpUseSsl { get; set; } = true;
        public string SmtpUsername { get; set; } = "envio2193@gmail.com";
        public string SmtpPwd { get; set; } = "ybnaemitlebavqlr";


        public string ImapServer { get; set; } = "imap.gmail.com";
        public int ImapPort { get; set; } = 993;
        public bool ImapUseSsl { get; set; } = true;
        public string ImapUsername { get; set; } = "recepcion123.321@gmail.com";
        public string ImapPwd { get; set; } = "eisuqjyfhacwtlvl";

        
    }
}
