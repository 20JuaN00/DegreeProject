using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsSupport.Core.Mail.Model
{
    public class DTO_SMTP_envio
    {
        //Task<SendEmailResponse> SendEmailAsync(SendEmailRequest request)
        public List<string> Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int Quantity { get; set; }
    }
}
