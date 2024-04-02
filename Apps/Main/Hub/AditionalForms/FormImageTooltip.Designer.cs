namespace SOS_Essential.Apps.Main.Lobby.AditionalForms
{
    partial class FormImageTooltip
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
            this.Tooltippb = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Tooltippb)).BeginInit();
            this.SuspendLayout();
            // 
            // Tooltippb
            // 
            this.Tooltippb.Location = new System.Drawing.Point(-1, 54);
            this.Tooltippb.Name = "Tooltippb";
            this.Tooltippb.Size = new System.Drawing.Size(637, 338);
            this.Tooltippb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Tooltippb.TabIndex = 0;
            this.Tooltippb.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(225, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Coding Tutorial";
            // 
            // FormImageTooltip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 415);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Tooltippb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormImageTooltip";
            this.Text = "FormImageTooltip";
            ((System.ComponentModel.ISupportInitialize)(this.Tooltippb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox Tooltippb;
        private Label label1;
    }
}