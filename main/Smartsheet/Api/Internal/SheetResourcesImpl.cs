//    #[license]
//    Smartsheet SDK for C#
//    %%
//    Copyright (C) 2014 Smartsheet
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

	using HttpMethod = Api.Internal.Http.HttpMethod;
	using HttpRequest = Api.Internal.Http.HttpRequest;
	using Utils = Api.Internal.Utility.Utility;
	using ObjectInclusion = Api.Models.ObjectInclusion;
	using PaperSize = Api.Models.PaperSize;
	using Sheet = Api.Models.Sheet;
	using SheetEmail = Api.Models.SheetEmail;
	using SheetPublish = Api.Models.SheetPublish;
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
		/// <param name="smartsheet"> the Smartsheet </param>
		public SheetResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
			this.shares = new ShareResourcesImpl(smartsheet, "sheet");
			this.rows = new SheetRowResourcesImpl(smartsheet);
			this.columns = new SheetColumnResourcesImpl(smartsheet);
			this.attachments = new AssociatedAttachmentResourcesImpl(smartsheet, "sheet");
			this.discussions = new AssociatedDiscussionResourcesImpl(smartsheet, "sheet");
		}

		/// <summary>
		/// List all Sheets.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /Sheets
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <returns> all Sheets (note that empty list will be returned if there is none) </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual IList<Sheet> ListSheets()
		{
			return this.ListResources<Sheet>("sheets", typeof(Sheet));
		}

		/// <summary>
		/// List all Sheets in the organization.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /Users/Sheets
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <returns> all Sheets (note that empty list will be returned if there is none) </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual IList<Sheet> ListOrganizationSheets()
		{
			return this.ListResources<Sheet>("users/sheets", typeof(Sheet));
		}

		/// <summary>
		/// Get a sheet.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /sheet/{Id} 
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the Id </param>
		/// <param name="includes"> used To specify the optional objects To include, currently DISCUSSIONS and
		/// ATTACHMENTS are supported. </param>
		/// <returns> the resource (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
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
		/// It mirrors To the following Smartsheet REST API method: GET /sheet/{Id} with "application/vnd.ms-excel" Accept
		/// HTTP header 
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if outputStream is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the Id </param>
		/// <param name="outputStream"> the OutputStream To which the Excel file will be written </param>
		/// <returns> the sheet as excel </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual void GetSheetAsExcel(long id, BinaryWriter outputStream)
		{
			GetSheetAsFile(id, null, outputStream, "application/vnd.ms-excel");
		}

		/// <summary>
		/// Get a sheet as a PDF file.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /sheet/{Id} with "application/pdf" Accept HTTP 
		/// header
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if outputStream is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the Id </param>
		/// <param name="outputStream"> the output stream To which the PDF file will be written. </param>
		/// <param name="paperSize"> the optional paper size </param>
		/// <returns> the sheet as pdf </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual void GetSheetAsPDF(long id, BinaryWriter outputStream, PaperSize? paperSize)
		{
			GetSheetAsFile(id, paperSize, outputStream, "application/pdf");
		}

		/// <summary>
		/// Create a sheet in default "Sheets" collection.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /Sheets 
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="sheet"> the sheet To create, limited To the following required attributes: * Name (string) *
		/// Columns (array of Column objects, limited To the following attributes) - Title - Primary - Type - Symbol -
		/// Options </param>
		/// <returns> the created sheet </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Sheet CreateSheet(Sheet sheet)
		{
			return this.CreateResource("sheets", typeof(Sheet), sheet);
		}

		/// <summary>
		/// Create a sheet (from existing sheet or template) in default "Sheets" collection.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /Sheets 
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request 
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="sheet"> the sheet To create, limited To the following required attributes: * Name (string) * FromId
		/// (number): ID of the Sheet or Template from which To create the sheet. </param>
		/// <param name="includes"> used To specify the optional objects To include, currently DATA, DISCUSSIONS and ATTACHMENTS are 
		/// supported. </param>
		/// <returns> the sheet </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
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
		/// It mirrors To the following Smartsheet REST API method: POST /folder/{folderId}/Sheets
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="folderId"> the folder Id </param>
		/// <param name="sheet"> the sheet To create, limited To the following required
		/// attributes: * Name (string) * Columns (array of Column objects, limited To the following attributes) - Title -
		/// Primary - Type - Symbol - Options </param>
		/// <returns> the created sheet </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Sheet CreateSheetInFolder(long folderId, Sheet sheet)
		{

			return this.CreateResource("folder/" + folderId + "/sheets", typeof(Sheet), sheet);
		}

		/// <summary>
		/// Create a sheet in given folder.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /folder/{folderId}/Sheets 
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="folderId"> the folder Id </param>
		/// <param name="sheet"> the sheet </param>
		/// <param name="includes"> the includes </param>
		/// <returns> the sheet To create, limited To the following required
		/// attributes: * Name (string) * Columns (array of Column objects, limited To the following attributes) - Title -
		/// Primary - Type - Symbol - Options </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
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
		/// It mirrors To the following Smartsheet REST API method: POST /workspace/{workspaceId}/Sheets
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null 
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="workspaceId"> the workspace Id </param>
		/// <param name="sheet"> the sheet To create, limited To the following required attributes: * Name (string) * Columns 
		/// (array of Column objects, limited To the following attributes) - Title - Primary - Type - Symbol - Options </param>
		/// <returns> the created sheet </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Sheet CreateSheetInWorkspace(long workspaceId, Sheet sheet)
		{
			return this.CreateResource("workspace/" + workspaceId + "/sheets", typeof(Sheet), sheet);
		}

		/// <summary>
		/// Create a sheet (from existing sheet or template) in given workspace.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /workspace/{workspaceId}/Sheets 
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="workspaceId"> the workspace Id </param>
		/// <param name="sheet"> the sheet To create, limited To the following required
		/// attributes: * Name (string) * FromId (number): ID of the Sheet or Template from which To create the sheet. -
		/// includes : used To specify the optional objects To include, currently DATA, DISCUSSIONS and ATTACHMENTS are
		/// supported. </param>
		/// <param name="includes"> the includes </param>
		/// <returns> the created sheet </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
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
		/// It mirrors To the following Smartsheet REST API method: DELETE /sheet{Id}
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the ID of the sheet </param>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual void DeleteSheet(long id)
		{
			this.DeleteResource<Sheet>("sheet/" + id, typeof(Sheet));
		}

		/// <summary>
		/// Update a sheet.
		/// 
		/// It mirrors To the following Smartsheet REST API method: PUT /sheet/{Id}
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="sheet"> the sheet To update limited To the following attribute: * Name (string) </param>
		/// <returns> the updated sheet (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Sheet UpdateSheet(Sheet sheet)
		{
			return this.UpdateResource("sheet/" + sheet.ID, typeof(Sheet), sheet);
		}

		/// <summary>
		/// Get a sheet Version.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /sheet/{Id}/Version
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the Id </param>
		/// <returns> the sheet Version (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual int? GetSheetVersion(long id)
		{
			return this.GetResource<Sheet>("sheet/" + id + "/version", typeof(Sheet)).Version;
		}

		/// <summary>
		/// Send a sheet as a PDF attachment via Email To the designated recipients.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /sheet/{SheetId}/emails
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if any argument is null 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the Id </param>
		/// <param name="email"> the Email </param>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual void SendSheet(long id, SheetEmail email)
		{
			this.CreateResource<SheetEmail>("sheet/" + id + "/emails", typeof(SheetEmail), email);
		}

		/// <summary>
		/// Return the ShareResources object that provides access To Share resources associated with Sheet resources.
		/// </summary>
		/// <returns> the ShareResources object </returns>
		public virtual ShareResources Shares()
		{
			return this.shares;
		}

		/// <summary>
		/// Return the SheetRowResources object that provides access To Row resources associated with Sheet resources.
		/// </summary>
		/// <returns> the sheet row resources </returns>
		public virtual SheetRowResources Rows()
		{
			return this.rows;
		}

		/// <summary>
		/// Return the SheetColumnResources object that provides access To Column resources associated with Sheet resources.
		/// </summary>
		/// <returns> the sheet column resources </returns>
		public virtual SheetColumnResources Columns()
		{
			return this.columns;
		}

		/// <summary>
		/// Return the AssociatedAttachmentResources object that provides access To attachment resources associated with
		/// Sheet resources.
		/// </summary>
		/// <returns> the associated attachment resources </returns>
		public virtual AssociatedAttachmentResources Attachments()
		{
			return this.attachments;
		}

		/// <summary>
		/// Return the AssociatedDiscussionResources object that provides access To discussion resources associated with
		/// Sheet resources.
		/// </summary>
		/// <returns> the associated discussion resources </returns>
		public virtual AssociatedDiscussionResources Discussions()
		{
			return this.discussions;
		}

		/// <summary>
		/// Get the Status of the Publish settings of the sheet, including the URLs of any enabled publishings.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /sheet/{SheetId}/publish
		/// 
		/// Returns: the resource (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null).
		/// 
		/// Exceptions: 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the Id </param>
		/// <returns> the publish Status </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual SheetPublish GetPublishStatus(long id)
		{
			return this.GetResource<SheetPublish>("sheet/" + id + "/publish", typeof(SheetPublish));
		}

		/// <summary>
		/// Sets the publish Status of a sheet and returns the new Status, including the URLs of any enabled publishings.
		/// 
		/// It mirrors To the following Smartsheet REST API method: PUT /sheet/{SheetId}/publish
		/// 
		/// Exceptions: 
		///   - IllegalArgumentException : if any argument is null 
		///   - InvalidRequestException : if there is any problem with the REST API request 
		///   - AuthorizationException : if there is any problem with the REST API authorization(access token) 
		///   - ResourceNotFoundException : if the resource can not be found 
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the Id </param>
		/// <param name="publish"> the SheetPublish object limited To the following attributes *
		/// ReadOnlyLiteEnabled * ReadOnlyFullEnabled * ReadWriteEnabled * IcalEnabled </param>
		/// <returns> the updated SheetPublish (note that if there is no such resource, this method will throw
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
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
		///   - ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting) 
		///   - SmartsheetRestException : if there is any other REST API related error occurred during the operation 
		///   - SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the Id </param>
		/// <param name="paperSize"> the paper size </param>
		/// <param name="outputStream"> the OutputStream To which the Excel file will be written </param>
		/// <param name="contentType"> the content Type </param>
		/// <returns> the sheet as file </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		private void GetSheetAsFile(long id, PaperSize? paperSize, BinaryWriter outputStream, string contentType)
		{
			Utils.ThrowIfNull(outputStream, contentType);

			string path = "sheet/" + id;
			if (paperSize != null)
			{
				path += "?paperSize=" + paperSize;
			}

			HttpRequest request = null;
				
			request = CreateHttpRequest(new Uri(this.Smartsheet.BaseURI, path), HttpMethod.GET);
			request.Headers["Accept"] = contentType;

			Api.Internal.Http.HttpResponse response = Smartsheet.HttpClient.Request(request);

			switch (response.StatusCode)
			{
			case HttpStatusCode.OK:
				try
				{
					response.Entity.GetBinaryContent().BaseStream.CopyTo(outputStream.BaseStream);
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

			Smartsheet.HttpClient.ReleaseConnection();
		}

		/*
		 * Copy an input stream To an output stream.
		 * 
		 * @param input The input stream To copy.
		 * 
		 * @param output the output stream To write To.
		 * 
		 * @throws IOException if there is trouble reading or writing To the streams.
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