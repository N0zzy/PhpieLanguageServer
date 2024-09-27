using PhpieLanguageServer.Methods;

namespace PhpieLanguageServer.Server;

public class Route
{
    public static void Execute()
    {
        var message = Request.GetRequestMessage();
        BaseMethod method = null;
        switch (message.Method)
        {
            case "connect": method = new ConnectMethod(); 
                break;
            case "shutdown": method = new ShutdownMethod(); 
                break;
            case "file": method = new FileMethod(); 
                break;
            case "code": method = new CodeMethod(); 
                break;
        }
        
        Response.Add( method == null ? new ErrorMethod().Output() : method.Output() );
    }
}