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




	using HttpEntity = com.smartsheet.api.@internal.http.HttpEntity;
	using HttpMethod = com.smartsheet.api.@internal.http.HttpMethod;
	using HttpRequest = com.smartsheet.api.@internal.http.HttpRequest;
	using HttpResponse = com.smartsheet.api.@internal.http.HttpResponse;
	using Util = com.smartsheet.api.@internal.util.Util;
	using Column = com.smartsheet.api.models.Column;
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
		/// <param name="smartsheet"> the smartsheet </param>
		public ColumnResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		/// Update a column.
		/// 
		/// It mirrors to the following Smartsheet REST API method: PUT /column/{id}
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
		/// <param name="column"> the column to update limited to the following attributes: index (column's new index in the sheet), 
		/// title, sheetId, type, options (optional), symbol (optional), systemColumnType (optional), 
		/// autoNumberFormat (optional) </param>
		/// <returns> the updated sheet (note that if there is no such resource, this method will throw 
		/// ResourceNotFoundException rather than returning null). </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Column UpdateColumn(Column column)
		{
			Util.ThrowIfNull(column);

			return this.UpdateResource("column/" + column.id, typeof(Column), column);
		}

		/// <summary>
		/// Delete a column.
		/// 
		/// It mirrors to the following Smartsheet REST API method: DELETE /column/{id}
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="id"> the ID of the column </param>
		/// <param name="sheetId"> the ID of the sheet </param>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual void DeleteColumn(long id, long sheetId)
		{
			HttpRequest request = null;
            request = CreateHttpRequest(new Uri(Smartsheet.baseURI, "column/"+id), HttpMethod.DELETE);

			Column column = new Column();
			column.sheetId = sheetId;

            request.entity = serializeToEntity<Column>(column);

			HttpResponse response = Smartsheet.httpClient.Request(request);

			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
					this.Smartsheet.jsonSerializer.deserializeResult<object>(response.entity.getContent());
					break;
				default:
					HandleError(response);
				break;
			}

			this.Smartsheet.httpClient.ReleaseConnection();

		}
	}

}