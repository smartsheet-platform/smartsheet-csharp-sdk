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

	using Column = com.smartsheet.api.models.Column;

	/// <summary>
	/// This is the implementation of the SheetColumnResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class SheetColumnResourcesImpl : AbstractResources, SheetColumnResources
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the smartsheet </param>
		public SheetColumnResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		/// List columns of a given sheet.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /sheet/{id}/columns
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="sheetId"> the sheet id </param>
		/// <returns> the columns (note that empty list will be returned if there is none) </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual IList<Column> ListColumns(long sheetId)
		{
			return this.ListResources<Column>("sheet/" + sheetId + "/columns", typeof(Column));
		}

		/// <summary>
		/// Add column to a sheet.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /sheet/{id}/columns
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
		/// <param name="sheetId"> the sheet id </param>
		/// <param name="column"> the coluimn object limited to the following attributes: *
		/// title * type * symbol (optional) * options (optional) - array of options * index (zero-based) * systemColumnType
		/// (optional) * autoNumberFormat (optional) </param>
		/// <returns> the created column </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Column AddColumn(long sheetId, Column column)
		{

			return this.CreateResource<Column>("sheet/" + sheetId + "/columns", typeof(Column), column);
		}
	}

}