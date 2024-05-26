using System;
using System.Security.Cryptography;

public static class SecretKeyGenerator
{
    public static byte[] GenerateSecretKey()
    {
        const int keySizeInBytes = 32; // 256 bits
        byte[] keyBytes = new byte[keySizeInBytes];

        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(keyBytes);
        }

        return keyBytes;
    }
}
