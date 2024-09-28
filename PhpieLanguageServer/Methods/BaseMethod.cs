using PhpieLanguageServer.Models;

namespace PhpieLanguageServer.Methods;

public abstract class BaseMethod
{
    protected string Method { get; set; }
    protected bool Error { get; set; } = false;

    protected string Data { get; set; } = "";
    
    protected Messages Message { get; set; }
    
    public virtual string Result()
    {
        var error = Error ? "true" : "false";
        var data = Data.Length > 0 ? $",{Data}" : "";
        return "{" + $"\"method\":\"{Method}\",\"error\":{error}{data}"+"}";
    }

    public void SetMessage(Messages msg)
    {
        Message = msg;
        Method = Message.Method;
    }
}