using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
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
	 * Unless required by applicable law or agreed To in writing, software
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
		/// Represents the Sheets contained in the folder.
		/// </summary>
		private IList<Sheet> sheets;

		/// <summary>
		/// Represents the child Folders contained in the folder.
		/// </summary>
		private IList<Folder> folders;

		/// <summary>
		/// Represents the reports.
		/// </summary>
		//TODO: implement reports
		// private List<Report> reports;

		/// <summary>
		/// Represents the Templates contained in the folder.
		/// </summary>
		private IList<Template> templates;

		/// <summary>
		/// Gets the Sheets in the folder.
		/// </summary>
		/// <returns> the Sheets </returns>
		public virtual IList<Sheet> Sheets
		{
			get
			{
				return sheets;
			}
			set
			{
				this.sheets = value;
			}
		}


		/// <summary>
		/// Gets the Folders contained in this folder.
		/// </summary>
		/// <returns> the Folders </returns>
		public virtual IList<Folder> Folders
		{
			get
			{
				return folders;
			}
			set
			{
				this.folders = value;
			}
		}


		/// <summary>
		/// Gets the Templates contained in this folder.
		/// </summary>
		/// <returns> the Templates </returns>
		public virtual IList<Template> Templates
		{
			get
			{
				return templates;
			}
			set
			{
				this.templates = value;
			}
		}


		/// <summary>
		/// A convenience class for setting up a folder with the appropriate fields for updating the folder.
		/// </summary>
		public class UpdateFolderBuilder
		{
			internal string folderName;
			internal long? id;

			/// <summary>
			/// Name.
			/// </summary>
			/// <param Name="Name"> the Name </param>
			/// <returns> the update folder builder </returns>
			public virtual UpdateFolderBuilder SetName(string name)
			{
				this.folderName = name;
				return this;
			}

			/// <summary>
			/// Gets the Name.
			/// </summary>
			/// <returns> the Name </returns>
			public virtual string name
			{
				get
				{
					return folderName;
				}
			}

			/// <summary>
			/// Gets the folder Id.
			/// </summary>
			/// <returns> the folder Id. </returns>
			public virtual long? Id
			{
				get
				{
					return id;
				}
			}

			/// <summary>
			/// Sets the folder Id.
			/// </summary>
			/// <param Name="Id"> the Id of the folder. </param>
			public virtual UpdateFolderBuilder SetID(long? id)
			{
				this.id = id;
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
				folder.ID = id;
				folder.Name = folderName;
				return folder;
			}
		}

	}

}