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
//    Unless required by applicable law or agreed To in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

namespace Smartsheet.Api.Internal
{

	using Smartsheet.Api.Internal.Util;
	using Smartsheet.Api.Models;
	using System.Collections.Generic;
	using System.Text;
	using Home = Api.Models.Home;
	using ObjectInclusion = Api.Models.ObjectInclusion;

	/// <summary>
	/// This is the implementation of the HomeResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class HomeResourcesImpl : AbstractResources, HomeResources
	{
		/// <summary>
		/// Represents the HomeFolderResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private HomeFolderResources folders;

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public HomeResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
			this.folders = new HomeFolderResourcesImpl(smartsheet);
		}

		/// <summary>
		/// <para>
		/// Get a nested list of all Home objects, including Sheets, Workspaces and Folders, and optionally reports and/or
		/// Templates, as shown on the Home tab..
		/// </para>
		/// <para>
		/// It mirrors To the following Smartsheet REST API method: GET /home
		/// </para>
		/// </summary>
		/// <param name="includes"> used To specify the optional objects To include, currently TEMPLATES is supported. </param>
		/// <exception cref="InvalidRequestException">if there is any problem with the REST API request</exception>
		/// <exception cref="AuthorizationException">if there is any problem with the REST API authorization(access token)</exception>
		/// <exception cref="InvalidRequestException">if the resource can not be found</exception>
		/// <exception cref="ResourceNotFoundException">if the REST API service is not available (possibly due To rate limiting)</exception>
		/// <exception cref="ServiceUnavailableException">if there is any other REST API related error occurred during the operation</exception>
		/// <exception cref="SmartsheetException">if there is any other error occurred during the operation</exception>
		/// <returns> the resource (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null). </returns>
		public virtual Home GetHome(IEnumerable<SourceInclusion> includes)
		{
			StringBuilder path = new StringBuilder("home");
			if (includes != null)
			{
				path.Append("?include=" + QueryUtil.GenerateCommaSeparatedList<SourceInclusion>(includes));
			}
			return this.GetResource<Home>(path.ToString(), typeof(Home));
		}

		/// <summary>
		/// Return the HomeFolderResources object that provides access To Folder resources under home.
		/// </summary>
		/// <returns> the home folder resources </returns>
		public virtual HomeFolderResources FolderResources()
		{
			return this.folders;
		}


	}

}