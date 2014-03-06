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




	using HttpEntity = Api.Internal.http.HttpEntity;
	using HttpMethod = Api.Internal.http.HttpMethod;
	using HttpRequest = Api.Internal.http.HttpRequest;
	using HttpResponse = Api.Internal.http.HttpResponse;
	using Utils = Api.Internal.Utility.Utility;
	using Column = Api.Models.Column;
    using System.Net;
    using System;

	/// <summary>
	/// This is the implementation of the ColumnResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class ColumnResourcesImpl : AbstractResources, ColumnResources
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the Smartsheet </param>
		public ColumnResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		/// Update a column.
		/// 
		/// It mirrors To the following Smartsheet REST API method: PUT /column/{Id}
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
		/// <param name="column"> the column To update limited To the following attributes: Index (column's new Index in the sheet), 
		/// Title, SheetId, Type, Options (optional), Symbol (optional), SystemColumnType (optional), 
		/// AutoNumberFormat (optional) </param>
		/// <returns> the updated sheet (note that if there is no such resource, this method will throw 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Column UpdateColumn(Column column)
		{
			Utils.ThrowIfNull(column);

			return this.UpdateResource("column/" + column.ID, typeof(Column), column);
		}

		/// <summary>
		/// Delete a column.
		/// 
		/// It mirrors To the following Smartsheet REST API method: DELETE /column/{Id}
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the ID of the column </param>
		/// <param name="sheetId"> the ID of the sheet </param>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual void DeleteColumn(long id, long sheetId)
		{
			HttpRequest request = null;
            request = CreateHttpRequest(new Uri(Smartsheet.BaseURI, "column/"+id), HttpMethod.DELETE);

			Column column = new Column();
			column.SheetId = sheetId;

            request.Entity = serializeToEntity<Column>(column);

			HttpResponse response = Smartsheet.HttpClient.Request(request);

			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
					this.Smartsheet.JsonSerializer.deserializeResult<object>(response.Entity.getContent());
					break;
				default:
					HandleError(response);
				break;
			}

			this.Smartsheet.HttpClient.ReleaseConnection();

		}
	}

}