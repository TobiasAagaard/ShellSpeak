using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace ShellSpeak_Server.Helpers;

public static class GetIpAddress
{
    public static string GetLocalIPAddress()
    {
        try
        {
            // We are looking for a network interface that is up and is not a loopback interface
            foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (netInterface.OperationalStatus == OperationalStatus.Up && 
                    netInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    // Get the IP properties of the network interface
                    var ipProps = netInterface.GetIPProperties();

                    // Look for an IPv4 address in the unicast addresses
                    foreach (var addr in ipProps.UnicastAddresses)
                    {
                        if (addr.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            return addr.Address.ToString();
                        }
                    }
                }
            }

        // Catch any exceptions that may occur during the retrieval of the IP address
        } catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving local IP address: {ex.Message}");
        }
        return "127.0.0.1"; // Fallback to localhost if no IP address is found
    }
}