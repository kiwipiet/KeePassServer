using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace KeePassServer.Core
{
    public static class SecureStringEx
    {
        public static byte[] ToByteArray(this SecureString secureString, Encoding encoding = null)
        {
            if (secureString == null)
            {
                throw new ArgumentNullException(nameof(secureString));
            }

            encoding = encoding ?? Encoding.UTF8;

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = CreateString(secureString);

                if (unmanagedString != IntPtr.Zero)
                {
                    return encoding.GetBytes(Marshal.PtrToStringBSTR(unmanagedString));
                }
                return Array.Empty<byte>();
            }
            finally
            {
                if (unmanagedString != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(unmanagedString);
                }
            }
        }
        internal static IntPtr CreateString(SecureString secureString)
        {
            IntPtr num = IntPtr.Zero;
            if (secureString != null)
            {
                if (secureString.Length != 0)
                {
                    num = Marshal.SecureStringToBSTR(secureString);
                }
            }
            return num;
        }
    }
}
