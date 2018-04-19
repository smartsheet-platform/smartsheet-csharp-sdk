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

using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents a Favorite object.
	/// </summary>
	public class Favorite
	{
		private ObjectType? type;

		private long? objectId;

		/// <summary>
		/// One of: workspace, folder, sheet, report, template, sight
		/// </summary>
		public ObjectType? Type
		{
			get { return type; }
			set { type = value; }
		}

		/// <summary>
		/// ID of the favorited item. If type is "template", only private sheet-type template ID is allowed.
		/// </summary>
		public long? ObjectId
		{
			get { return objectId; }
			set { objectId = value; }
		}

		/// <summary>
		/// A convenience class for making a Favorite object with the appropriate fields for adding the user.
		/// </summary>
		public class AddFavoriteBuilder
		{
			private ObjectType? type;
			private long? objectId;

			/// <summary>
			/// Sets the required propeties for createing a Favorite.
			/// </summary>
			/// <param name="type"> the object type </param>
			/// <param name="objectId"> ID of the favorited item. If type is "template", only private sheet-type template ID is allowed.</param>
			public AddFavoriteBuilder(ObjectType? type, long? objectId)
			{
				this.type = type;
				this.objectId = objectId;
			}

			/// <summary>
			/// Builds and returns the Favorite object.
			/// </summary>
			/// <returns> the Favorite object </returns>
			public Favorite Build()
			{
				return new Favorite
				{
					ObjectId = this.objectId,
					Type = this.type
				};
			}
		}
	}
}