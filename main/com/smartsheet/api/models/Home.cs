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
	/// Represents the Home object. </summary>
	/// <seealso cref= <a href="http://help.smartsheet.com/customer/portal/articles/522237-the-home-tab">Home Tab Help</a> </seealso>
	public class Home
	{
		/// <summary>
		/// Represents the sheets in the home location.
		/// </summary>
		private IList<Sheet> sheets_Renamed;

		/// <summary>
		/// Represents the folders in the home location.
		/// </summary>
		private IList<Folder> folders_Renamed;

		/// <summary>
		/// Represents the reports in the home location.
		/// </summary>
		//TODO: implement reports
		// private List<Report> reports;

		/// <summary>
		/// Represents the templates in the home location.
		/// </summary>
		private IList<Template> templates_Renamed;

		/// <summary>
		/// Represents the workspaces in the home location.
		/// </summary>
		private IList<Workspace> workspaces_Renamed;

		/// <summary>
		/// Gets the sheets in the home location.
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
		/// Gets the folders in the home location.
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
		/// Gets the templates in the home location.
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
		/// Gets the workspaces in the home location.
		/// </summary>
		/// <returns> the workspaces </returns>
		public virtual IList<Workspace> workspaces
		{
			get
			{
				return workspaces_Renamed;
			}
			set
			{
				this.workspaces_Renamed = value;
			}
		}

	}

}