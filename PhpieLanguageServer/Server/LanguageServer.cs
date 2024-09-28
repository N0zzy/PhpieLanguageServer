using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PhpieLanguageServer.Server;

public class LanguageServer
{
    public static int Port { protected get; set; }
    public static bool Debug { protected get; set; } = false;
    private static UdpClient _udpSocket;
    private static bool _isRunning = true;

    public static async Task Run()
    {
        _udpSocket = new UdpClient(Port); 
        Logger($"running port:{Port}");
        await ReceiveMessagesAsync();
    }
    
    public static void Stop()
    {
        _isRunning = false;
        _udpSocket.Close();
        Logger( "stopped..." );
    }
    
    public static void Logger(string message)
    {
        if (!Debug) return;
        Console.WriteLine("[PhpieLanguageServer] {0}", message);
    }

    private static async Task ReceiveMessagesAsync()
    {
        while (_isRunning)
        {
            try
            {
                UdpReceiveResult result = await _udpSocket.ReceiveAsync();
                byte[] receivedBytes = result.Buffer;
                string receivedMessage = Encoding.UTF8.GetString(receivedBytes);
                Logger($"request {result.RemoteEndPoint} {receivedMessage}");
                var kernel = new Kernel();
                kernel.Initialize(new Request(receivedMessage), new Response());
                await kernel.Send(_udpSocket, result.RemoteEndPoint);
                
            }
            catch (Exception ex)
            {
                if (_isRunning)
                {
                    Logger("error " + ex.Message);
                    Logger(ex.StackTrace);
                }
            }
        }
    }
}