using System;
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
	/// Represents the Workspace object which is an area in which sheets, reports, templates and sub-folders can be 
	/// organized, similar to a folder. </summary>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/506687-creating-a-workspace">Help Creating a 
	/// Workspace</a> </seealso>
	public class Workspace : Folder
	{
		/// <summary>
		/// Represents the user's permissions on a workspace. </summary>
		private AccessLevel? accessLevel_Renamed;

		/// <summary>
		/// Represents the link . </summary>
		private string permalink_Renamed;

		/// <summary>
		/// Gets the user's permissions on a workspace.
		/// </summary>
		/// <returns> the access level </returns>
		public virtual AccessLevel? accessLevel
		{
			get
			{
				return accessLevel_Renamed;
			}
			set
			{
				this.accessLevel_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the permalink to the workspace.
		/// </summary>
		/// <returns> the permalink </returns>
		public virtual string permalink
		{
			get
			{
				return permalink_Renamed;
			}
			set
			{
				this.permalink_Renamed = value;
			}
		}


		/// <summary>
		/// A convenience class for creating a <seealso cref="Workspace"/> object with the appropriate fields for updating a workspace.
		/// </summary>
		public class UpdateWorkspaceBuilder
		{
			internal string workspaceName;
			internal long? id_Renamed;

			/// <summary>
			/// Get the workspace id </summary>
			/// <returns> the workspace id </returns>
			public virtual long? id
			{
				get
				{
					return id_Renamed;
				}
			}

			/// <summary>
			/// Set the workspace id </summary>
			/// <param name="id"> the workspace id </param>
			public virtual UpdateWorkspaceBuilder SetId(long? id)
			{
				this.id_Renamed = id;
				return this;
			}

			/// <summary>
			/// The name of the workspace.
			/// </summary>
			/// <param name="name"> the name </param>
			/// <returns> the update workspace builder </returns>
			public virtual UpdateWorkspaceBuilder SetName(string name)
			{
				this.workspaceName = name;
				return this;
			}

			/// <summary>
			/// Gets the name.
			/// </summary>
			/// <returns> the name </returns>
			public virtual string name
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
				workspace.name = workspaceName;
				workspace.id = id_Renamed;
				return workspace;
			}
		}
	}

}