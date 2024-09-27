using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using PhpieLanguageServer.Server;

public class UdpServer
{
    public static string Ip = "127.0.0.1";
    public static ushort Port = 9999;
    private static UdpClient _udpSocket;
    private static IPEndPoint _remoteEndPoint;
    private static bool _isRunning = true;

    public static async Task Run()
    {
        _udpSocket = new UdpClient(Port);
        Logger($"running port:{Port}");

        await ReceiveMessagesAsync();
    }

    private static async Task ReceiveMessagesAsync()
    {
        while (_isRunning)
        {
            try
            {
                UdpReceiveResult result = await _udpSocket.ReceiveAsync();
                byte[] receivedBytes = result.Buffer;
                IPEndPoint _remoteEndPoint = result.RemoteEndPoint;

                string receivedMessage = Encoding.UTF8.GetString(receivedBytes);
                Request.ReadMessage( receivedMessage );
                Route.Execute();
                byte[] responseBytes = Encoding.UTF8.GetBytes(Response.Get());
                await _udpSocket.SendAsync(responseBytes, responseBytes.Length, _remoteEndPoint);
                Logger($"message {_remoteEndPoint} {receivedMessage}");
            }
            catch (Exception ex)
            {
                if (_isRunning)
                {
                    Logger( "error " + ex.Message );
                }
            }
        }
    }

    public static void Stop()
    {
        _isRunning = false;
        _udpSocket.Close();
        Logger( "stopped..." );
    }

    public static void Logger(string message)
    {
        Console.WriteLine("[PhpieLanguageServer] {0}", message);
    }
}