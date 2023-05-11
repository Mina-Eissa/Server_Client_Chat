
namespace Server
{
    partial class ServerForm
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
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ChatBox = new System.Windows.Forms.ListBox();
            this.test = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.test)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(641, 37);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(92, 41);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(641, 84);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(92, 41);
            this.StopButton.TabIndex = 0;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ChatBox
            // 
            this.ChatBox.FormattingEnabled = true;
            this.ChatBox.ItemHeight = 16;
            this.ChatBox.Location = new System.Drawing.Point(40, 37);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(571, 388);
            this.ChatBox.TabIndex = 1;
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(641, 188);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(311, 237);
            this.test.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.test.TabIndex = 2;
            this.test.TabStop = false;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.test);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Name = "ServerForm";
            this.Text = "Server";
            ((System.ComponentModel.ISupportInitialize)(this.test)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.ListBox ChatBox;
        private System.Windows.Forms.PictureBox test;
    }
}

