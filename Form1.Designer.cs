namespace aps2excel
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            openFileDialog1 = new OpenFileDialog();
            OpenBtn = new Button();
            FilePathlbl = new Label();
            Convertbtn = new Button();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "aps";
            openFileDialog1.Filter = "APS files (*.aps)|*.aps";
            // 
            // OpenBtn
            // 
            OpenBtn.Location = new Point(12, 12);
            OpenBtn.Name = "OpenBtn";
            OpenBtn.Size = new Size(75, 23);
            OpenBtn.TabIndex = 0;
            OpenBtn.Text = "Open File";
            OpenBtn.UseVisualStyleBackColor = true;
            OpenBtn.Click += OpenBtn_Click;
            // 
            // FilePathlbl
            // 
            FilePathlbl.AutoSize = true;
            FilePathlbl.Location = new Point(12, 38);
            FilePathlbl.Name = "FilePathlbl";
            FilePathlbl.Size = new Size(0, 15);
            FilePathlbl.TabIndex = 1;
            // 
            // Convertbtn
            // 
            Convertbtn.Location = new Point(12, 77);
            Convertbtn.Name = "Convertbtn";
            Convertbtn.Size = new Size(75, 23);
            Convertbtn.TabIndex = 2;
            Convertbtn.Text = "Convert";
            Convertbtn.UseVisualStyleBackColor = true;
            Convertbtn.Click += ConvertBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 130);
            Controls.Add(Convertbtn);
            Controls.Add(FilePathlbl);
            Controls.Add(OpenBtn);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button OpenBtn;
        private Label FilePathlbl;
        private Button Convertbtn;
    }
}