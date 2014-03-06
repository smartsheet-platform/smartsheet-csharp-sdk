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

using System;
namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents the Workspace object which is an area in which Sheets, reports, Templates and sub-Folders can be 
	/// organized, similar To a folder. </summary>
	/// <seealso href="http://help.Smartsheet.com/customer/portal/articles/506687-creating-a-workspace">Help Creating a 
	/// Workspace</seealso>
	public class Workspace : Folder
	{
		/// <summary>
		/// Represents the user's permissions on a workspace. </summary>
		private AccessLevel? accessLevel;

		/// <summary>
		/// Represents the Link . </summary>
		private string permalink;

		/// <summary>
		/// Gets the user's permissions on a workspace.
		/// </summary>
		/// <returns> the access level </returns>
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
		/// Gets the Permalink To the workspace.
		/// </summary>
		/// <returns> the Permalink </returns>
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
		/// A convenience class for creating a <seealso cref="Workspace"/> object with the appropriate fields for updating a workspace.
		/// </summary>
		public class UpdateWorkspaceBuilder
		{
			internal string workspaceName;
			internal long? id;

			/// <summary>
			/// Get the workspace Id </summary>
			/// <returns> the workspace Id </returns>
			public virtual long? ID
			{
				get
				{
					return id;
				}
			}

            /// <summary>
            /// Set the workspace Id
            /// </summary>
            /// <param name="id">the workspace Id</param>
            /// <returns>the update workspace builder</returns>
			public virtual UpdateWorkspaceBuilder SetID(long? id)
			{
				this.id = id;
				return this;
			}

			/// <summary>
			/// The Name of the workspace.
			/// </summary>
			/// <param name="name"> the Name </param>
			/// <returns> the update workspace builder </returns>
			public virtual UpdateWorkspaceBuilder SetName(string name)
			{
				this.workspaceName = name;
				return this;
			}

			/// <summary>
			/// Gets the Name.
			/// </summary>
			/// <returns> the Name </returns>
			public virtual string Name
			{
				get
				{
					return workspaceName;
				}
			}

			/// <summary>
			/// Builds the <seealso cref="Workspace"/>.
			/// </summary>
			/// <returns> the workspace </returns>
			public virtual Workspace Build()
			{
				if (workspaceName == null)
				{
					throw new InvalidOperationException("A workspace name is required.");
				}

				Workspace workspace = new Workspace();
				workspace.Name = workspaceName;
				workspace.ID = id;
				return workspace;
			}
		}
	}

}