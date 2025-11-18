using AccountsSupport.Core.Mail.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsSupport.Core.Mail.Interfaz
{
   public interface Interface_SMTP
    {
        Task<DTO_SMTP_respuesta> SendEmailAsync(DTO_SMTP_envio request);

    }
}
