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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents the sight object. </summary>
	/// <seealso href="http://smartsheet-platform.github.io/api-docs/#sight-object">Sight Object Help</seealso>
	public class Sight : NamedModel
	{
		/// <summary>
		/// Number of Columns that the Sight contains
		/// </summary>
		private int? columnCount;

		/// <summary>
		/// Array of Widget objects
		/// </summary>
		private IList<Widget> widgets;

		/// <summary>
		/// Indicates whether the User has marked the Sight as a favorite
		/// </summary>
		private bool? favorite;

		/// <summary>
		/// User’s permissions on the Sight. Valid values
		/// </summary>
		private AccessLevel? accessLevel;

		/// <summary>
		/// URL that represents a direct link to the Sight in Smartsheet
		/// </summary>
		private string permalink;

		/// <summary>
		/// Time of creation
		/// </summary>
		private DateTime? createdAt;

		/// <summary>
		/// Time of last modification
		/// </summary>
		private DateTime? modifiedAt;

		/// <summary>
		/// A Workspace object, limited to only 2 attributes: Id, Name
		/// </summary>
		private Workspace workspace;

		/// <summary>
		/// The background color of the Sight
		/// </summary>
		private string backgroundColor;

		/// <summary>
		/// Get the number of Columns that the Sight contains.
		/// </summary>
		/// <returns> the columnCount </returns>
		public virtual int? ColumnCount
		{
			get
			{
				return columnCount;
			}
			set
			{
				this.columnCount = value;
			}
		}

		/// <summary>
		/// Array of Widget objects.
		/// </summary>
		/// <returns> the List </returns>
		public virtual IList<Widget> Widgets
		{
			get
			{
				return widgets;
			}
			set
			{
				this.widgets = value;
			}
		}

		/// <summary>
		/// Indicates whether the User has marked the Sight as a favorite.
		/// </summary>
		/// <returns> the favority flag </returns>
		public virtual Boolean? Favorite
		{
			get
			{
				return favorite;
			}
			set
			{
				this.favorite = value;
			}
		}

		/// <summary>
		/// User’s permissions on the Sight. Valid values:
		///		OWNER, ADMIN, VIEWER
		/// </summary>
		/// <returns> the AccessLevel </returns>
		public virtual AccessLevel? AccessLevel
		{
			get
			{
				return accessLevel;
			}
			set
			{
				this.accessLevel = value;
			}
		}

		/// <summary>
		/// URL that represents a direct link to the Sight in Smartsheet
		/// </summary>
		/// <returns> the permalink </returns>
		public virtual string Permalink
		{
			get
			{
				return permalink;
			}
			set
			{
				this.permalink = value;
			}
		}

		/// <summary>
		/// Time of creation
		/// </summary>
		/// <returns> the DateTime </returns>
		public virtual DateTime? CreatedAt
		{
			get
			{
				return createdAt;
			}
			set
			{
				this.createdAt = value;
			}
		}

		/// <summary>
		/// Time of last modification
		/// </summary>
		/// <returns> the DateTime </returns>
		public virtual DateTime? ModifiedAt
		{
			get
			{
				return modifiedAt;
			}
			set
			{
				this.modifiedAt = value;
			}
		}

		/// <summary>
		/// A Workspace object, limited to only 2 attributes:
		///		id, name
		///	Note: this attribute is only present if the Sight resides within a Workspace.
		/// </summary>
		/// <returns> the Workspace </returns>
		public virtual Workspace Workspace
		{
			get
			{
				return workspace;
			}
			set
			{
				this.workspace = value;
			}
		}

		/// <summary>
		/// Get the background color of the Sight
		/// </summary>
		/// <returns> the background color </returns>
		public virtual string BackgroundColor
		{
			get 
			{ 
				return backgroundColor; 
			}
			set
			{
				this.backgroundColor = value;
			}
		}
	}
}
