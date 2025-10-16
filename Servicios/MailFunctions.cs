using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using MimeKit;
namespace Servicios
{
    public class MailFunctions
    {
        private readonly AccessConnection _accessConnection;
        //Creacion de instancia y constructor de la clase
        public MailFunctions(MailSettings settings)
        {
            _accessConnection =  new AccessConnection(settings);    
        }

        //Envio de correos
        public async Task SendMultipleEmails(List<string> recipients,string subject, string body,int quantity)
        {
            await _accessConnection.sendEmail(recipients, subject, body, quantity);
        }

        //Recepcion de correo con filtro por asunto
        public async Task<MimeMessage> filteredEmail(string subjectFilter)
        {
            return await _accessConnection.getLastEmail(subjectFilter);
        }
        public async Task<string> showLastEmail(string subjectFilter)
        {
            MimeMessage message = await _accessConnection.getLastEmail(subjectFilter);
            return message?.TextBody ?? "No se encontró correo con ese filtro.";
        }

    }
}
