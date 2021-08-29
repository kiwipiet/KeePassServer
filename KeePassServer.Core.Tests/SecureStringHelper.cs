using System;
using System.Runtime.InteropServices;
using System.Security;

namespace KeePassServer.Core.Tests
{
    /// <summary>
    ///     NB! Do not use this in production code!
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    internal static class SecureStringHelper
    {
        internal static string CreateString(SecureString secureString)
        {
            IntPtr num = IntPtr.Zero;
            if (secureString != null)
            {
                if (secureString.Length != 0)
                {
                    try
                    {
                        num = Marshal.SecureStringToBSTR(secureString);
                        return Marshal.PtrToStringBSTR(num);
                    }
                    finally
                    {
                        if (num != IntPtr.Zero)
                            Marshal.ZeroFreeBSTR(num);
                    }
                }
            }
            return string.Empty;
        }

        internal static SecureString CreateSecureString(string plainString)
        {
            switch (plainString)
            {
                case "":
                case null:
                    return new SecureString();
                default:
                    SecureString secureString = new SecureString();
                    foreach (char c in plainString)
                    {
                        secureString.AppendChar(c);
                    }
                    return secureString;
            }
        }
    }
}
