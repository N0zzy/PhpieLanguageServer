using Newtonsoft.Json;
using PhpieLanguageServer.Models;

namespace PhpieLanguageServer.Server;

public class Request()
{
    private Messages _message;
    
    public Request(string receivedMessage) : this()
    {
        ReadMessage( receivedMessage ); 
    }
    
    private void ReadMessage(string receivedMessage)
    {
        _message = JsonConvert.DeserializeObject<Messages>(receivedMessage);
    }

    public Messages GetMessage()
    {
        return _message;
    }
}