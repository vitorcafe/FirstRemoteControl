namespace WFARemoteControl
{
    partial class Form1
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
            this.btAprender = new System.Windows.Forms.Button();
            this.btTransmitir = new System.Windows.Forms.Button();
            this.rtbInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btAprender
            // 
            this.btAprender.Location = new System.Drawing.Point(12, 12);
            this.btAprender.Name = "btAprender";
            this.btAprender.Size = new System.Drawing.Size(75, 23);
            this.btAprender.TabIndex = 0;
            this.btAprender.Text = "Aprender";
            this.btAprender.UseVisualStyleBackColor = true;
            this.btAprender.Click += new System.EventHandler(this.btAprender_Click);
            // 
            // btTransmitir
            // 
            this.btTransmitir.Location = new System.Drawing.Point(93, 12);
            this.btTransmitir.Name = "btTransmitir";
            this.btTransmitir.Size = new System.Drawing.Size(75, 23);
            this.btTransmitir.TabIndex = 1;
            this.btTransmitir.Text = "Transmitir";
            this.btTransmitir.UseVisualStyleBackColor = true;
            this.btTransmitir.Click += new System.EventHandler(this.btTransmitir_Click);
            // 
            // rtbInfo
            // 
            this.rtbInfo.Location = new System.Drawing.Point(12, 41);
            this.rtbInfo.Name = "rtbInfo";
            this.rtbInfo.Size = new System.Drawing.Size(156, 208);
            this.rtbInfo.TabIndex = 2;
            this.rtbInfo.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 261);
            this.Controls.Add(this.rtbInfo);
            this.Controls.Add(this.btTransmitir);
            this.Controls.Add(this.btAprender);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btAprender;
        private System.Windows.Forms.Button btTransmitir;
        private System.Windows.Forms.RichTextBox rtbInfo;
    }
}

