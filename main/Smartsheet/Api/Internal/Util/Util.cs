//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2014 SmartsheetClient
//    %%
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//        
//            http://www.apache.org/licenses/LICENSE-2.0
//        
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using System;
using System.IO;
using System.Reflection;
using System.Runtime.Versioning;
#if !NETSTANDARD2_0
using System.Management;
#endif

namespace Smartsheet.Api.Internal.Utility
{
    public class Utility
    {
        public Utility()
        {
        }

        public static string GetOSFriendlyName()
        {
            var framework = Assembly
                .GetEntryAssembly()?
                .GetCustomAttribute<TargetFrameworkAttribute>()?
                .FrameworkName;

#if NETSTANDARD2_0
            return framework + "-" + System.Runtime.InteropServices.RuntimeInformation.OSDescription;
#else
            string result = string.Empty;
            ManagementObjectCollection.ManagementObjectEnumerator enumerator = null;

            try
            {
                enumerator = (
                        new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem")
                    ).Get()
                    .GetEnumerator();

                if (enumerator.MoveNext())
                {
                    result = ((ManagementObject)enumerator.Current)["Caption"].ToString();
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Hosted solution - Many not allow access to WMI
                return "Hosted";
            }
            catch (System.NotImplementedException)
            {
                return ".Net Core-" + System.Environment.OSVersion.VersionString;
            }
            finally
            {
                if (enumerator != null)
                {
                    ((IDisposable)enumerator).Dispose();
                }
            }
            return result + "-" + framework;
#endif
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

        public static byte[] ReadAllBytes(BinaryReader reader)
        {
            const int bufferSize = 4096;
            using (var ms = new MemoryStream())
            {
                byte[] buffer = new byte[bufferSize];
                int count;
                while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                {
                    ms.Write(buffer, 0, count);
                }
                ms.Position = 0;
                return ms.ToArray();
            }
        }
    }
}