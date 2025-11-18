using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsSupport.Core.Mail.Model
{
    public class Filter_IMAP
    {
        //EmailFilter
        public MimeMessage GetLastWithSubject(List<MimeMessage> emails, string subject)
      {
                return emails
                    .Where(e => e.Subject != null &&
                                e.Subject.ToLower().Contains(subject.ToLower()))
                    .LastOrDefault();
      }
        

    }
}
