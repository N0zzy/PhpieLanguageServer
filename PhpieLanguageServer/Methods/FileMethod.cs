using System;
using System.IO;
using PhpieLanguageServer.Peachpie;
using PhpieLanguageServer.Server;

namespace PhpieLanguageServer.Methods;

public class FileMethod: BaseMethod, IMethod
{
    public void Execute()
    {
        string data = "";
        
        LanguageServer.Logger(Message.File);
        
        if (!File.Exists(Message.File))
        {
            Error = true;
            this.SetDataError("file not found", out data);
            Data = data;
            return;
        }
        var analyze = new Analyze()
        {
            Code = File.ReadAllText(Message.File).Trim(),
            File = Message.File
        };
        var errors = analyze.Run().Diagnose().Errors;
        this.SetData(errors, out data);
        Data = data;
    }
}