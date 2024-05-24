using System;
using System.Security.Cryptography;

public class SecretKeyGenerator
{
    public static string GenerateSecretKey(int length)
    {
        const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var randomBytes = new byte[length];

        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(randomBytes);
        }

        var chars = new char[length];
        for (int i = 0; i < length; i++)
        {
            chars[i] = validChars[randomBytes[i] % validChars.Length];
        }

        return new string(chars);
    }
}
