namespace com.smartsheet.api
{

    using System.Collections.Generic;
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
         * Unless required by applicable law or agreed to in writing, software
         * distributed under the License is distributed on an "AS IS" BASIS,
         * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
         * See the License for the specific language governing permissions and
         * limitations under the License.
         * %[license]
         */



    using Home = com.smartsheet.api.models.Home;
    using ObjectInclusion = com.smartsheet.api.models.ObjectInclusion;

	/// <summary>
	/// <para>This interface provides methods to access Home resources.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface HomeResources
	{

		/// <summary>
		/// <para>Get a nested list of all Home objects, including sheets, workspaces and folders, and optionally reports and/or
		/// templates, as shown on the Home tab.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method:<br />
		/// GET /home</para>
		/// </summary>
		/// <param name="includes"> used to specify the optional objects to include. </param>
		/// <returns> the home resource (note that if there is no such resource, this method will throw 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Home GetHome(IEnumerable<ObjectInclusion> includes);

		/// <summary>
		/// <para>Return the HomeFolderResources object that provides access to Folder resources under home.</para>
		/// </summary>
		/// <returns> the home folder resources </returns>
		HomeFolderResources Folders();
	}

}