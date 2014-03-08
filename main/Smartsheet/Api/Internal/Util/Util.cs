using System;
using System.Management;

namespace Smartsheet.Api.Internal.Utility
{
    public class Utility
    {
        public Utility()
        {
        }

        public static string GetOSFriendlyName()
        {
            string result = string.Empty;
            ManagementObjectCollection.ManagementObjectEnumerator enumerator = (
                new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem")).Get().GetEnumerator();
            try
            {
                if (enumerator.MoveNext())
                {
                    result = ((ManagementObject)enumerator.Current)["Caption"].ToString();
                }
            }
            finally
            {
                if (enumerator != null)
                {
                    ((IDisposable)enumerator).Dispose();
                }
            }
            return result;
        }

	    /**
	     * Helper function that throws an IllegalArgumentException if one of the parameters is null.
	     * @param objects the paramters to 
	     */
        public static void ThrowIfNull(params object[] objects)
        {
            foreach (object obj in objects)
            {
                if (obj == null)
                {
                    throw new System.ArgumentException();
                }
            }
        }

        public static void ThrowIfEmpty(params string[] strings)
        {
            foreach (string @string in strings)
            {
                if (@string != null && @string.Length == 0)
                {
                    throw new System.ArgumentException();
                }
            }
        }
    }
}