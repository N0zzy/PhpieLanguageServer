using PhpieLanguageServer.Analyze;
using PhpieLanguageServer.Server;

namespace PhpieLanguageServer.Methods;

public class FileMethod: BaseMethod
{
    public FileMethod()
    {
        Method = "file";
        FileAnalyze.Execute( "");
    }
}