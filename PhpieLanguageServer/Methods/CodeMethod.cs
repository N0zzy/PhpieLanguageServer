using PhpieLanguageServer.Peachpie;

namespace PhpieLanguageServer.Methods;

public class CodeMethod: BaseMethod, IMethod
{
    public void Execute()
    {
        var analyze = new Analyze()
        {
            Code = Message.Message,
            File = Message.File
        };
        var errors = analyze.Run().Diagnose().Errors;
        this.SetData(errors, out var data);
        Data = data;
    }
}