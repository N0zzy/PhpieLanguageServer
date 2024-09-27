using PhpieLanguageServer.Analyze;

namespace PhpieLanguageServer.Methods;

public class CodeMethod: BaseMethod
{
    public CodeMethod()
    {
        Method = "code";
        CodeAnalyze.Execute( "");
    }
}