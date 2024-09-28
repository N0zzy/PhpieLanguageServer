using System.Threading.Tasks;
using PhpieLanguageServer.Server;

namespace PhpieLanguageServer;

public class Program {
    public static async Task Main(string[] args)
    {
        LanguageServer.Port = 9999;
        LanguageServer.Debug = true;
        await Task.Run(LanguageServer.Run);
    }
}