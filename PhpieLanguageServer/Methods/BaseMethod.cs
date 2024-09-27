using PhpieLanguageServer.Models;
using PhpieLanguageServer.Server;

namespace PhpieLanguageServer.Methods;

public abstract class BaseMethod
{
    protected string Method { get; set; }
    protected bool Error { get; set; } = false;
    protected string Result { get; set; } = "";
    
    public virtual string Output()
    {
        var error = Error ? "true" : "false";
        return "{" + $"\"method\":\"{Method}\",\"error\":{error}" + Result + "}";
    }
    
    protected RequestMessage Input()
    {
        return Request.GetRequestMessage();
    }
}