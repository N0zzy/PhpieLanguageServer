using System.Collections.Generic;
using PhpieLanguageServer.Peachpie;

namespace PhpieLanguageServer.Methods;

public static class MethodExtension
{
    public static BaseMethod SetData(this BaseMethod method, List<Errors> errors, out string data)
    {
        if (errors.Count <= 0)
        {
            data = $"\"message\":null," +
                   $"\"line\":null," +
                   $"\"start\":null," +
                   $"\"end\":null";
        }
        else
        {
            data = $"\"message\":\"{errors[0].Text}\"," +
                   $"\"line\":\"{errors[0].Line}\"," +
                   $"\"start\":\"{errors[0].Start}\"," +
                   $"\"end\":\"{errors[0].End}\"";
        }

        return method;
    }

    public static BaseMethod SetDataError(this BaseMethod method, string error, out string data)
    {
        data = $"\"message\":\"{error}\"";
        return method;
    }
}