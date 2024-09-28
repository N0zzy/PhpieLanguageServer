using System.Collections.Generic;

namespace PhpieLanguageServer.Peachpie;

public class Diagnose
{
    public List<Errors> Errors { get; set; } = new List<Errors>();
}