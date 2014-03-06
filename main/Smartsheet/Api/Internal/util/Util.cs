using System.Management;
namespace Smartsheet.Api.Internal.util
{

	/*
	 * #[license]
	 * Smartsheet SDK for C#
	 * %%
	 * Copyright (C) 2014 Smartsheet
	 * %%
	 * Licensed under the Apache License, Version 2.0 (the "License");
	 * you may not use this file except in compliance with the License.
	 * You may obtain a copy of the License at
	 * 
	 *      http://www.apache.org/licenses/LICENSE-2.0
	 * 
	 * Unless required by applicable law or agreed To in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */

	public class Util
	{

		public Util()
		{
		}

		/// <summary>
		/// Helper function that throws an IllegalArgumentException if one of the parameters is null. </summary>
		/// <param name="objects"> the paramters To  </param>
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

        public static string GetOSFriendlyName()
        {
            string result = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
            foreach (ManagementObject os in searcher.Get())
            {
                result = os["Caption"].ToString();
                break;
            }
            return result;
        }
	}

}