namespace PhpieLanguageServer.Methods;

public class ErrorMethod: BaseMethod
{
    public override string Output()
    {
        return "{\"method\":null,\"error\":true}";
    }
}