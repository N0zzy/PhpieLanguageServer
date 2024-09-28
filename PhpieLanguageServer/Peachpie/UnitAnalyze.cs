using System;
using System.Linq;

namespace PhpieLanguageServer.Peachpie;

public static class UnitAnalyze
{
    public static void Run()
    {
        string code = @"
            echo 'hello world';
            $a = function(){};
        ";
        
        var analyze = new Analyze()
        {
            Code = code,
            File = "test.php"
        };
        var errors = analyze.Run().Diagnose().Errors;
        foreach (var error in    errors)
        {
            Console.WriteLine( error.Text );
            Console.WriteLine( error.Line );
            Console.WriteLine( error.Start );
            Console.WriteLine( error.End );
        }
    }
}