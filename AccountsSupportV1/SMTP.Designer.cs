namespace AccountsSupportV1
{
    partial class SMTP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textDestinatario = new System.Windows.Forms.TextBox();
            this.textAsunto = new System.Windows.Forms.TextBox();
            this.textCuerpo = new System.Windows.Forms.TextBox();
            this.buttonEnviarSMTP = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Destinatario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Asunto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cuerpo";
            // 
            // textDestinatario
            // 
            this.textDestinatario.Location = new System.Drawing.Point(404, 86);
            this.textDestinatario.Name = "textDestinatario";
            this.textDestinatario.Size = new System.Drawing.Size(254, 22);
            this.textDestinatario.TabIndex = 3;
            this.textDestinatario.TextChanged += new System.EventHandler(this.textDestinatario_TextChanged);
            // 
            // textAsunto
            // 
            this.textAsunto.Location = new System.Drawing.Point(404, 160);
            this.textAsunto.Name = "textAsunto";
            this.textAsunto.Size = new System.Drawing.Size(254, 22);
            this.textAsunto.TabIndex = 4;
            this.textAsunto.TextChanged += new System.EventHandler(this.textAsunto_TextChanged);
            // 
            // textCuerpo
            // 
            this.textCuerpo.Location = new System.Drawing.Point(404, 237);
            this.textCuerpo.Name = "textCuerpo";
            this.textCuerpo.Size = new System.Drawing.Size(254, 22);
            this.textCuerpo.TabIndex = 5;
            // 
            // buttonEnviarSMTP
            // 
            this.buttonEnviarSMTP.Location = new System.Drawing.Point(350, 321);
            this.buttonEnviarSMTP.Name = "buttonEnviarSMTP";
            this.buttonEnviarSMTP.Size = new System.Drawing.Size(154, 29);
            this.buttonEnviarSMTP.TabIndex = 6;
            this.buttonEnviarSMTP.Text = "ENVIAR";
            this.buttonEnviarSMTP.UseVisualStyleBackColor = true;
            this.buttonEnviarSMTP.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(387, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 7;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // SMTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonEnviarSMTP);
            this.Controls.Add(this.textCuerpo);
            this.Controls.Add(this.textAsunto);
            this.Controls.Add(this.textDestinatario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SMTP";
            this.Text = "SMTP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textDestinatario;
        private System.Windows.Forms.TextBox textAsunto;
        private System.Windows.Forms.TextBox textCuerpo;
        private System.Windows.Forms.Button buttonEnviarSMTP;
        private System.Windows.Forms.Button button1;
    }
}