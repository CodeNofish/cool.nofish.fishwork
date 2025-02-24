using System.IO;
using System.IO.Compression;

namespace Fishwork.Serialize {

  public static class CompressUtil {
    #region GZip 
    public static byte[] GZipCompress(byte[] data) {
      using var compressedStream = new MemoryStream();
      using var gzipStream = new GZipStream(compressedStream, CompressionMode.Compress);
      gzipStream.Write(data, 0, data.Length);
      return compressedStream.ToArray();
    }

    public static byte[] GZipDecompress(byte[] data) {
      using var compressedStream = new MemoryStream(data);
      using var gzipStream = new GZipStream(compressedStream, CompressionMode.Decompress);
      using var decompressedStream = new MemoryStream();
      gzipStream.CopyTo(decompressedStream);
      return decompressedStream.ToArray();
    }
    #endregion
    
    #region Brotli
    public static byte[] BrotliCompress(byte[] data) {
      using var memoryStream = new MemoryStream();
      using var brotliStream = new BrotliStream(memoryStream, CompressionMode.Compress);
      brotliStream.Write(data, 0, data.Length);
      return memoryStream.ToArray();
    }

    public static byte[] BrotliDecompress(byte[] data) {
      using var memoryStream = new MemoryStream(data);
      using var brotliStream = new BrotliStream(memoryStream, CompressionMode.Decompress);
      using var decompressedStream = new MemoryStream();
      brotliStream.CopyTo(decompressedStream);
      return decompressedStream.ToArray();
    }
    #endregion

    #region Deflate
    public static byte[] DeflateCompress(byte[] data) {
      using var memoryStream = new MemoryStream();
      using var deflateStream = new DeflateStream(memoryStream, CompressionMode.Compress);
      deflateStream.Write(data, 0, data.Length);
      return memoryStream.ToArray();
    }

    public static byte[] DeflateDecompress(byte[] data) {
      using var memoryStream = new MemoryStream(data);
      using var deflateStream = new DeflateStream(memoryStream, CompressionMode.Decompress);
      using var decompressedStream = new MemoryStream();
      deflateStream.CopyTo(decompressedStream);
      return decompressedStream.ToArray();
    }
    #endregion
  }

}
