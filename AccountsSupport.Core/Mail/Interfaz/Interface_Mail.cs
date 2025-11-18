using AccountsSupport.Core.Mail.Model;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsSupport.Core.Mail.Interfaz
{
    public interface Interface_Mail
    {
        Task<MimeMessage> GetLastEmailAsync(DTO_IMAP_getlast request);
        Task<List<MimeMessage>> GetEmailsBySubjectAsync(DTO_IMAP_filtro request);
        Task SendEmailAsync(DTO_SMTP_envio request);
    }
}
