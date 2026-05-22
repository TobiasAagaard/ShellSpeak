using System.Net;
using System.Net.Sockets;
using ShellChat_Server.Helpers;

namespace ShellChat_Server;

public class Program
{
    static readonly string version = "1.0.0";
    static readonly int port = 31377;

    public static void ReciveConnection()
    {
        TcpListener listener = new TcpListener(IPAddress.Any, port);
        listener.Start();

        string localIP = GetIpAddress.GetLocalIPAddress();
        Console.WriteLine("==================================================");
        Console.WriteLine($"         ShellChat Server v{version}");
        Console.WriteLine($"         Listening on {localIP}:{port}");
        Console.WriteLine("==================================================");
        Console.WriteLine("Waiting for incoming connections...");
    }
    public static void Main(string[] args)
    {
        ReciveConnection();
    }
   
}