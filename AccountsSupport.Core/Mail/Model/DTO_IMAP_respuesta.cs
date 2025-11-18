using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsSupport.Core.Mail.Model
{
    public class DTO_IMAP_respuesta
    {
        public bool Success { get; set; }
        public List<DTO_MAIL_estructure> Emails { get; set; } = new List<DTO_MAIL_estructure>();
        public string Message { get; set; }
        public string Error { get; set; }
    }
}
