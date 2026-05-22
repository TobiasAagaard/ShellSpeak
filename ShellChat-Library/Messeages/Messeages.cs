using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ShellChat_Library.Messeages
{
    public class Messeages
    {
        public static class Messeage
        {
            
            public static string ReciveMesseage(TcpClient client)
            {
                Stream stream = client.GetStream();
                byte[] header = new byte[4];
                ReadExactly(stream, header, 0, header.Length);
                int messageLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(header, 0));
                if (messageLength < 0)
                    throw new InvalidDataException($"Invalid message length: {messageLength}");

                byte[] buffer = new byte[messageLength];
                ReadExactly(stream, buffer, 0, messageLength);
                return Encoding.UTF8.GetString(buffer, 0, messageLength);
            }
            private static void ReadExactly(Stream stream, byte[] buffer, int offset, int count)
            {
                int total = 0;
                while (total < count)
                {
                    int read = stream.Read(buffer, offset + total, count - total);
                    if (read == 0)
                        throw new EndOfStreamException("Socket closed before full message was received.");
                    total += read;
                }
            }
        }
    }
}