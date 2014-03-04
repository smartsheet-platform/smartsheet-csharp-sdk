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
	/// This is the implementation of the FolderResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class FolderResourcesImpl : AbstractResources, FolderResources
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Parameters: - smartsheet : the SmartsheetImpl
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the smartsheet </param>
		public FolderResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		/// Get a folder.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /folder/{id}
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="folderId"> the folder id </param>
		/// <returns> the folder (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null) </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Folder GetFolder(long folderId)
		{
			return this.GetResource<Folder>("folder/" + folderId, typeof(Folder));
		}

		/// <summary>
		/// Update a folder.
		/// 
		/// It mirrors to the following Smartsheet REST API method: PUT /folder/{id}
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if folder is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="folder"> the folder to update </param>
		/// <returns> the updated folder (note that if there is no such folder, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Folder UpdateFolder(Folder folder)
		{

			return this.UpdateResource<Folder>("folder/" + folder.id, typeof(Folder), folder);
		}

		/// <summary>
		/// Delete a folder.
		/// 
		/// It mirrors to the following Smartsheet REST API method: DELETE /folder{id}
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="folderId"> the folder id </param>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual void DeleteFolder(long folderId)
		{

			this.DeleteResource<Folder>("folder/" + folderId, typeof(Folder));
		}

		/// <summary>
		/// List child folders of a given folder.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /folder/{id}/folders
		/// 
		/// Parameters: - parentFolderId : the parent folder ID
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="parentFolderId"> the parent folder id </param>
		/// <returns> the child folders (note that empty list will be returned if no child folder found) </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual IList<Folder> ListFolders(long parentFolderId)
		{

			return this.ListResources<Folder>("folder/" + parentFolderId + "/folders", typeof(Folder));
		}

		/// <summary>
		/// Create a folder.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /folder/{id}/folders
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if folder is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="parentFolderId"> the parent folder id </param>
		/// <param name="folder"> the folder to create </param>
		/// <returns> the folder </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Folder CreateFolder(long parentFolderId, Folder folder)
		{

			return this.CreateResource<Folder>("folder/" + parentFolderId + "/folders", typeof(Folder), folder);
		}
	}

}