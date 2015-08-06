﻿//    #[license]
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
//    Unless required by applicable law or agreed To in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{

	/// <summary>
	/// Object that describes the destination container when a Sheet or Folder is moved, or when a Sheet, Folder, or Workspace is copied.
	/// </summary>
	public class ContainerDestination
	{
		private DestinationType? destinationType;

		private long? destinationId;

		private string newName;

		/// <summary>
		/// Type of the destination container (when copying or moving a Sheet or a Folder). 
		/// </summary>
		public DestinationType? DestinationType
		{
			get { return destinationType; }
			set { destinationType = value; }
		}

		/// <summary>
		/// <para>
		/// ID of the destination container (when copying or moving a Sheet or a Folder).
		/// </para>
		/// <para>
		/// Required if destinationType is "folder" or "workspace" If destinationType is "home", this value must be null.
		/// </para>
		/// </summary>
		public long? DestinationId
		{
			get { return destinationId; }
			set { destinationId = value; }
		}

		/// <summary>
		/// <para>
		/// Name of the newly created object (when creating a copy of a Sheet, Folder, or Workspace).
		/// </para>
		/// <para>
		/// This attribute is not supported for "move" operations (i.e., a moved Sheet, Folder or Workspace retains its original name).
		/// </para>
		/// </summary>
		public string NewName
		{
			get { return newName; }
			set { newName = value; }
		}
	}
}