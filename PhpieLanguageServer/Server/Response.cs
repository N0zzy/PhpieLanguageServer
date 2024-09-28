namespace PhpieLanguageServer.Server;

public class Response
{
    private string _response { get; set; }
    
    public void Set(string response)
    {
        _response = response;
    }
    
    public string Get()
    {
        return _response;
    }
}