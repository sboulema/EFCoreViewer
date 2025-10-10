using System.IO;
using System.Text;

namespace IQueryableObjectSource;

static class StreamExtensions
{
    public static void WriteError(this Stream outgoingData, string errorMessage)
    {
        using var writer = new BinaryWriter(outgoingData, Encoding.Default, true);
        writer.Write(true);
        writer.Write(errorMessage);
    }

    public static void WriteSuccess(this Stream outgoingData, string data)
    {
        using var writer = new BinaryWriter(outgoingData, Encoding.Default, true);
        writer.Write(false);
        writer.Write(data);
    }
}
