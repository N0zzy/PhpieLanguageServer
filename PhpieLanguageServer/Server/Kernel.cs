using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using PhpieLanguageServer.Methods;
using static PhpieLanguageServer.Server.LanguageServer;

namespace PhpieLanguageServer.Server;

public class Kernel
{
    private Response Response { get; set; }
    private Request Request { get; set; }


    public Kernel()
    {
        /// initialize main kernel
    }
    
    public void Initialize(Request request, Response response)
    {
        Response = response;
        Request = request;
        Routing();
    }
    

    private void Routing()
    {
        var message = Request.GetMessage();
        IMethod method = null;
        switch (message.Method)
        {
            case Method.Connect:
                method = new ConnectMethod(); 
                break;
            case Method.Shutdown: 
                method = new ShutdownMethod(); 
                break;
            case Method.File: 
                method = new FileMethod(); 
                break;
            case Method.Code :
                method = new CodeMethod();
                break;
        }

        if (method == null)
        {
            Response.Set(new ErrorMethod().Result());
        }
        else
        {
            method.SetMessage(message);
            method.Execute();
            Response.Set(method.Result());
        }
    }

    public async Task Send(UdpClient udpSocket, IPEndPoint resultRemoteEndPoint)
    {
        Logger($"response {Response.Get()}");
        byte[] responseBytes = Encoding.UTF8.GetBytes(Response.Get());
        await udpSocket.SendAsync(responseBytes, responseBytes.Length, resultRemoteEndPoint);
    }
}