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
    public partial class IMAP: Form
    {
        
        private readonly MailFunctions _mailFunctions;
        private readonly MailSettings _mailSettings = new MailSettings();

        public IMAP()
        {
            InitializeComponent();
            _mailSettings = new MailSettings();
            _mailFunctions = new MailFunctions(_mailSettings);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void IMAP_Load(object sender, EventArgs e)
        {

        }

        private async Task function2(object sender, EventArgs e)
        {
            

            string usuario = textMail.Text?.Trim();
            string password = textPwd.Text?.Trim();
            if ((string.IsNullOrWhiteSpace(usuario) || (string.IsNullOrWhiteSpace(password))))
            {
                MessageBox.Show("Por favor, ingresa usuario y contraseña.");
                return;
            }

            try
            {
                string subjectFilter = "código de acceso";
                var cuerpoCorreo = await _mailFunctions.filteredEmail(subjectFilter.Trim());

                if (cuerpoCorreo == null)
                {
                    MessageBox.Show("No se encontró ningún correo que coincida con el filtro.");
                    return;
                }

                // Si el cuerpo tiene texto plano
                if (!string.IsNullOrEmpty(cuerpoCorreo.TextBody))
                    textCode.Text = cuerpoCorreo.TextBody;

                else if (!string.IsNullOrEmpty(cuerpoCorreo.HtmlBody))
                    textCode.Text = cuerpoCorreo.HtmlBody;
                
                else
                    textCode.Text = "El correo no tiene contenido legible.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer correos: {ex.Message}");
            }

            MessageBox.Show("Correo leído correctamente SAPA.");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void textMail_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void textPwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonCode_Click(object sender, EventArgs e)
        {
            string usuario = textMail.Text?.Trim();
            string password = textPwd.Text?.Trim();
            if (usuario =="hola" && password=="hola")
            {
                function2(sender, e);   
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos SAPA");
            }   
        }

        private void textCode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
