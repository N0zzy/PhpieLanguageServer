using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Pchp.CodeAnalysis;

namespace PhpieLanguageServer.Peachpie;

public class Analyze
{
    public string Code { get; set; }
    public string File { get; set; }
    
    private PhpSyntaxTree _syntaxTree;
    
    public Analyze Run()
    {
        string pattern = @"^\s*" + Regex.Escape("<?php");
        Code = Regex.Replace(Code, pattern, string.Empty);
        var sourceText = SourceText.From(Code);
        var parseOptions = new PhpParseOptions(
            documentationMode: DocumentationMode.Diagnose,
            kind: SourceCodeKind.Script,
            languageVersion: new Version(8, 2),
            shortOpenTags: true);
        _syntaxTree = PhpSyntaxTree.ParseCode(sourceText, parseOptions, parseOptions, File);
        return this;
    }
    
    public Diagnose Diagnose()
    {
        var diagnose = new Diagnose();
        if( _syntaxTree == null ) return diagnose;
        var diagnostics = _syntaxTree.GetDiagnostics();
        var errors = diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error);
        var enumerable = errors.ToList();
        List<Errors> errorsList = new List<Errors>();
        foreach (var error in enumerable)
        {
            var span = error.Location.GetLineSpan().Span;
            errorsList.Add(new Errors()
            {
                Text = error.GetMessage(),
                Line = span.Start.Line,
                Start = span.Start.Line + "-" + span.Start.Character,
                End = span.End.Line + "-" + span.End.Character,
            });
        }
        if (errorsList.Count > 0)
        {
            diagnose.Errors = errorsList;
        }
        return diagnose;
    }
}