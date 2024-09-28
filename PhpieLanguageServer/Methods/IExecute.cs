using PhpieLanguageServer.Models;

namespace PhpieLanguageServer.Methods;

public interface IMethod
{
    public void Execute();
    
    public string Result();
    
    public void SetMessage(Messages message);
}