namespace PhpieLanguageServer.Analyze;

public class FileAnalyze: Analyzer
{
    public new static void Execute(string code)
    {
        Analyze( code );
    }
}