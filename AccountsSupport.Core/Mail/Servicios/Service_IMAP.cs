using AccountsSupport.Core.Mail.Interfaz;
using AccountsSupport.Core.Mail.Settings;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Security;
using AccountsSupport.Core.Mail.Model;

namespace AccountsSupport.Core.Mail.Servicios
{
    public class Service_IMAP : Interface_IMAP
    {
        private readonly Settings_Mail settings_Mail;

        public Service_IMAP(Settings_Mail settings)
        {
            settings_Mail = settings;
        }

        public async Task<MimeMessage> GetLastEmailAsync(DTO_IMAP_getlast request)
        {
            using (var client = new ImapClient())
            {
                await client.ConnectAsync(settings_Mail.ImapServer, settings_Mail.ImapPort, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(settings_Mail.ImapUsername, settings_Mail.ImapPwd);

                var inbox = client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly);


                var query = SearchQuery.SubjectContains(request.Subject);
                var uids = inbox.Search(query);

                if (uids.Count == 0)
                    return null;

                var lastUid = uids[uids.Count - 1];
                var message = inbox.GetMessage(lastUid);

                await client.DisconnectAsync(true);

                return message;
            }
        }


        public async Task<List<MimeMessage>> GetEmailsBySubjectAsync(DTO_IMAP_filtro request)
        {
            using (var client = new ImapClient())
            {
                await client.ConnectAsync(settings_Mail.ImapServer, settings_Mail.ImapPort, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(settings_Mail.ImapUsername, settings_Mail.ImapPwd);

                var inbox = client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly);

                var query = SearchQuery.SubjectContains(request.SubjectFilter);
                var uids = inbox.Search(query);

                var list = new List<MimeMessage>();

                foreach (var uid in uids)
                {
                    var message = await inbox.GetMessageAsync(uid);
                    list.Add(message);

                }

                await client.DisconnectAsync(true);

                return list;
            }
        }
    }
}
