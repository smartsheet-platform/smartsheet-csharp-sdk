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

using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using Api.Models;
	using System.Text;

	/// <summary>
	/// This is the implementation of the HomeFolderResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class HomeFolderResourcesImpl : AbstractResources, HomeFolderResources
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		/// <exception cref="IllegalArgumentException">if any argument is null</exception>
		public HomeFolderResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
		}

		/// <summary>
		/// <para>List Folders under home.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// GET /home/Folders</para>
		/// </summary>
		/// <returns> the list of Folders (note that an empty list will be returned if there is none) </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual PaginatedResult<Folder> ListFolders(PaginationParameters paging)
		{
			StringBuilder path = new StringBuilder("home/folders");
			if (paging != null)
			{
				path.Append(paging.ToQueryString());
			}
			return ListResourcesWithWrapper<Folder>(path.ToString());
		}

		/// <summary>
		/// <para>Create a folder in home.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method:<br />
		/// POST /home/Folders</para>
		/// </summary>
		/// <param name="folder"> the folder To create </param>
		/// <returns> the folder </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Folder CreateFolder(Folder folder)
		{
			return this.CreateResource<Folder>("home/folders", typeof(Folder), folder);
		}
	}
}