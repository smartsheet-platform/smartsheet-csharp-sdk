using System.Collections.Generic;

namespace com.smartsheet.api.@internal
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
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */



	using Folder = com.smartsheet.api.models.Folder;

	/// <summary>
	/// This is the implementation of the HomeFolderResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class HomeFolderResourcesImpl : AbstractResources, HomeFolderResources
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the smartsheet </param>
		public HomeFolderResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		/// List folders under home.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /home/folders
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <returns> the folders (note that empty list will be returned if there is none) </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual IList<Folder> ListFolders()
		{
			return this.ListResources<Folder>("home/folders", typeof(Folder));
		}

		/// <summary>
		/// Create a folder in home.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /home/folders
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if folder is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="folder"> the folder to create </param>
		/// <returns> the created folder </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Folder CreateFolder(Folder folder)
		{
			return this.CreateResource<Folder>("home/folders", typeof(Folder), folder);
		}
	}

}