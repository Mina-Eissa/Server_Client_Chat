
namespace Client
{
    partial class ClientForm
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
            this.Enterlbl = new System.Windows.Forms.Label();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.MessageBox = new System.Windows.Forms.TextBox();
            this.ChatBox = new System.Windows.Forms.ListBox();
            this.ClientsBox = new System.Windows.Forms.ComboBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.ClientNamelbl = new System.Windows.Forms.Label();
            this.ImageFromClientBox = new System.Windows.Forms.ComboBox();
            this.DisplayingBox = new System.Windows.Forms.PictureBox();
            this.Fromlbl = new System.Windows.Forms.Label();
            this.BrowseImagebtn = new System.Windows.Forms.Button();
            this.Imagelbl = new System.Windows.Forms.Label();
            this.SaveImagebtn = new System.Windows.Forms.Button();
            this.ClientNameBox = new System.Windows.Forms.TextBox();
            this.ClientNameFromBox = new System.Windows.Forms.TextBox();
            this.DeleteImagebtn = new System.Windows.Forms.Button();
            this.Clearbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Enterlbl
            // 
            this.Enterlbl.AutoSize = true;
            this.Enterlbl.Location = new System.Drawing.Point(26, 29);
            this.Enterlbl.Name = "Enterlbl";
            this.Enterlbl.Size = new System.Drawing.Size(82, 17);
            this.Enterlbl.TabIndex = 0;
            this.Enterlbl.Text = "Enter Text :";
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(678, 52);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(98, 35);
            this.DisconnectButton.TabIndex = 1;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // MessageBox
            // 
            this.MessageBox.Location = new System.Drawing.Point(29, 58);
            this.MessageBox.Name = "MessageBox";
            this.MessageBox.Size = new System.Drawing.Size(390, 24);
            this.MessageBox.TabIndex = 2;
            // 
            // ChatBox
            // 
            this.ChatBox.FormattingEnabled = true;
            this.ChatBox.ItemHeight = 16;
            this.ChatBox.Location = new System.Drawing.Point(29, 104);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(390, 324);
            this.ChatBox.TabIndex = 3;
            // 
            // ClientsBox
            // 
            this.ClientsBox.FormattingEnabled = true;
            this.ClientsBox.Location = new System.Drawing.Point(435, 58);
            this.ClientsBox.Name = "ClientsBox";
            this.ClientsBox.Size = new System.Drawing.Size(121, 24);
            this.ClientsBox.TabIndex = 4;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(574, 52);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(98, 35);
            this.SendButton.TabIndex = 1;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(678, 11);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(98, 35);
            this.ConnectButton.TabIndex = 1;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // ClientNamelbl
            // 
            this.ClientNamelbl.AutoSize = true;
            this.ClientNamelbl.Location = new System.Drawing.Point(432, 407);
            this.ClientNamelbl.Name = "ClientNamelbl";
            this.ClientNamelbl.Size = new System.Drawing.Size(89, 17);
            this.ClientNamelbl.TabIndex = 0;
            this.ClientNamelbl.Text = "Client Name :";
            // 
            // ImageFromClientBox
            // 
            this.ImageFromClientBox.FormattingEnabled = true;
            this.ImageFromClientBox.Location = new System.Drawing.Point(574, 117);
            this.ImageFromClientBox.Name = "ImageFromClientBox";
            this.ImageFromClientBox.Size = new System.Drawing.Size(202, 24);
            this.ImageFromClientBox.TabIndex = 6;
            this.ImageFromClientBox.SelectedIndexChanged += new System.EventHandler(this.ImageFromClientBox_SelectedIndexChanged);
            // 
            // DisplayingBox
            // 
            this.DisplayingBox.Location = new System.Drawing.Point(435, 147);
            this.DisplayingBox.Name = "DisplayingBox";
            this.DisplayingBox.Size = new System.Drawing.Size(353, 251);
            this.DisplayingBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DisplayingBox.TabIndex = 7;
            this.DisplayingBox.TabStop = false;
            // 
            // Fromlbl
            // 
            this.Fromlbl.AutoSize = true;
            this.Fromlbl.Location = new System.Drawing.Point(432, 120);
            this.Fromlbl.Name = "Fromlbl";
            this.Fromlbl.Size = new System.Drawing.Size(49, 17);
            this.Fromlbl.TabIndex = 8;
            this.Fromlbl.Text = "From :";
            // 
            // BrowseImagebtn
            // 
            this.BrowseImagebtn.Location = new System.Drawing.Point(574, 11);
            this.BrowseImagebtn.Name = "BrowseImagebtn";
            this.BrowseImagebtn.Size = new System.Drawing.Size(98, 35);
            this.BrowseImagebtn.TabIndex = 9;
            this.BrowseImagebtn.Text = "Browse";
            this.BrowseImagebtn.UseVisualStyleBackColor = true;
            this.BrowseImagebtn.Click += new System.EventHandler(this.BrowseImagebtn_Click);
            // 
            // Imagelbl
            // 
            this.Imagelbl.AutoSize = true;
            this.Imagelbl.Location = new System.Drawing.Point(501, 20);
            this.Imagelbl.Name = "Imagelbl";
            this.Imagelbl.Size = new System.Drawing.Size(55, 17);
            this.Imagelbl.TabIndex = 10;
            this.Imagelbl.Text = "Image :";
            // 
            // SaveImagebtn
            // 
            this.SaveImagebtn.Location = new System.Drawing.Point(794, 147);
            this.SaveImagebtn.Name = "SaveImagebtn";
            this.SaveImagebtn.Size = new System.Drawing.Size(98, 35);
            this.SaveImagebtn.TabIndex = 11;
            this.SaveImagebtn.Text = "Save";
            this.SaveImagebtn.UseVisualStyleBackColor = true;
            this.SaveImagebtn.Click += new System.EventHandler(this.SaveImagebtn_Click);
            // 
            // ClientNameBox
            // 
            this.ClientNameBox.Enabled = false;
            this.ClientNameBox.Location = new System.Drawing.Point(527, 404);
            this.ClientNameBox.Name = "ClientNameBox";
            this.ClientNameBox.Size = new System.Drawing.Size(145, 24);
            this.ClientNameBox.TabIndex = 5;
            // 
            // ClientNameFromBox
            // 
            this.ClientNameFromBox.Location = new System.Drawing.Point(487, 117);
            this.ClientNameFromBox.Name = "ClientNameFromBox";
            this.ClientNameFromBox.Size = new System.Drawing.Size(81, 24);
            this.ClientNameFromBox.TabIndex = 12;
            // 
            // DeleteImagebtn
            // 
            this.DeleteImagebtn.Location = new System.Drawing.Point(794, 188);
            this.DeleteImagebtn.Name = "DeleteImagebtn";
            this.DeleteImagebtn.Size = new System.Drawing.Size(98, 35);
            this.DeleteImagebtn.TabIndex = 13;
            this.DeleteImagebtn.Text = "Delete";
            this.DeleteImagebtn.UseVisualStyleBackColor = true;
            this.DeleteImagebtn.Click += new System.EventHandler(this.DeleteImagebtn_Click);
            // 
            // Clearbtn
            // 
            this.Clearbtn.Location = new System.Drawing.Point(794, 229);
            this.Clearbtn.Name = "Clearbtn";
            this.Clearbtn.Size = new System.Drawing.Size(98, 35);
            this.Clearbtn.TabIndex = 14;
            this.Clearbtn.Text = "Clear";
            this.Clearbtn.UseVisualStyleBackColor = true;
            this.Clearbtn.Click += new System.EventHandler(this.Clearbtn_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 450);
            this.Controls.Add(this.Clearbtn);
            this.Controls.Add(this.DeleteImagebtn);
            this.Controls.Add(this.ClientNameFromBox);
            this.Controls.Add(this.SaveImagebtn);
            this.Controls.Add(this.Imagelbl);
            this.Controls.Add(this.BrowseImagebtn);
            this.Controls.Add(this.Fromlbl);
            this.Controls.Add(this.DisplayingBox);
            this.Controls.Add(this.ImageFromClientBox);
            this.Controls.Add(this.ClientNameBox);
            this.Controls.Add(this.ClientsBox);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.MessageBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.ClientNamelbl);
            this.Controls.Add(this.Enterlbl);
            this.Name = "ClientForm";
            this.Text = "Client";
            ((System.ComponentModel.ISupportInitialize)(this.DisplayingBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Enterlbl;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.TextBox MessageBox;
        private System.Windows.Forms.ListBox ChatBox;
        private System.Windows.Forms.ComboBox ClientsBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label ClientNamelbl;
        private System.Windows.Forms.ComboBox ImageFromClientBox;
        private System.Windows.Forms.PictureBox DisplayingBox;
        private System.Windows.Forms.Label Fromlbl;
        private System.Windows.Forms.Button BrowseImagebtn;
        private System.Windows.Forms.Label Imagelbl;
        private System.Windows.Forms.Button SaveImagebtn;
        private System.Windows.Forms.TextBox ClientNameBox;
        private System.Windows.Forms.TextBox ClientNameFromBox;
        private System.Windows.Forms.Button DeleteImagebtn;
        private System.Windows.Forms.Button Clearbtn;
    }
}

