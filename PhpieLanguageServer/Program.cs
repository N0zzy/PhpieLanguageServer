using System.Threading.Tasks;

namespace PhpieLanguageServer;

public class Program {
    public static async Task Main(string[] args)
    {
        UdpServer.Ip = "127.0.0.1";
        UdpServer.Port = 9999;
        await Task.Run(UdpServer.Run);
    }
}