using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
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
        private MailSettings settings;

        public AccessConnection(MailSettings settings)
        {
            this.settings = settings;
        }

        //Método para enviar el correo
        public async Task sendEmail(List<string> recipients, string subject, string body, int count)
        {
            using ( var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    var _mailSettings = new MailSettings();
                    // Conexión al servidor SMTP 
                    await client.ConnectAsync(_mailSettings.SmtpServer, _mailSettings.SmtpPort,
                        SecureSocketOptions.StartTls);

                    await client.AuthenticateAsync(_mailSettings.SmtpUsername, _mailSettings.SmtpPwd);

                    if (true)
                    {
                        Console.WriteLine("Conexión SMTP exitosa.");
                    }
                    
                    
                        for (int i = 0; i < count; i++)
                        {
                            var message = new MimeMessage();

                            message.From.Add(MailboxAddress.Parse(_mailSettings.SmtpUsername));
                            message.To.AddRange(recipients.Select(r => new MailboxAddress($"#{i}", r)));
                            message.Subject = $"{subject} #{i + 1}";
                            message.Body = new TextPart("plain") { Text = body };

                            await client.SendAsync(message);
                        }

                    await client.DisconnectAsync(true);

                }catch (Exception ex)
                {
                    Console.WriteLine($"Error de conexión SMTP: {ex.Message}");
                }

            }
            
        }



        //Metodo para filtrar los correos por asunto y mostrarlos
        public async Task<MimeMessage> getLastEmail(string subjectFilter)
        {
            
            var client = new MailKit.Net.Imap.ImapClient();
            subjectFilter = "código de acceso";

            using (client = new ImapClient())
            {
                var _mailSettings = new MailSettings();
                // Conexión al servidor IMAP
                await client.ConnectAsync(_mailSettings.ImapServer, _mailSettings.ImapPort, _mailSettings.ImapUseSsl);
                await client.AuthenticateAsync(_mailSettings.ImapUsername, _mailSettings.ImapPwd);

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

}


