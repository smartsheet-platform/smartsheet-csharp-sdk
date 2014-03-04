using System.Collections.Generic;

namespace com.smartsheet.api
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



	using Column = com.smartsheet.api.models.Column;

	/// <summary>
	/// <para>This interface provides methods to access column resources that are associated to a sheet object.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	public interface SheetColumnResources
	{

		/// <summary>
		/// <para>List columns of a given sheet.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: GET /sheet/{id}/columns</para>
		/// </summary>
		/// <param name="sheetId"> the sheet id </param>
		/// <returns> the list of Columns (note that an empty list will be returned if there is none) </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		IList<Column> ListColumns(long sheetId);

		/// <summary>
		/// <para>Add column to a sheet.</para>
		/// 
		/// <para>It mirrors to the following Smartsheet REST API method: POST /sheet/{id}/columns</para>
		/// </summary>
		/// <param name="sheetId"> the sheet id </param>
		/// <param name="column"> the column object </param>
		/// <returns> the created column </returns>
		/// <exception cref="InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		Column AddColumn(long sheetId, Column column);
	}

}