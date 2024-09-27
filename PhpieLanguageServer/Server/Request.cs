using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using PhpieLanguageServer.Models;

namespace PhpieLanguageServer.Server;

public class Request
{
    private static RequestMessage _message;

    [UnconditionalSuppressMessage("Trimming", "IL2026:Members annotated with 'RequiresUnreferencedCodeAttribute' require dynamic access otherwise can break functionality when trimming application code", Justification = "<Pending>")]
    [UnconditionalSuppressMessage("AOT", "IL3050:Calling members annotated with 'RequiresDynamicCodeAttribute' may break functionality when AOT compiling.", Justification = "<Pending>")]
    public static void ReadMessage(string receivedMessage)
    {
        _message = JsonSerializer.Deserialize<RequestMessage>( receivedMessage );
    }

    public static RequestMessage GetRequestMessage()
    {
        return _message;
    }
}