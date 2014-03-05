using System.Collections.Generic;

namespace Smartsheet.Api.Internal
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

	using Folder = Api.Models.Folder;

	/// <summary>
	/// This is the implementation of the FolderResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class FolderResourcesImpl : AbstractResources, FolderResources
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Parameters: - Smartsheet : the SmartsheetImpl
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param Name="Smartsheet"> the Smartsheet </param>
		public FolderResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		/// Get a folder.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /folder/{Id}
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param Name="folderId"> the folder Id </param>
		/// <returns> the folder (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null) </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Folder GetFolder(long folderId)
		{
			return this.GetResource<Folder>("folder/" + folderId, typeof(Folder));
		}

		/// <summary>
		/// Update a folder.
		/// 
		/// It mirrors To the following Smartsheet REST API method: PUT /folder/{Id}
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if folder is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param Name="folder"> the folder To update </param>
		/// <returns> the updated folder (note that if there is no such folder, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Folder UpdateFolder(Folder folder)
		{

			return this.UpdateResource<Folder>("folder/" + folder.ID, typeof(Folder), folder);
		}

		/// <summary>
		/// Delete a folder.
		/// 
		/// It mirrors To the following Smartsheet REST API method: DELETE /folder{Id}
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param Name="folderId"> the folder Id </param>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual void DeleteFolder(long folderId)
		{

			this.DeleteResource<Folder>("folder/" + folderId, typeof(Folder));
		}

		/// <summary>
		/// List child Folders of a given folder.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /folder/{Id}/Folders
		/// 
		/// Parameters: - parentFolderId : the parent folder ID
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param Name="parentFolderId"> the parent folder Id </param>
		/// <returns> the child Folders (note that empty list will be returned if no child folder found) </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual IList<Folder> ListFolders(long parentFolderId)
		{

			return this.ListResources<Folder>("folder/" + parentFolderId + "/folders", typeof(Folder));
		}

		/// <summary>
		/// Create a folder.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /folder/{Id}/Folders
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if folder is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param Name="parentFolderId"> the parent folder Id </param>
		/// <param Name="folder"> the folder To create </param>
		/// <returns> the folder </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Folder CreateFolder(long parentFolderId, Folder folder)
		{

			return this.CreateResource<Folder>("folder/" + parentFolderId + "/folders", typeof(Folder), folder);
		}
	}

}