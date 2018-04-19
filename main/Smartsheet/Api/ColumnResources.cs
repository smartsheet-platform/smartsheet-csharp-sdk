//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2014 SmartsheetClient
//    %%
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//        
//            http://www.apache.org/licenses/LICENSE-2.0
//        
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

namespace Smartsheet.Api
{


	using System;
	using System.ComponentModel;
	using Column = Api.Models.Column;

	/// <summary>
	/// <para>Use SheetColumnResources instead.</para>
	/// </summary>
	[System.Obsolete("Deprecated", true)]
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public interface ColumnResources
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="column"></param>
		/// <returns></returns>
		[Obsolete("Deprecated", true)]
		[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		Column UpdateColumn(Column column);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="sheetId"></param>
		[Obsolete("Deprecated", true)]
		[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		void DeleteColumn(long id, long sheetId);
	}

}