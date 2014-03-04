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



	using Row = com.smartsheet.api.models.Row;
	using RowWrapper = com.smartsheet.api.models.RowWrapper;

	/// <summary>
	/// This is the implementation of the SheetRowResources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class SheetRowResourcesImpl : AbstractResources, SheetRowResources
	{

		/// <summary>
		/// Constructor.
		/// 
		/// Parameters: - smartsheet : the SmartsheetImpl
		/// 
		/// Exceptions: - IllegalArgumentException : if any argument is null
		/// </summary>
		/// <param name="smartsheet"> the smartsheet </param>
		public SheetRowResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
		{
		}

		/// <summary>
		/// Insert rows to a sheet.
		/// 
		/// It mirrors to the following Smartsheet REST API method: POST /sheet/{id}/rows
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
		/// <param name="sheetId"> the sheet id </param>
		/// <param name="rowWrapper"> he RowWrapper object, one of the following attributes should be specified: 
		/// * toTop : Inserts the rows at the top of the sheet. * toBottom : Inserts the rows at the
		/// bottom of the sheet * parentId : Inserts the rows as the first child row of the parent. toBottom=true can also be
		/// set to add the row as the last child of the parent. * siblingId : Inserts the row as the next sibling of the row
		/// ID provided. </param>
		/// <returns> the created rows </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual IList<Row> InsertRows(long sheetId, RowWrapper rowWrapper)
		{
			return this.PostAndReceiveList<RowWrapper, Row>("sheet/" + sheetId + "/rows", rowWrapper, typeof(Row));
		}

		/// <summary>
		/// Get a row.
		/// 
		/// It mirrors to the following Smartsheet REST API method: GET /sheet/{id}/row/{number}
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
		/// <param name="rowNumber"> the row number </param>
		/// <returns> the row (note that if there is no such resource, this method will throw ResourceNotFoundException rather
		/// than returning null). </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		public virtual Row GetRow(long id, int rowNumber)
		{
			return this.GetResource<Row>("sheet/" + id + "/row/" + rowNumber, typeof(Row));
		}
	}

}