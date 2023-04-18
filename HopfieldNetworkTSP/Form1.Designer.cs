namespace HopfieldNetworkTSP
{
    partial class HopfieldTSP
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
            button1 = new Button();
            openFileDialog1 = new OpenFileDialog();
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 309);
            button1.Name = "button1";
            button1.Size = new Size(299, 34);
            button1.TabIndex = 0;
            button1.Text = "Выберите файл";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 12);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(299, 291);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(12, 349);
            button2.Name = "button2";
            button2.Size = new Size(299, 34);
            button2.TabIndex = 3;
            button2.Text = "Загрузить результат";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // HopfieldTSP
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 392);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "HopfieldTSP";
            Text = "HopfieldTSP";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private OpenFileDialog openFileDialog1;
        private RichTextBox richTextBox1;
        private Button button2;
    }
}