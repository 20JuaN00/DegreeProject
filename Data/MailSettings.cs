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


        public string ImapServer { get; set; } = "imap.gmail.com";
        public int ImapPort { get; set; } = 993;
        public bool ImapUseSsl { get; set; } = true;

        public string User { get; set; } = "tuemail@gmail.com";
        public string Pass { get; set; } = "tu_contraseña_app";
    }
}
