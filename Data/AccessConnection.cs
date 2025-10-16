using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Data
{
    public class AccessConnection
    {
        //Constructor que recibe la configuración del envio del correo desde la instancia
        private readonly MailSettings _mailSettings;
        public AccessConnection( MailSettings settings )
        {
            _mailSettings= settings;
        }

        //Método para enviar el correo
        public async Task sendEmail(List<string> recipients, string subject, string body, int count)
        {
            var client = new MailKit.Net.Smtp.SmtpClient();


            using (client = new MailKit.Net.Smtp.SmtpClient())
            {
                // Conexión al servidor SMTP con SSL o StartTls según configuración
                await client.ConnectAsync(_mailSettings.SmtpServer, _mailSettings.SmtpPort,
                    _mailSettings.SmtpUseSsl ? SecureSocketOptions.SslOnConnect : SecureSocketOptions.StartTls);

                await client.AuthenticateAsync(_mailSettings.User, _mailSettings.Pass);
            }

            for (int i = 0; i < count; i++)
            {
                var message = new MimeMessage();

                message.From.Add(new MailboxAddress("NN", "envio248@gmail.com"));
                message.To.AddRange(recipients.Select(r => new MailboxAddress($"#{i}", r)));
                message.Subject = $"{subject} #{i + 1}";
                message.Body = new TextPart("plain") { Text = body };

                await client.SendAsync(message);
            }

            await client.DisconnectAsync(true);
        }



        //Metodo para filtrar los correos por asunto y mostrarlos
        public async Task<MimeMessage> getLastEmail(string subjectFilter)
        {
            var client = new MailKit.Net.Imap.ImapClient();
            subjectFilter = "código de acceso";

            using (client = new ImapClient())
            {
                // Conexión al servidor IMAP
                await client.ConnectAsync(_mailSettings.ImapServer, _mailSettings.ImapPort, _mailSettings.ImapUseSsl);
                await client.AuthenticateAsync(_mailSettings.User, _mailSettings.Pass);
            }

            // Abrir la bandeja de entrada
            var inbox = client.Inbox;
            await inbox.OpenAsync(MailKit.FolderAccess.ReadOnly);

            // Buscar correos que coincidan con el filtro de asunto
            var query = MailKit.Search.SearchQuery.SubjectContains(subjectFilter);
            var uids = await inbox.SearchAsync(query);

            if (uids.Count == 0)
            {
                await client.DisconnectAsync(true);
                return null;
            }

            // Obtener el último correo que coincide con el filtro
            var lastUid = uids[uids.Count - 1];
            var message = await inbox.GetMessageAsync(lastUid);

            // Desconectar del servidor
            await client.DisconnectAsync(true);
            return message;
        }
    }

}


