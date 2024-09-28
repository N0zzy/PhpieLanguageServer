namespace PhpieLanguageServer.Methods;

public class ErrorMethod: BaseMethod, IMethod
{
    public override string Result()
    {
        return "{\"method\":null, \"error\":true, \"message\":\"method not found\"}";
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}