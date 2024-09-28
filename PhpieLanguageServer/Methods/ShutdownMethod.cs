using PhpieLanguageServer.Server;

namespace PhpieLanguageServer.Methods;

public class ShutdownMethod: BaseMethod, IMethod
{
    public void Execute()
    {
        LanguageServer.Stop();
    }
}