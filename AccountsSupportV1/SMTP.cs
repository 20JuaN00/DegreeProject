using Data;
using Servicios;
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
    public partial class SMTP: Form
    {
        private readonly MailFunctions _mailFunctions;
        private readonly MailSettings _mailSettings;
        public SMTP()
        {
            InitializeComponent();
            _mailFunctions = new MailFunctions(_mailSettings);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Enviar
            string destinatario =textDestinatario.Text?.Trim();
            string asunto = textAsunto.Text?.Trim();
            string cuerpo = textCuerpo.Text?.Trim();

            if (string.IsNullOrWhiteSpace(destinatario) || string.IsNullOrWhiteSpace(asunto) || string.IsNullOrWhiteSpace(cuerpo))
            {
                MessageBox.Show("Por favor completa destinatario, asunto y cuerpo.");
                return;
            }

            var recipients = new List<string> { destinatario };

            button1.Enabled = false;
            try
            {
                 _mailFunctions.SendMultipleEmails(recipients, asunto, cuerpo, 1);
                MessageBox.Show("Correo enviado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar: {ex.Message}");
            }
            finally
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();    
        }

        private void textDestinatario_TextChanged(object sender, EventArgs e)
        {

        }

        private void textAsunto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
