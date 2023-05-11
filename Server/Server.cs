using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Client;
namespace Server
{
    public partial class ServerForm : Form
    {
        private TcpListener serverSocket;
        private List<Thread> clientThreads;
        private Dictionary<string, TcpClient> clients;
        private Dictionary<TcpClient, Thread> clientThreadsMap;
        private Thread serverThread;
        private List<string> CurrentClients;
        public ServerForm()
        {
            InitializeComponent();
            clientThreads = new List<Thread>();
            clients = new Dictionary<string, TcpClient>();
            clientThreadsMap = new Dictionary<TcpClient, Thread>();
            CurrentClients = new List<string>();
        }
        private void ServerThread()
        {
            while (true)
            {
                TcpClient clientSocket = serverSocket.AcceptTcpClient();
                Thread clientThread = new Thread(new ParameterizedThreadStart(ClientThread));
                clientThread.Start(clientSocket);
            }
        }
        private void ClientThread(object clientSocket)
        {
            TcpClient tcpClient = (TcpClient)clientSocket;
            string ClientNaturalName, ClientNameInDis;

            // Get the clientNaturalName
            string ConnectingMessage = RecieveMessage(tcpClient);
            string[] ConnectingMessageParts = ConnectingMessage.Split('|');
            ClientNaturalName = ConnectingMessageParts[1];
            CurrentClients.Add(ClientNaturalName);

            // Add the client to the dictionary of connected clients
            clients.Add(ClientNaturalName, tcpClient);
            clientThreadsMap.Add(tcpClient, Thread.CurrentThread);

           
            // Send a notification to all connected clients that a new client has joined
            Broadcast(ClientNaturalName + "| has joined the chat.");

            // Create message from CurrentClient names to update and send update to all clients
            string UpdateMessage = ConvertCurrentClientToMessage();
            Broadcast(UpdateMessage);

            // Print New Connected Client 
            this.Invoke((MethodInvoker)delegate () {
                ChatBox.Items.Add(ClientNaturalName + "| has joined the chat.");
            });
           

            // Start listening for incoming messages from the client
            while (true)
            {
                try
                {
                    string message = RecieveMessage(tcpClient);
                    string[] messageParts = message.Split('|');
                    // Check the message destination and forward it to the appropriate client(s)
                    string destination = messageParts[0];
                    StringBuilder content = new StringBuilder(), output = new StringBuilder();

                    // define byte array to image 
                    byte[] imageData = new byte[0];
                    if (message.Contains("Image"))
                    {
                        imageData = RecieveImage(tcpClient);
                        //System.Windows.Forms.MessageBox.Show(imageData.ToString());
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            test.Image = ImageUsed.ByteArrayToImage(imageData);
                        });
                        for (int i = 1; i < messageParts.Length; i++)
                        {
                            if (i < messageParts.Length - 1)
                                content.Append(messageParts[i] + "|");
                            else
                                content.Append(messageParts[i]);

                        }

                        output.Append(messageParts[3]);
                        output.Append(" and ");
                        output.Append(messageParts[2]);
                    }
                    else
                    {
                        content.Append(messageParts[1]);
                        output.Append(messageParts[1]);
                    }

                    if (destination == "All")
                    {
                        Broadcast(ClientNaturalName + "|" + content.ToString());
                        if (imageData.Length!=0)
                        {
                            BroadcastImage(imageData);
                        }
                    }
                    else
                    {
                        TcpClient destinationClient = clients[destination];
                        SendMessage(destinationClient, content.ToString(), ClientNaturalName);
                        if (imageData.Length != 0)
                        {
                            SendImage(destinationClient, imageData);
                        }
                    }
                    this.Invoke((MethodInvoker)delegate () {
                        ChatBox.Items.Add(ClientNaturalName + " to " + destination + ": " + output.ToString());
                    });

            }
                catch (Exception ex)
            {
                // Remove the client from the dictionary of connected clients
                clients.Remove(ClientNaturalName);
                clientThreadsMap.Remove(tcpClient);
                Broadcast(ClientNaturalName + "| has left the chat.");

                // Remove client and send update message to clients
                CurrentClients.Remove(ClientNaturalName);
                UpdateMessage = ConvertCurrentClientToMessage();
                Broadcast(UpdateMessage);

                // Print left Connected Client 
                this.Invoke((MethodInvoker)delegate ()
                {
                    ChatBox.Items.Add(ClientNaturalName + "| has left the chat.");
                });

                break;
            }
        }
        }
        private void Broadcast(string message)
        {
            // Send the message to all connected clients
            //System.Windows.Forms.MessageBox.Show(message);
            foreach (TcpClient client in clients.Values)
            {
                NetworkStream networkStream = client.GetStream();
                byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(message + "$");

                networkStream.Write(bytesToSend, 0, bytesToSend.Length);
                networkStream.Flush();
            }
        }
        private void BroadcastImage(byte[] image)
        {
            // Send the message to all connected clients
            foreach (TcpClient client in clients.Values)
            {
                NetworkStream networkStream = client.GetStream();
                byte[] sizeBytes = BitConverter.GetBytes(image.Length);
                networkStream.Write(sizeBytes, 0, sizeBytes.Length);
                networkStream.Flush();
                networkStream.Write(image, 0, image.Length);
                networkStream.Flush();
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            serverSocket = new TcpListener(IPAddress.Any, 8000);
            serverSocket.Start();

            // Start a new thread to handle incoming client connections
            serverThread = new Thread(new ThreadStart(ServerThread));
            serverThread.Start();

            ChatBox.Items.Add("Server is connected :)");
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Broadcast("Server is disconnected :(");
            ChatBox.Items.Add("Server is disconnected :(");
            CurrentClients.Clear();
            Broadcast(ConvertCurrentClientToMessage());

            // Close the socket and thread
            serverSocket.Stop();
            serverThread.Abort();
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
        private byte[] RecieveImage(TcpClient TempClient)
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
            return imageBytes;
        }
        private void SendMessage(TcpClient TempClient,string message,string ClientNaturalName)
        {
            NetworkStream destinationStream = TempClient.GetStream();
            byte[] bytesToSend = System.Text.Encoding.ASCII.GetBytes(ClientNaturalName + "|" + message + "$");
            destinationStream.Write(bytesToSend, 0, bytesToSend.Length);
            destinationStream.Flush();
        }
        private void SendImage(TcpClient TempClient,byte[] image)
        {
            NetworkStream destinationStream = TempClient.GetStream();
            byte[] sizeBytes = BitConverter.GetBytes(image.Length);
            destinationStream.Write(sizeBytes, 0, sizeBytes.Length);
            destinationStream.Flush();
            destinationStream.Write(image, 0, image.Length);
            destinationStream.Flush();
        }
        private string ConvertCurrentClientToMessage()
        {
            StringBuilder message = new StringBuilder();
            message.Append("Current Clients");
            foreach(var Client in CurrentClients)
            {
                message.Append("|" + Client);
            }
            return message.ToString();
        }
    }
}
