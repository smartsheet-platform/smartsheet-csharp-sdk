using System.Collections.Generic;

namespace Smartsheet.Api
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



	using Row = Api.Models.Row;
	using RowWrapper = Api.Models.RowWrapper;

	/// <summary>
	/// This interface provides methods To access row resources that are associated To a sheet object.
	/// 
	/// Thread Safety: Implementation of this interface must be thread safe.
	/// </summary>
	public interface SheetRowResources
	{

		/// <summary>
		/// <para>Insert Rows To a sheet.</para>
		/// 
		/// <para>It mirrors To the following Smartsheet REST API method: POST /sheet/{Id}/Rows</para>
		/// </summary>
		/// <param Name="SheetId"> the sheet Id </param>
		/// <param Name="rowWrapper"> the row wrapper </param>
		/// <returns> the list of created Rows </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		IList<Row> InsertRows(long sheetId, RowWrapper rowWrapper);

		/// <summary>
		/// Get a row.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /sheet/{Id}/row/{number}
		/// </summary>
		/// <param Name="Id"> the Id </param>
		/// <param Name="RowNumber"> the row number </param>
		/// <returns> the created row (note that if there is no such resource, this method will throw ResourceNotFoundException rather
		/// than returning null). </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due To rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Row GetRow(long id, int rowNumber);
	}

}