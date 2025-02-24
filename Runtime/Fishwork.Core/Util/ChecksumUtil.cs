namespace Fishwork.Core {

  /// <summary>
  /// <para>校验和算法</para>
  /// <para>固定长度输出：校验和算法的输出通常是一个固定长度的值（如 8 位、16 位、32 位等）</para>
  /// <para>快速计算：校验和算法的计算速度通常很快，适合实时校验</para>
  /// <para>错误检测：主要用于检测数据中的错误（如比特翻转、数据丢失等），而不是加密或验证数据的真实性</para>
  /// <para>非加密性：校验和算法通常不具备加密性质，不能用于防止恶意篡改</para>
  /// </summary>
  public static class ChecksumUtil {
    /// <summary>
    /// 计算 简单 校验和
    /// </summary>
    public static byte ComputeSimple(byte[] data) {
      byte checksum = 0;
      foreach (var b in data)
        checksum += b;
      return checksum;
    }

    /// <summary>
    /// 计算 CRC-32 校验和
    /// </summary>
    public static uint ComputeCRC32(byte[] data) {
      return CyclicRedundancyCheck32.ComputeCrc32(data);
    }

    /// <summary>
    /// 计算 Fletcher-16 校验和
    /// </summary>
    public static ushort ComputeFletcher16(byte[] data) {
      return FletcherChecksum.ComputeFletcher16(data);
    }

    /// <summary>
    /// 计算 Fletcher-32 校验和
    /// </summary>
    public static uint ComputeFletcher32(byte[] data) {
      return FletcherChecksum.ComputeFletcher32(data);
    }
  }

  /// <summary>
  /// CRC32实现
  /// </summary>
  public static class CyclicRedundancyCheck32 {
    private static readonly uint[] CrcTable;

    static CyclicRedundancyCheck32() {
      const uint polynomial = 0xEDB88320;
      CrcTable = new uint[256];
      for (uint i = 0; i < 256; i++) {
        uint crc = i;
        for (int j = 8; j > 0; j--) {
          if ((crc & 1) == 1)
            crc = (crc >> 1) ^ polynomial;
          else
            crc >>= 1;
        }
        CrcTable[i] = crc;
      }
    }

    public static uint ComputeCrc32(byte[] data) {
      uint crc32 = 0xFFFFFFFF;
      foreach (byte b in data)
        crc32 = (crc32 >> 8) ^ CrcTable[(crc32 & 0xFF) ^ b];
      return ~crc32;
    }
  }

  /// <summary>
  /// Fletcher实现
  /// </summary>
  public static class FletcherChecksum {
    /// <summary>
    /// 计算 Fletcher-16 校验和
    /// </summary>
    public static ushort ComputeFletcher16(byte[] data) {
      ushort sum1 = 0;
      ushort sum2 = 0;
      foreach (byte b in data) {
        sum1 = (ushort)((sum1 + b) % 255);
        sum2 = (ushort)((sum2 + sum1) % 255);
      }
      return (ushort)((sum2 << 8) | sum1);
    }

    /// <summary>
    /// 计算 Fletcher-32 校验和
    /// </summary>
    public static uint ComputeFletcher32(byte[] data) {
      uint sum1 = 0;
      uint sum2 = 0;
      foreach (byte b in data) {
        sum1 = (sum1 + b) % 65535;
        sum2 = (sum2 + sum1) % 65535;
      }
      return (sum2 << 16) | sum1;
    }
  }


  /// <summary>
  /// 模10算法实现。
  /// 是一种用于验证数字（如信用卡号、身份证号）的校验和算法。
  /// 它通过计算数字的校验位来检测输入是否有效。
  /// </summary>
  public static class LuhnChecksum {
    /// <summary>
    /// 计算 Luhn 校验和
    /// </summary>
    public static int CalculateLuhnChecksum(string number) {
      int sum = 0;
      bool isEvenPosition = false;

      // 从右到左遍历每一位
      for (int i = number.Length - 1; i >= 0; i--) {
        int digit = number[i] - '0'; // 将字符转换为数字
        if (isEvenPosition) {
          digit *= 2; // 偶数位乘以 2
          if (digit > 9) {
            digit = digit - 9; // 如果结果大于 9，则减去 9
          }
        }
        sum += digit; // 累加到总和
        isEvenPosition = !isEvenPosition; // 切换位置标志
      }
      return sum;
    }

    // 验证数字是否有效
    public static bool ValidateLuhnNumber(string number) {
      int checksum = CalculateLuhnChecksum(number);
      return checksum % 10 == 0; // 校验和是否为 10 的倍数
    }

    // 计算校验位
    public static int CalculateCheckDigit(string number) {
      int checksum = CalculateLuhnChecksum(number + "0"); // 在原数字后补 0
      int checkDigit = (10 - (checksum % 10)) % 10; // 计算校验位
      return checkDigit;
    }
  }

}
