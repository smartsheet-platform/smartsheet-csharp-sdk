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

namespace Smartsheet.Api.Models
{


	/// <summary>
	/// Represents the Type of attachment.
	/// </summary>
	public enum AttachmentType
	{
		/// <summary>
		/// The file
		/// </summary>
		FILE,
		/// <summary>
		/// Google drive
		/// </summary>
		GOOGLE_DRIVE,
		/// <summary>
		/// The link
		/// </summary>
		LINK,
		/// <summary>
		/// BOX
		/// </summary>
		BOX_COM,
		/// <summary>
		/// Dropbox
		/// </summary>
		DROPBOX,
		/// <summary>
		/// Evernote
		/// </summary>
		EVERNOTE,
		/// <summary>
		/// Egnyte
		/// </summary>
		EGNYTE,
		/// <summary>
		/// OneDrive 
		/// </summary>
		ONEDRIVE,
		/// <summary>
		/// Smartsheet
		/// </summary>
		SMARTSHEET
	}
}
