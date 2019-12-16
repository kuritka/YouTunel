using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Renci.SshNet;
using Random = System.Random;

namespace ConsoleApplication1
{

    internal class XyZ
    {
        public static void Main()
        {
            using (var client = new SshClient("p.ceex.cz", 443,"coba", ".coba123"))
            {
                client.Connect();
                client.RunCommand("etc/init.d/networking restart");
                client.Disconnect();
            }
        }
    }

    //internal class Program
    //{

    //    public static void Main()
    //    {
    //        // Setup Credentials and Server Information
    //        ConnectionInfo ConnNfo = new ConnectionInfo("p.ceex.cz", 443, "coba",
    //            new AuthenticationMethod[]{
 
    //            // Pasword based Authentication
    //            new PasswordAuthenticationMethod("coba",".coba123"),
 
    //            // Key Based Authentication (using keys in OpenSSH Format)
    //            new PrivateKeyAuthenticationMethod("coba",new PrivateKeyFile[]{ 
    //                new PrivateKeyFile(@"..\openssh.key","passphrase")
    //            }),
    //        }
    //        );

    //        // Execute a (SHELL) Command - prepare upload directory
    //        using (var sshclient = new SshClient(ConnNfo))
    //        {
    //            sshclient.Connect();
    //            using (var cmd = sshclient.CreateCommand("mkdir -p /tmp/uploadtest && chmod +rw /tmp/uploadtest"))
    //            {
    //                cmd.Execute();
    //                Console.WriteLine("Command>" + cmd.CommandText);
    //                Console.WriteLine("Return Value = {0}", cmd.ExitStatus);
    //            }
    //            sshclient.Disconnect();
    //        }

    //        // Upload A File
    //        using (var sftp = new SftpClient(ConnNfo))
    //        {
    //            string uploadfn = "Renci.SshNet.dll";

    //            sftp.Connect();
    //            sftp.ChangeDirectory("/tmp/uploadtest");
    //            using (var uplfileStream = System.IO.File.OpenRead(uploadfn))
    //            {
    //                sftp.UploadFile(uplfileStream, uploadfn, true);
    //            }
    //            sftp.Disconnect();
    //        }

    //        // Execute (SHELL) Commands
    //        using (var sshclient = new SshClient(ConnNfo))
    //        {
    //            sshclient.Connect();

    //            // quick way to use ist, but not best practice - SshCommand is not Disposed, ExitStatus not checked...
    //            Console.WriteLine(sshclient.CreateCommand("cd /tmp && ls -lah").Execute());
    //            Console.WriteLine(sshclient.CreateCommand("pwd").Execute());
    //            Console.WriteLine(sshclient.CreateCommand("cd /tmp/uploadtest && ls -lah").Execute());
    //            sshclient.Disconnect();
    //        }
    //        Console.ReadKey();
    //    }
    //}

    //class Program
    //{

    //    public static Socket GetConnectedSocket()
    //    {
    //        Socket socket = null;
    //        var hostEntry = Dns.GetHostEntry("p.ceex.cz");

    //        foreach (var address in hostEntry.AddressList)
    //        {
    //            var ipe = new IPEndPoint(address, 6666);
    //            var tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    //            tempSocket.Connect(ipe);
    //            if (tempSocket.Connected)
    //            {
    //                socket = tempSocket;
    //                break;
    //            }
    //            else
    //            {
    //                continue;
    //            }
    //        }
    //        return socket;
    //    }




    //    static void Main(string[] args)
    //    {
    //        var socket = GetConnectedSocket();
    //        if (socket != null)
    //        {
    //            var inputStream = new System.Net.Sockets.NetworkStream(socket);
    //            var outputStream = new System.Net.Sockets.NetworkStream(socket);
    //            socket.NoDelay = true;
    //        }

    //        if (socket != null)
    //            socket.Disconnect(false);

    //    }


    //    private static void Receive(Socket client)
    //    {
    //        try
    //        {
    //            // Create the state object.
    //            StateObject state = new StateObject();
    //            state.workSocket = client;

    //            // Begin receiving the data from the remote device.
    //            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
    //                new AsyncCallback(ReceiveCallback), state);
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.ToString());
    //        }
    //    }



        


    //    public class StateObject
    //    {
    //        // Client socket.
    //        public Socket workSocket = null;
    //        // Size of receive buffer.
    //        public const int BufferSize = 256;
    //        // Receive buffer.
    //        public byte[] buffer = new byte[BufferSize];
    //        // Received data string.
    //        public StringBuilder sb = new StringBuilder();
    //    }

    //    private static void ReceiveCallback(IAsyncResult ar)
    //    {
    //        try
    //        {
    //            // Retrieve the state object and the client socket 
    //            // from the asynchronous state object.
    //            StateObject state = (StateObject)ar.AsyncState;
    //            Socket client = state.workSocket;
    //            // Read data from the remote device.
    //            int bytesRead = client.EndReceive(ar);
    //            if (bytesRead > 0)
    //            {
    //                // There might be more data, so store the data received so far.
    //                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
    //                //  Get the rest of the data.
    //                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
    //                    new AsyncCallback(ReceiveCallback), state);
    //            }
    //            else
    //            {
    //                // All the data has arrived; put it in response.
    //                if (state.sb.Length > 1)
    //                {
    //                    response = state.sb.ToString();
    //                }
    //                // Signal that all bytes have been received.
    //                receiveDone.Set();
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.ToString());
    //        }
    //    }


    //}
}
