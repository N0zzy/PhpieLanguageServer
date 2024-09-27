using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Pchp.CodeAnalysis;

namespace PhpieLanguageServer.Analyze;

public abstract class Analyzer
{
    public static void Execute(string code)
    {
        throw new NotImplementedException();
    }

    protected static string _phpFilePath { set; get; }
    
    protected static void Analyze(string code)
    {
        var sourceText = SourceText.From(code);
        var parseOptions = new PhpParseOptions(
            documentationMode: DocumentationMode.Diagnose,
            kind: SourceCodeKind.Script,
            languageVersion: new Version(8, 2),
            shortOpenTags: true);
        var syntaxTree = PhpSyntaxTree.ParseCode(sourceText, parseOptions, parseOptions, _phpFilePath);
        
        Diagnose( syntaxTree );
    }
    
    private static void Diagnose(PhpSyntaxTree syntaxTree)
    {
        var diagnostics = syntaxTree.GetDiagnostics();
        var errors = diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error);
        var enumerable = errors.ToList();
        foreach (var error in enumerable)
        {
            Console.WriteLine($"Error: {error.GetMessage()} at {error.Location.GetLineSpan()}");
        }
        if (!enumerable.Any())
        {
            Console.WriteLine("No errors found.");
        }
    }
}