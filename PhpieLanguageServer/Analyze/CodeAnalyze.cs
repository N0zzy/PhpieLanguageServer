﻿namespace PhpieLanguageServer.Analyze;

public class CodeAnalyze: Analyzer
{
    public new static void Execute(string code)
    {
        Analyze(code);
    }
}