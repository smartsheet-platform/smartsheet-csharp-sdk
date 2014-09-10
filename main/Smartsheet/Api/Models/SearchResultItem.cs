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
//    Unless required by applicable law or agreed To in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

using System.Collections.Generic;

namespace Smartsheet.Api.Models
{


	/// <summary>
	/// Represents one specific RequestResult of a search.
	/// </summary>
	public class SearchResultItem
	{
		/// <summary>
		/// Represents the Text for this specific search RequestResult.
		/// </summary>
		private string text;

		/// <summary>
		/// Represents the object ID for this specific search RequestResult.
		/// </summary>
		private long? objectId;

		/// <summary>
		/// Represents the object Type (row, discussion, attach) for this specific search RequestResult.
		/// </summary>
		private string objectType;

		/// <summary>
		/// Represents the parent object ID for this specific search RequestResult.
		/// </summary>
		private long? parentObjectId;

		/// <summary>
		/// Represents the parent object Type for this specific search RequestResult.
		/// </summary>
		private string parentObjectType;

		/// <summary>
		/// Represents the parent object Name for this specific search RequestResult.
		/// </summary>
		private string parentObjectName;

		/// <summary>
		/// Represents the context data for this specific search RequestResult.
		/// </summary>
		private IList<string> contextData;

		/// <summary>
		/// Gets the Text for this specific search RequestResult.
		/// </summary>
		/// <returns> the Text </returns>
		public virtual string Text
		{
			get
			{
				return text;
			}
			set
			{
				this.text = value;
			}
		}


		/// <summary>
		/// Gets the object Id for this specific search RequestResult.
		/// </summary>
		/// <returns> the object Id </returns>
		public virtual long? ObjectId
		{
			get
			{
				return objectId;
			}
			set
			{
				this.objectId = value;
			}
		}


		/// <summary>
		/// Gets the object Type for this specific search RequestResult.
		/// </summary>
		/// <returns> the object Type </returns>
		public virtual string ObjectType
		{
			get
			{
				return objectType;
			}
			set
			{
				this.objectType = value;
			}
		}


		/// <summary>
		/// Gets the parent object Id for this specific search RequestResult.
		/// </summary>
		/// <returns> the parent object Id </returns>
		public virtual long? ParentObjectId
		{
			get
			{
				return parentObjectId;
			}
			set
			{
				this.parentObjectId = value;
			}
		}


		/// <summary>
		/// Gets the parent object Type for this specific search RequestResult.
		/// </summary>
		/// <returns> the parent object Type </returns>
		public virtual string ParentObjectType
		{
			get
			{
				return parentObjectType;
			}
			set
			{
				this.parentObjectType = value;
			}
		}


		/// <summary>
		/// Gets the parent object Name for this specific search RequestResult.
		/// </summary>
		/// <returns> the parent object Name </returns>
		public virtual string ParentObjectName
		{
			get
			{
				return parentObjectName;
			}
			set
			{
				this.parentObjectName = value;
			}
		}


		/// <summary>
		/// Gets the context data for this specific search RequestResult.
		/// </summary>
		/// <returns> the context data </returns>
		public virtual IList<string> ContextData
		{
			get
			{
				return contextData;
			}
			set
			{
				this.contextData = value;
			}
		}

	}

}