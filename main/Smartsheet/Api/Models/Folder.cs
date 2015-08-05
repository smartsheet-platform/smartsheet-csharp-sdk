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

namespace Smartsheet.Api.Models
{


	/// <summary>
	/// Represents a folder.
	/// </summary>
	public class Folder : NamedModel
	{
		/// <summary>
		/// Represents whether Folder is marked as favorite in Home folder
		/// </summary>
		private bool? favorite;

		/// <summary>
		/// Direct URL to Folder
		/// </summary>
		private string permalink;

		/// <summary>
		/// Represents the Sheets contained in the folder.
		/// </summary>
		private IList<Sheet> sheets;

		/// <summary>
		/// Represents the Reports contained in the folder.
		/// </summary>
		private IList<Report> reports;

		/// <summary>
		/// Represents the child Folders contained in the folder.
		/// </summary>
		private IList<Folder> folders;

		// <summary>
		// Represents the reports.
		// </summary>
		//TODO: implement reports
		// private List<Report> reports;

		/// <summary>
		/// Represents the Templates contained in the folder.
		/// </summary>
		private IList<Template> templates;

		private string distributionLink;

		/// <summary>
		/// <para>
		/// A URL that can be used to provision the Folder.
		/// It enables a user to create their own copy of this Folder without having access to the Workspace that contains the Folder.
		/// </para>
		/// <para>
		/// This attribute is only present if the Folder exists in a distribution-enabled
		/// Workspace and the API requester has either owner or admin access to the containing Workspace.
		/// </para>
		/// </summary>
		public string DistributionLink
		{
			get { return distributionLink; }
			set { distributionLink = value; }
		}

		/// <summary>
		/// Gets and Sets the whether this Folder is favorited.
		/// </summary>
		/// <returns> the Sheets </returns>
		public bool? Favorite
		{
			get { return favorite; }
			set { favorite = value; }
		}

		/// <summary>
		/// Gets and Sets the permalink of this folder.
		/// </summary>
		/// <returns> the Sheets </returns>
		public string Permalink
		{
			get { return permalink; }
			set { permalink = value; }
		}

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
		/// Gets the Reports in the folder.
		/// </summary>
		/// <returns> the Sheets </returns>
		public virtual IList<Report> Reports
		{
			get
			{
				return reports;
			}
			set
			{
				this.reports = value;
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
			private string folderName;
			//internal long? id;

			/// <summary>
			/// Sets the required the fields for updating a Folder.
			/// </summary>
			/// <param name="name"> the name of the folder, need not be unique </param>
			public UpdateFolderBuilder(string name)
			{
				this.folderName = name;
			}

			/// <summary>
			/// Set the Name of the Folder.
			/// </summary>
			/// <param name="name"> the Name </param>
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
			public virtual string GetName()
			{
				return folderName;
			}

			///// <summary>
			///// Gets the folder Id.
			///// </summary>
			///// <returns> the folder Id. </returns>
			//public virtual long? Id
			//{
			//	get
			//	{
			//		return id;
			//	}
			//}

			//	/// <summary>
			//	/// Sets the folder Id.
			//	/// </summary>
			//	/// <param name="id">the Id of the folder.</param>
			//	/// <returns></returns>
			//public virtual UpdateFolderBuilder SetID(long? id)
			//{
			//	this.id = id;
			//	return this;
			//}

			/// <summary>
			/// Builds the folder.
			/// </summary>
			/// <returns> the folder </returns>
			public virtual Folder Build()
			{
				//if (folderName == null)
				//{
				//	throw new MemberAccessException("A folder name is required.");
				//}

				Folder folder = new Folder();
				//folder.ID = id;
				folder.Name = folderName;
				return folder;
			}
		}

		/// <summary>
		/// A convenience class for setting up a folder with the appropriate fields for creation.
		/// </summary>
		public class CreateFolderBuilder
		{
			private string folderName;

			/// <summary>
			/// Sets the required the fields for creating a Folder.
			/// </summary>
			/// <param name="name"> the name of the folder, need not be unique </param>
			public CreateFolderBuilder(string name)
			{
				this.folderName = name;
			}

			/// <summary>
			/// Set the Name of the Folder.
			/// </summary>
			/// <param name="name"> the Name </param>
			/// <returns> the update folder builder </returns>
			public virtual CreateFolderBuilder SetName(string name)
			{
				this.folderName = name;
				return this;
			}

			/// <summary>
			/// Gets the Name.
			/// </summary>
			/// <returns> the Name </returns>
			public virtual string GetName()
			{
				return folderName;
			}

			/// <summary>
			/// Builds the folder.
			/// </summary>
			/// <returns> the folder </returns>
			public virtual Folder Build()
			{
				Folder folder = new Folder();
				folder.Name = folderName;
				return folder;
			}
		}
	}
}