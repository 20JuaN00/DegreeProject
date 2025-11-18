using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountsSupport.Core.Mail.Interfaz;
using AccountsSupport.Core.Mail.Settings;
using AccountsSupport.Core.Mail.Model;

namespace AccountsSupport.Core.Mail.Servicios
{
    public class Service_SMTP : Interface_SMTP
    {
        private readonly Settings_Mail settings_Mail;

        public Service_SMTP(Settings_Mail settings)
        {
            settings_Mail = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public async Task<DTO_SMTP_respuesta> SendEmailAsync(DTO_SMTP_envio request)
        {
            var response = new DTO_SMTP_respuesta();

            // Validaciones
            if (request == null)
            {
                response.Success = false;
                response.Message = "La solicitud es nula.";
                response.Error = "Request is null.";
                return response;
            }

            if (request.Recipients == null || request.Recipients.Count == 0)
            {
                response.Success = false;
                response.Message = "No se proporcionaron destinatarios.";
                response.Error = "Recipients list is empty.";
                return response;
            }

            using (var client = new SmtpClient())
            {
                try
                {
                    // Conexión al servidor SMTP 
                    await client.ConnectAsync(settings_Mail.SmtpServer, settings_Mail.SmtpPort,
                        SecureSocketOptions.StartTls);

                    // Autenticación
                    await client.AuthenticateAsync(settings_Mail.SmtpUsername, settings_Mail.SmtpPwd);

                    // Creación estructura del mensaje
                    var message = new MimeMessage();
                    message.From.Add(MailboxAddress.Parse(settings_Mail.SmtpUsername));

                    foreach (var correo in request.Recipients)
                    {
                        message.To.Add(MailboxAddress.Parse(correo));
                    }

                    message.Subject = request.Subject;
                    message.Body = new TextPart("plain") { Text = request.Body };

                    // Envío del mensaje 
                    await client.SendAsync(message);

                    // Desconexión
                    await client.DisconnectAsync(true);

                    response.Success = true;
                    response.Message = "Correo enviado correctamente.";
                    response.Error = null;
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = "Error al enviar correo.";
                    response.Error = ex.Message;
                }
            }

            return response;
        }
    }
}