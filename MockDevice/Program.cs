using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MockDevice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TcpListener server = null;

            try
            {
                server = new TcpListener(IPAddress.Any, 13175);
                server.Start();
                while (true)
                {
                    Console.WriteLine("Waiting for connection...");
                    var client = server.AcceptTcpClient();
                    Console.WriteLine("Client connected...");
                    var stream = client.GetStream();


                    var incomingBytes = new byte[256];
                    var numberOfBytesRead = stream.Read(incomingBytes, 0, incomingBytes.Length);
                    while (numberOfBytesRead != 0)
                    {
                        var incomingData = Encoding.ASCII.GetString(incomingBytes, 0, numberOfBytesRead);
                        Console.WriteLine($"Data from client: {incomingData}");
                        var outgoingBytes = Encoding.ASCII.GetBytes("~OUTPUT,2,1,48<CR><LF>");
                        stream.Write(outgoingBytes, 0, outgoingBytes.Length);          
                        numberOfBytesRead = stream.Read(incomingBytes, 0, incomingBytes.Length);
                        Console.WriteLine("Bytes read...");
                    }
                    client.Close();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                server?.Stop();
            }
        }
    }
}