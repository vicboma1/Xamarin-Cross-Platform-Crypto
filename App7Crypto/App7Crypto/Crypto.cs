using PCLCrypto;
using static PCLCrypto.WinRTCrypto;
using System.Text;
using System;
using System.IO;

namespace Crypto
{
    public static class Crypto
    {

        //Esto debe de ser un valor accesible encriptado con una xor
        private static string key = "&%$€@Ññ";

        private static byte[] GetBytesPassword(string str, int bufferInBytes = 16, int keyLengthInBytes = 32, int iterations = 1000)
        {
            var buffer = WinRTCrypto.CryptographicBuffer.GenerateRandom(bufferInBytes);
            return NetFxCrypto.DeriveBytes.GetBytes(str, buffer, iterations, keyLengthInBytes);
        }

        private static string ToCryto(this string data)
        {
            var result = new StringBuilder();

            for (int c = 0; c < data.Length; c++)
                result.Append((char)((uint)data[c] ^ (uint)key[c % key.Length]));

            return result.ToString();
        }

        public static string ToStringEncrypt(this string data) => data.ToCryto();
        
        public static byte [] ToByteEncrypt(this string data) => Encoding.UTF8.GetBytes(data.ToCryto());

        public static string ToByteEncrypt(this byte[] data) => Encoding.UTF8.GetString(data,0 ,data.Length).ToStringEncrypt();

    }
}
