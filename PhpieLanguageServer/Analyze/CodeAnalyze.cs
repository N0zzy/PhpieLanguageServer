using System;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Pchp.CodeAnalysis;

namespace PhpieLanguageServer.Analyze;

public class CodeAnalyze
{
    public static void Run()
    {
        string phpCode = @"
           

            function a() -> {}
            
         
            ";

        try
        {
            var sourceText = SourceText.From(phpCode);
            var parseOptions = new PhpParseOptions(
                documentationMode: DocumentationMode.Diagnose,
                kind: SourceCodeKind.Script,
                languageVersion: new Version(8, 2),
                shortOpenTags: true);

            var syntaxTree = PhpSyntaxTree.ParseCode(sourceText, parseOptions, parseOptions, "example.php");

            // Получаем все диагностические сообщения
            var diagnostics = syntaxTree.GetDiagnostics();

            // Фильтруем только ошибки
            var errors = diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error);

            // Выводим ошибки на консоль
            var enumerable = errors.ToList();
            foreach (var error in enumerable)
            {
                Console.WriteLine($"Error: {error.GetMessage()} at {error.Location.GetLineSpan()}");
            }

            // Проверка на наличие ошибок
            if (!enumerable.Any())
            {
                Console.WriteLine("No errors found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}