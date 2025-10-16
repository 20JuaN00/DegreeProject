namespace AccountsSupportV1
{
    partial class Home
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
            this.label2 = new System.Windows.Forms.Label();
            this.buttonEnviarOpc = new System.Windows.Forms.Button();
            this.buttonRecibirOpc = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(185, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(438, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Elija el servicio que desea usar";
            // 
            // buttonEnviarOpc
            // 
            this.buttonEnviarOpc.Location = new System.Drawing.Point(300, 172);
            this.buttonEnviarOpc.Name = "buttonEnviarOpc";
            this.buttonEnviarOpc.Size = new System.Drawing.Size(226, 57);
            this.buttonEnviarOpc.TabIndex = 2;
            this.buttonEnviarOpc.Text = "Enviar Correos";
            this.buttonEnviarOpc.UseVisualStyleBackColor = true;
            this.buttonEnviarOpc.Click += new System.EventHandler(this.buttonEnviarOpc_Click);
            // 
            // buttonRecibirOpc
            // 
            this.buttonRecibirOpc.Location = new System.Drawing.Point(300, 263);
            this.buttonRecibirOpc.Name = "buttonRecibirOpc";
            this.buttonRecibirOpc.Size = new System.Drawing.Size(226, 57);
            this.buttonRecibirOpc.TabIndex = 3;
            this.buttonRecibirOpc.Text = "Recepción Correos";
            this.buttonRecibirOpc.UseVisualStyleBackColor = true;
            this.buttonRecibirOpc.Click += new System.EventHandler(this.buttonRecibirOpc_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(379, 361);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 7;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonRecibirOpc);
            this.Controls.Add(this.buttonEnviarOpc);
            this.Controls.Add(this.label2);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonEnviarOpc;
        private System.Windows.Forms.Button buttonRecibirOpc;
        private System.Windows.Forms.Button button1;
    }
}