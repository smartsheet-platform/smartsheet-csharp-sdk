using System;
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
	/// Represents a folder.
	/// </summary>
	public class Folder : NamedModel
	{

		/// <summary>
		/// Represents the sheets contained in the folder.
		/// </summary>
		private IList<Sheet> sheets_Renamed;

		/// <summary>
		/// Represents the child folders contained in the folder.
		/// </summary>
		private IList<Folder> folders_Renamed;

		/// <summary>
		/// Represents the reports.
		/// </summary>
		//TODO: implement reports
		// private List<Report> reports;

		/// <summary>
		/// Represents the templates contained in the folder.
		/// </summary>
		private IList<Template> templates_Renamed;

		/// <summary>
		/// Gets the sheets in the folder.
		/// </summary>
		/// <returns> the sheets </returns>
		public virtual IList<Sheet> sheets
		{
			get
			{
				return sheets_Renamed;
			}
			set
			{
				this.sheets_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the folders contained in this folder.
		/// </summary>
		/// <returns> the folders </returns>
		public virtual IList<Folder> folders
		{
			get
			{
				return folders_Renamed;
			}
			set
			{
				this.folders_Renamed = value;
			}
		}


		/// <summary>
		/// Gets the templates contained in this folder.
		/// </summary>
		/// <returns> the templates </returns>
		public virtual IList<Template> templates
		{
			get
			{
				return templates_Renamed;
			}
			set
			{
				this.templates_Renamed = value;
			}
		}


		/// <summary>
		/// A convenience class for setting up a folder with the appropriate fields for updating the folder.
		/// </summary>
		public class UpdateFolderBuilder
		{
			internal string folderName;
			internal long? id_Renamed;

			/// <summary>
			/// Name.
			/// </summary>
			/// <param name="name"> the name </param>
			/// <returns> the update folder builder </returns>
			public virtual UpdateFolderBuilder SetName(string name)
			{
				this.folderName = name;
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
					return folderName;
				}
			}

			/// <summary>
			/// Gets the folder id.
			/// </summary>
			/// <returns> the folder id. </returns>
			public virtual long? id
			{
				get
				{
					return id_Renamed;
				}
			}

			/// <summary>
			/// Sets the folder id.
			/// </summary>
			/// <param name="id"> the id of the folder. </param>
			public virtual UpdateFolderBuilder SetId(long? id)
			{
				this.id_Renamed = id;
				return this;
			}

			/// <summary>
			/// Builds the folder.
			/// </summary>
			/// <returns> the folder </returns>
			public virtual Folder Build()
			{
				if (folderName == null)
				{
					throw new MemberAccessException("A folder name is required.");
				}

				Folder folder = new Folder();
				folder.id = id_Renamed;
				folder.name = folderName;
				return folder;
			}
		}

	}

}