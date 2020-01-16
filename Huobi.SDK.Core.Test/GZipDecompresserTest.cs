using Huobi.SDK.Core.Client.WebSocketClientBase;
using Xunit;

namespace Huobi.SDK.Core.Test
{
    public class GZipDecompresserTest
    {
        [Fact]
        public void Decompress_Success()
        {
            byte[] compressed = GZipDecompresser.Compress("Huobi");

            string origin = GZipDecompresser.Decompress(compressed);

            Assert.Equal("Huobi", origin);
        }
    }
}
