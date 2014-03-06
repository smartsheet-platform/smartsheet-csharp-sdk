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
	using Column = Api.Models.Column;

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
		/// <param name="smartsheet"> the Smartsheet </param>
		public SheetColumnResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		/// List Columns of a given sheet.
		/// 
		/// It mirrors To the following Smartsheet REST API method: GET /sheet/{Id}/Columns
		/// 
		/// Exceptions:
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due To rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// <param name="sheetId"> the sheet Id </param>
		/// <returns> the Columns (note that empty list will be returned if there is none) </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual IList<Column> ListColumns(long sheetId)
		{
			return this.ListResources<Column>("sheet/" + sheetId + "/columns", typeof(Column));
		}

		/// <summary>
		/// Add column To a sheet.
		/// 
		/// It mirrors To the following Smartsheet REST API method: POST /sheet/{Id}/Columns
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
		/// <param name="sheetId"> the sheet Id </param>
		/// <param name="column"> the coluimn object limited To the following attributes: *
		/// Title * Type * Symbol (optional) * Options (optional) - array of Options * Index (zero-based) * SystemColumnType
		/// (optional) * AutoNumberFormat (optional) </param>
		/// <returns> the created column </returns>
		/// <exception cref="SmartsheetException"> the Smartsheet exception </exception>
		public virtual Column AddColumn(long sheetId, Column column)
		{

			return this.CreateResource<Column>("sheet/" + sheetId + "/columns", typeof(Column), column);
		}
	}

}