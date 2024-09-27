using System.Text.Json;

namespace PhpieLanguageServer.Server;

public class Response
{
    private static string _message;
    
    public static void Add(string message)
    {
        _message = message;
    }
    
    public static string Get()
    {
        return _message;
    }
}