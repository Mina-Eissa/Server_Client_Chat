using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Client
{
  
    public partial class ClientForm : Form
    {

        private TcpClient clientSocket;
        private Thread clientThread;
        private string ClientName;
        private bool isConnected;
        private List<string> CurrentClients;
        private ImageUsed ImageToSend, CurrentDispalyingImage;
        private Dictionary<string, Image> ListOfCurrentImages;
        public ClientForm()
        {
            InitializeComponent();
            isConnected = false;
            CurrentClients = new List<string>();
            ListOfCurrentImages = new Dictionary<string, Image>();

            ImageToSend = new ImageUsed();
            CurrentDispalyingImage = new ImageUsed();
            // Generate Name for this user
            ClientName = GenerateRandomName();
            ClientNameBox.Text = ClientName;
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (isConnected == false)
            {
                try
                {
                    clientSocket = new TcpClient();
                    clientSocket.Connect(IPAddress.Parse("127.0.0.1"), 8000);

                    // Start a new thread to handle incoming messages from the server
                    clientThread = new Thread(new ThreadStart(ClientThread));
                    clientThread.Start();

                    // Set isConnected to true even not connect more than once
                    isConnected = true;

                    // Send a connection message to the server
                    Send("Connect|" + ClientName);

                    // Set Clients 
                    string message = RecieveMessage(clientSocket);
                    if (message.Contains("Current Clients"))
                    {
                        UpdateCurrentClients(message);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show("Server is not connected");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("You can not connect more than one.");
            }
        }

        private void DisconnectButton_Click(object sender, EventArgs e)
        {
            if (isConnected == true)
            {
                // Send a disconnection message to the server
                Send("Disconnect|" + ClientName);

                // Close the client socket and stop the client thread
                clientSocket.Close();
                clientThread.Abort();

                isConnected = false;
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (ClientsBox.Items.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("you should connect first !!");
                return;
            }
            // Send a message to the server
            string destination = ClientsBox.SelectedItem.ToString();
            if (destination == "")
            {
                System.Windows.Forms.MessageBox.Show("you should choose client too !!");
                return;
            }
            string content = MessageBox.Text;
            if (ImageToSend.image != null)
            {
                byte[] ImageData = ImageToSend.ImageToByteArray();
                Send(destination + "|Image|" + ImageToSend.name + "|" + content);
                SendImage(ImageData);
                ImageToSend.Clear();
                DisplayingBox.Image = null;
            }
            else
            {
                Send(destination + "|" + content);
            }

            // Clear the message text box
            MessageBox.Text = "";
        }

        private void ClientThread()
        {
            while (true)
            {
                try
                {
                    string message = RecieveMessage(clientSocket);
                    if (message.Contains("Current Clients"))
                    {
                        UpdateCurrentClients(message);
                    }
                    else if (message.Contains("Image"))
                    {
                        Image TempImage = RecieveImage(clientSocket);
                        AddtoImageFromClientsBox(message, TempImage);

                    }
                    else
                    {
                        // Update the chat box with the incoming message
                        ChatBox.Invoke(new Action(() =>
                        {
                            ChatBox.Items.Add(message + "\r\n");
                        }));
                    }
                }
                catch (Exception ex)
                {
                    // Display an error message
                    //System.Windows.Forms.MessageBox.Show("Connection to server lost.");

                    // Close the client socket and stop the client thread
                    clientSocket.Close();
                    clientThread.Abort();

                    break;
                }
            }
        }

        private void Send(string message)
        {
            try
            {
                NetworkStream networkStream = clientSocket.GetStream();
                byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(message + "$");
                networkStream.Write(bytesToSend, 0, bytesToSend.Length);
                networkStream.Flush();
            }
            catch (Exception ex)
            {
                // Display an error message
                System.Windows.Forms.MessageBox.Show("Connection to server lost.");

                // Close the client socket and stop the client thread
                clientSocket.Close();
                clientThread.Abort();
            }
        }
        private void SendImage(byte[] imageData)
        {
            try
            {
                NetworkStream networkStream = clientSocket.GetStream();
                byte[] sizeBytes = BitConverter.GetBytes(imageData.Length);
                networkStream.Write(sizeBytes, 0, sizeBytes.Length);
                networkStream.Flush();
                networkStream.Write(imageData, 0, imageData.Length);
                networkStream.Flush();
            }
            catch (Exception ex)
            {
                // Display an error message
                System.Windows.Forms.MessageBox.Show("Connection to server lost.");

                // Close the client socket and stop the client thread
                clientSocket.Close();
                clientThread.Abort();
            }
        }
        private static readonly Random random = new Random();
        public static string GenerateRandomName()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private string RecieveMessage(TcpClient TempClient)
        {
            NetworkStream networkStream = TempClient.GetStream();
            byte[] bytesFrom = new byte[TempClient.ReceiveBufferSize];
            networkStream.Read(bytesFrom, 0, TempClient.ReceiveBufferSize);
            string message = System.Text.Encoding.ASCII.GetString(bytesFrom);
            message = message.Substring(0, message.IndexOf("$"));
            return message;

        }
        private Image RecieveImage(TcpClient TempClient)
        {
            NetworkStream networkStream = TempClient.GetStream();
            byte[] sizeBytes = new byte[sizeof(int)];
            networkStream.Read(sizeBytes, 0, sizeBytes.Length);
            int imageSize = BitConverter.ToInt32(sizeBytes, 0);
            // Receive the image data from the sender
            byte[] imageBytes = new byte[imageSize];
            int bytesRead = 0;
            int offset = 0;
            while (bytesRead < imageSize)
            {
                int count = networkStream.Read(imageBytes, offset, imageSize - bytesRead);
                bytesRead += count;
                offset += count;
            }
            Image TempImage = ImageUsed.ByteArrayToImage(imageBytes);
            return TempImage;
        }

        private void UpdateCurrentClients(string message)
        {
            this.Invoke((MethodInvoker)delegate () {
                ClientsBox.Items.Clear();
            });
            string[] messageParts = message.Split('|');
            for(int i = 1; i < messageParts.Length; i++)
            {
                if (messageParts[i] != ClientName)
                {
                    this.Invoke((MethodInvoker)delegate () {
                        ClientsBox.Items.Add(messageParts[i]);
                    });
                }
            }
            if (ClientsBox.Items.Count > 1)
            {
                this.Invoke((MethodInvoker)delegate () {
                    ClientsBox.Items.Add("All");
                });
            }
        }

        private void BrowseImagebtn_Click(object sender, EventArgs e)
        {
            // Create a new instance of the OpenFileDialog class
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the filter to allow only image files
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp, *.gif) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.bmp; *.gif";

            // Show the file dialog and wait for the user to select a file
            DialogResult result = openFileDialog.ShowDialog();

            // If the user selects a file, load the image and display it in your WinForms application
            if (result == DialogResult.OK)
            {

                // Load the image from the file
                ImageToSend.name = openFileDialog.FileName.Trim();
                ImageToSend.image = Image.FromFile(openFileDialog.FileName);

                // Display the image in your WinForms application
                DisplayingBox.Image = ImageToSend.image;
            }
        }

       
        private void SaveImagebtn_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (CurrentDispalyingImage != null)
                    CurrentDispalyingImage.Save();
            //}
            //catch { }
        }

        private void DeleteImagebtn_Click(object sender, EventArgs e)
        {
            string Key = ClientNameFromBox.Text + "|" + CurrentDispalyingImage.name;
            System.Windows.Forms.MessageBox.Show(Key);
            if (ListOfCurrentImages.ContainsKey(Key))
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    ListOfCurrentImages.Remove(Key);
                    ImageFromClientBox.Items.Remove(Key);
                });
            }

            this.Invoke((MethodInvoker)delegate ()
            {
                DisplayingBox.Image = null;
                ClientNameFromBox.Text = "";
                ImageFromClientBox.SelectedItem = "";

            });

        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                DisplayingBox.Image = null;
                ClientNameFromBox.Text = "";
            });
        }

        private void ImageFromClientBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string user = ImageFromClientBox.SelectedItem.ToString();
            ImageFromClientBox.SelectedItem = "";
            this.Invoke((MethodInvoker)delegate ()
            {
                CurrentDispalyingImage.image = ListOfCurrentImages[user];
                CurrentDispalyingImage.name = user.Split('|')[1];
                DisplayingBox.Image = ListOfCurrentImages[user];
                ClientNameFromBox.Text = user.Split('|')[0];
            });
        }

        private void AddtoImageFromClientsBox(string message,Image TempImage)
        {
            string[] messageParts = message.Split('|');
            // Prepare User name , Image name   
            string user = messageParts[0] + "|" + messageParts[2];
            
            // Adding it to comboBox
            ImageFromClientBox.Items.Add(user);

            // Adding key-> (user and image name) and value-> image
            ListOfCurrentImages.Add(user, TempImage);
            
        }
    }
}
