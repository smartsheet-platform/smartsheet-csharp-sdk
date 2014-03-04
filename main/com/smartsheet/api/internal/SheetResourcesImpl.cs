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


	using HttpMethod = com.smartsheet.api.@internal.http.HttpMethod;
	using HttpRequest = com.smartsheet.api.@internal.http.HttpRequest;
	using Util = com.smartsheet.api.@internal.util.Util;
	using ObjectInclusion = com.smartsheet.api.models.ObjectInclusion;
	using PaperSize = com.smartsheet.api.models.PaperSize;
	using Sheet = com.smartsheet.api.models.Sheet;
	using SheetEmail = com.smartsheet.api.models.SheetEmail;
	using SheetPublish = com.smartsheet.api.models.SheetPublish;
    using System.IO;
    using System.Net;
    using System;

	/// <summary>
	/// This is the implementation of the SheetResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class SheetResourcesImpl : AbstractResources, SheetResources
	{

		/// <summary>
		/// The Constant BUFFER_SIZE. </summary>
		private const int BUFFER_SIZE = 4098;

		/// <summary>
		/// Represents the ShareResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private ShareResources shares;
		/// <summary>
		/// Represents the SheetRowResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private SheetRowResources rows;
		/// <summary>
		/// Represents the SheetColumnResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private SheetColumnResources columns;
		/// <summary>
		/// Represents the AssociatedAttachmentResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private AssociatedAttachmentResources attachments;
		/// <summary>
		/// Represents the AssociatedDiscussionResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private AssociatedDiscussionResources discussions;

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the smartsheet </param>
		public SheetResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
			this.shares = new ShareResourcesImpl(smartsheet, "sheet");
			this.rows = new SheetRowResourcesImpl(smartsheet);
			this.columns = new SheetColumnResourcesImpl(smartsheet);
			this.attachments = new AssociatedAttachmentResourcesImpl(smartsheet, "sheet");
			this.discussions = new AssociatedDiscussionResourcesImpl(smartsheet, "sheet");
		}

		/// <summary>
		/// List all sheets.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /sheets
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <returns> all sheets (note that empty list will be returned if there is none) </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual IList<Sheet> ListSheets()
		{
			return this.ListResources<Sheet>("sheets", typeof(Sheet));
		}

		/// <summary>
		/// List all sheets in the organization.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /users/sheets
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <returns> all sheets (note that empty list will be returned if there is none) </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual IList<Sheet> ListOrganizationSheets()
		{
			return this.ListResources<Sheet>("users/sheets", typeof(Sheet));
		}

		/// <summary>
		/// Get a sheet.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /sheet/{id} 
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the id </param>
		/// <param name="includes"> used to specify the optional objects to include, currently DISCUSSIONS and
		/// ATTACHMENTS are supported. </param>
		/// <returns> the resource (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Sheet GetSheet(long id, IEnumerable<ObjectInclusion> includes)
		{
			string path = "sheet/" + id;
			if (includes != null)
			{
				path += "?include=";
				foreach (ObjectInclusion oi in includes)
				{
					path += oi.ToString().ToLower() + ",";
				}
			}

			return this.GetResource<Sheet>(path, typeof(Sheet));
		}

		/// <summary>
		/// Get a sheet as an Excel file.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /sheet/{id} with "application/vnd.ms-excel" Accept
		/// HTTP header 
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if outputStream is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the id </param>
		/// <param name="outputStream"> the OutputStream to which the Excel file will be written </param>
		/// <returns> the sheet as excel </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual void GetSheetAsExcel(long id, StreamWriter outputStream)
		{
			GetSheetAsFile(id, null, outputStream, "application/vnd.ms-excel");
		}

		/// <summary>
		/// Get a sheet as a PDF file.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /sheet/{id} with "application/pdf" Accept HTTP 
		/// header
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if outputStream is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the id </param>
		/// <param name="outputStream"> the output stream to which the PDF file will be written. </param>
		/// <param name="paperSize"> the optional paper size </param>
		/// <returns> the sheet as pdf </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual void GetSheetAsPDF(long id, StreamWriter outputStream, PaperSize? paperSize)
		{
			GetSheetAsFile(id, paperSize, outputStream, "application/pdf");
		}

		/// <summary>
		/// Create a sheet in default "Sheets" collection.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /sheets 
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="sheet"> the sheet to create, limited to the following required attributes: * name (string) *
		/// columns (array of Column objects, limited to the following attributes) - title - primary - type - symbol -
		/// options </param>
		/// <returns> the created sheet </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Sheet CreateSheet(Sheet sheet)
		{
			return this.CreateResource("sheets", typeof(Sheet), sheet);
		}

		/// <summary>
		/// Create a sheet (from existing sheet or template) in default "Sheets" collection.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /sheets 
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request 
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="sheet"> the sheet to create, limited to the following required attributes: * name (string) * fromId
		/// (number): ID of the Sheet or Template from which to create the sheet. </param>
		/// <param name="includes"> used to specify the optional objects to include, currently DATA, DISCUSSIONS and ATTACHMENTS are 
		/// supported. </param>
		/// <returns> the sheet </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Sheet CreateSheetFromExisting(Sheet sheet, IEnumerable<ObjectInclusion> includes)
		{
			string path = "sheets";
			if (includes != null)
			{
				path += "?include=";
				foreach (ObjectInclusion oi in includes)
				{
					path += oi.ToString().ToLower() + ",";
				}
			}
			return this.CreateResource(path, typeof(Sheet), sheet);
		}

		/// <summary>
		/// Create a sheet in given folder.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /folder/{folderId}/sheets
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="folderId"> the folder id </param>
		/// <param name="sheet"> the sheet to create, limited to the following required
		/// attributes: * name (string) * columns (array of Column objects, limited to the following attributes) - title -
		/// primary - type - symbol - options </param>
		/// <returns> the created sheet </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Sheet CreateSheetInFolder(long folderId, Sheet sheet)
		{

			return this.CreateResource("folder/" + folderId + "/sheets", typeof(Sheet), sheet);
		}

		/// <summary>
		/// Create a sheet in given folder.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /folder/{folderId}/sheets 
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="folderId"> the folder id </param>
		/// <param name="sheet"> the sheet </param>
		/// <param name="includes"> the includes </param>
		/// <returns> the sheet to create, limited to the following required
		/// attributes: * name (string) * columns (array of Column objects, limited to the following attributes) - title -
		/// primary - type - symbol - options </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Sheet CreateSheetInFolderFromExisting(long folderId, Sheet sheet, IEnumerable<ObjectInclusion> includes)
		{
			string path = "folder/" + folderId + "/sheets";
			if (includes != null)
			{
				path += "?include=";
				foreach (ObjectInclusion oi in includes)
				{
					path += oi.ToString().ToLower() + ",";
				}
			}

			return this.CreateResource(path, typeof(Sheet), sheet);
		}

		/// <summary>
		/// Create a sheet in given workspace.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /workspace/{workspaceId}/sheets
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null 
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="workspaceId"> the workspace id </param>
		/// <param name="sheet"> the sheet to create, limited to the following required attributes: * name (string) * columns 
		/// (array of Column objects, limited to the following attributes) - title - primary - type - symbol - options </param>
		/// <returns> the created sheet </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Sheet CreateSheetInWorkspace(long workspaceId, Sheet sheet)
		{
			return this.CreateResource("workspace/" + workspaceId + "/sheets", typeof(Sheet), sheet);
		}

		/// <summary>
		/// Create a sheet (from existing sheet or template) in given workspace.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /workspace/{workspaceId}/sheets 
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="workspaceId"> the workspace id </param>
		/// <param name="sheet"> the sheet to create, limited to the following required
		/// attributes: * name (string) * fromId (number): ID of the Sheet or Template from which to create the sheet. -
		/// includes : used to specify the optional objects to include, currently DATA, DISCUSSIONS and ATTACHMENTS are
		/// supported. </param>
		/// <param name="includes"> the includes </param>
		/// <returns> the created sheet </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Sheet CreateSheetInWorkspaceFromExisting(long workspaceId, Sheet sheet, IEnumerable<ObjectInclusion> includes)
		{
			string path = "workspace/" + workspaceId + "/sheets";
			if (includes != null)
			{
				path += "?include=";
				foreach (ObjectInclusion oi in includes)
				{
					path += oi.ToString().ToLower() + ",";
				}
			}

			return this.CreateResource(path, typeof(Sheet), sheet);
		}

		/// <summary>
		/// Delete a sheet.
		/// 
		/// It mirrors to the following Smartsheet REST API method: DELETE /sheet{id}
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the ID of the sheet </param>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual void DeleteSheet(long id)
		{
			this.DeleteResource<Sheet>("sheet/" + id, typeof(Sheet));
		}

		/// <summary>
		/// Update a sheet.
		/// 
		/// It mirrors to the following Smartsheet REST API method: PUT /sheet/{id}
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="sheet"> the sheet to update limited to the following attribute: * name (string) </param>
		/// <returns> the updated sheet (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Sheet UpdateSheet(Sheet sheet)
		{
			return this.UpdateResource("sheet/" + sheet.id, typeof(Sheet), sheet);
		}

		/// <summary>
		/// Get a sheet version.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /sheet/{id}/version
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the id </param>
		/// <returns> the sheet version (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual int? GetSheetVersion(long id)
		{
			return this.GetResource<Sheet>("sheet/" + id + "/version", typeof(Sheet)).version;
		}

		/// <summary>
		/// Send a sheet as a PDF attachment via email to the designated recipients.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /sheet/{sheetId}/emails
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if any argument is null 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the id </param>
		/// <param name="email"> the email </param>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual void SendSheet(long id, SheetEmail email)
		{
			this.CreateResource<SheetEmail>("sheet/" + id + "/emails", typeof(SheetEmail), email);
		}

		/// <summary>
		/// Return the ShareResources object that provides access to Share resources associated with Sheet resources.
		/// </summary>
		/// <returns> the ShareResources object </returns>
		public virtual ShareResources Shares()
		{
			return this.shares;
		}

		/// <summary>
		/// Return the SheetRowResources object that provides access to Row resources associated with Sheet resources.
		/// </summary>
		/// <returns> the sheet row resources </returns>
		public virtual SheetRowResources Rows()
		{
			return this.rows;
		}

		/// <summary>
		/// Return the SheetColumnResources object that provides access to Column resources associated with Sheet resources.
		/// </summary>
		/// <returns> the sheet column resources </returns>
		public virtual SheetColumnResources Columns()
		{
			return this.columns;
		}

		/// <summary>
		/// Return the AssociatedAttachmentResources object that provides access to attachment resources associated with
		/// Sheet resources.
		/// </summary>
		/// <returns> the associated attachment resources </returns>
		public virtual AssociatedAttachmentResources Attachments()
		{
			return this.attachments;
		}

		/// <summary>
		/// Return the AssociatedDiscussionResources object that provides access to discussion resources associated with
		/// Sheet resources.
		/// </summary>
		/// <returns> the associated discussion resources </returns>
		public virtual AssociatedDiscussionResources Discussions()
		{
			return this.discussions;
		}

		/// <summary>
		/// Get the status of the Publish settings of the sheet, including the URLs of any enabled publishings.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /sheet/{sheetId}/publish
		/// 
		/// Returns: the resource (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null).
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the id </param>
		/// <returns> the publish status </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual SheetPublish GetPublishStatus(long id)
		{
			return this.GetResource<SheetPublish>("sheet/" + id + "/publish", typeof(SheetPublish));
		}

		/// <summary>
		/// Sets the publish status of a sheet and returns the new status, including the URLs of any enabled publishings.
		/// 
		/// It mirrors to the following Smartsheet REST API method: PUT /sheet/{sheetId}/publish
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if any argument is null 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the id </param>
		/// <param name="publish"> the SheetPublish object limited to the following attributes *
		/// readOnlyLiteEnabled * readOnlyFullEnabled * readWriteEnabled * icalEnabled </param>
		/// <returns> the updated SheetPublish (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual SheetPublish UpdatePublishStatus(long id, SheetPublish publish)
		{
			return this.UpdateResource("sheet/" + id + "/publish", typeof(SheetPublish), publish);
		}

		/// <summary>
		/// Get a sheet as a file.
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the id </param>
		/// <param name="paperSize"> the paper size </param>
		/// <param name="outputStream"> the OutputStream to which the Excel file will be written </param>
		/// <param name="contentType"> the content type </param>
		/// <returns> the sheet as file </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		private void GetSheetAsFile(long id, PaperSize? paperSize, StreamWriter outputStream, string contentType)
		{
			Util.ThrowIfNull(outputStream, contentType);

			string path = "sheet/" + id;
			if (paperSize != null)
			{
				path += "?paperSize=" + paperSize;
			}

			HttpRequest request = null;
            
			request = CreateHttpRequest(new Uri(this.Smartsheet.baseURI, path), HttpMethod.GET);
			request.headers["Accept"] = contentType;

			com.smartsheet.api.@internal.http.HttpResponse response = Smartsheet.httpClient.Request(request);

			switch (response.StatusCode)
			{
			case HttpStatusCode.OK:
				try
				{
					CopyStream(response.entity.getContent().BaseStream, outputStream.BaseStream);
				}
				catch (IOException e)
				{
					throw new SmartsheetException(e);
				}
				break;
			default:
				HandleError(response);
			break;
			}

			Smartsheet.httpClient.ReleaseConnection();
		}

		/*
		 * Copy an input stream to an output stream.
		 * 
		 * @param input The input stream to copy.
		 * 
		 * @param output the output stream to write to.
		 * 
		 * @throws IOException if there is trouble reading or writing to the streams.
		 */
		/// <summary>
		/// Copy stream.
		/// </summary>
		/// <param name="input"> the input </param>
		/// <param name="output"> the output </param>
		/// <exception cref="IOException"> Signals that an I/O exception has occurred. </exception>
		private static void CopyStream(Stream input, Stream output)
		{
			byte[] buffer = new byte[BUFFER_SIZE];
			int len;
			while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
			{
				output.Write(buffer, 0, len);
			}
		}
	}

}