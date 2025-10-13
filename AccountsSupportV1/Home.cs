using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountsSupportV1
{
    public partial class Home: Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void buttonEnviarOpc_Click(object sender, EventArgs e)
        {
            IMAP IMAP = new IMAP();
            IMAP.Show();
        }

        private void buttonRecibirOpc_Click(object sender, EventArgs e)
        {
            SMTP SMTP = new SMTP();
            SMTP.Show();
        }
    }
}
