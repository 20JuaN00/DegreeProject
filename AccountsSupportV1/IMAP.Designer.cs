namespace AccountsSupportV1
{
    partial class IMAP
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textMail = new System.Windows.Forms.TextBox();
            this.textPwd = new System.Windows.Forms.TextBox();
            this.buttonCode = new System.Windows.Forms.Button();
            this.textCode = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Correo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textMail
            // 
            this.textMail.Location = new System.Drawing.Point(369, 115);
            this.textMail.Name = "textMail";
            this.textMail.Size = new System.Drawing.Size(290, 22);
            this.textMail.TabIndex = 2;
            this.textMail.TextChanged += new System.EventHandler(this.textMail_TextChanged);
            // 
            // textPwd
            // 
            this.textPwd.Location = new System.Drawing.Point(368, 190);
            this.textPwd.Name = "textPwd";
            this.textPwd.Size = new System.Drawing.Size(290, 22);
            this.textPwd.TabIndex = 3;
            this.textPwd.TextChanged += new System.EventHandler(this.textPwd_TextChanged);
            // 
            // buttonCode
            // 
            this.buttonCode.Location = new System.Drawing.Point(483, 258);
            this.buttonCode.Name = "buttonCode";
            this.buttonCode.Size = new System.Drawing.Size(175, 31);
            this.buttonCode.TabIndex = 4;
            this.buttonCode.Text = "Traer codigo";
            this.buttonCode.UseVisualStyleBackColor = true;
            this.buttonCode.Click += new System.EventHandler(this.buttonCode_Click);
            // 
            // textCode
            // 
            this.textCode.Location = new System.Drawing.Point(269, 330);
            this.textCode.Name = "textCode";
            this.textCode.ReadOnly = true;
            this.textCode.Size = new System.Drawing.Size(279, 22);
            this.textCode.TabIndex = 5;
            this.textCode.TextChanged += new System.EventHandler(this.textCode_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(369, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IMAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textCode);
            this.Controls.Add(this.buttonCode);
            this.Controls.Add(this.textPwd);
            this.Controls.Add(this.textMail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IMAP";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.IMAP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textMail;
        private System.Windows.Forms.TextBox textPwd;
        private System.Windows.Forms.Button buttonCode;
        private System.Windows.Forms.TextBox textCode;
        private System.Windows.Forms.Button button1;
    }
}

