using System.Collections.Generic;

namespace com.smartsheet.api.models
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



	/// <summary>
	/// Represents one specific result of a search.
	/// </summary>
	public class SearchResultItem
	{
		/// <summary>
		/// Represents the text for this specific search result.
		/// </summary>
		private string text_Renamed;

		/// <summary>
		/// Represents the object ID for this specific search result.
		/// </summary>
		private long? objectId_Renamed;

		/// <summary>
		/// Represents the object type (row, discussion, attach) for this specific search result.
		/// </summary>
		private string objectType_Renamed;

		/// <summary>
		/// Represents the parent object ID for this specific search result.
		/// </summary>
		private long? parentObjectId_Renamed;

		/// <summary>
		/// Represents the parent object type for this specific search result.
		/// </summary>
		private string parentObjectType_Renamed;

		/// <summary>
		/// Represents the parent object name for this specific search result.
		/// </summary>
		private string parentObjectName_Renamed;

		/// <summary>
		/// Represents the context data for this specific search result.
		/// </summary>
		private IList<string> contextData_Renamed;

		/// <summary>
		/// Gets the text for this specific search result.
		/// </summary>
		/// <returns> the text </returns>
		public virtual string text
		{
			get
			{
				return text_Renamed;
			}
			set
			{
				this.text_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the object id for this specific search result.
		/// </summary>
		/// <returns> the object id </returns>
		public virtual long? objectId
		{
			get
			{
				return objectId_Renamed;
			}
			set
			{
				this.objectId_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the object type for this specific search result.
		/// </summary>
		/// <returns> the object type </returns>
		public virtual string objectType
		{
			get
			{
				return objectType_Renamed;
			}
			set
			{
				this.objectType_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the parent object id for this specific search result.
		/// </summary>
		/// <returns> the parent object id </returns>
		public virtual long? parentObjectId
		{
			get
			{
				return parentObjectId_Renamed;
			}
			set
			{
				this.parentObjectId_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the parent object type for this specific search result.
		/// </summary>
		/// <returns> the parent object type </returns>
		public virtual string parentObjectType
		{
			get
			{
				return parentObjectType_Renamed;
			}
			set
			{
				this.parentObjectType_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the parent object name for this specific search result.
		/// </summary>
		/// <returns> the parent object name </returns>
		public virtual string parentObjectName
		{
			get
			{
				return parentObjectName_Renamed;
			}
			set
			{
				this.parentObjectName_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the context data for this specific search result.
		/// </summary>
		/// <returns> the context data </returns>
		public virtual IList<string> contextData
		{
			get
			{
				return contextData_Renamed;
			}
			set
			{
				this.contextData_Renamed = value;
			}
		}

	}

}