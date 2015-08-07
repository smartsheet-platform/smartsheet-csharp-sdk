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
using System.ComponentModel;
namespace Smartsheet.Api
{
	///<summary>
	///<p>This interface is the entry point of the Smartsheet SDK, it provides convenient methods to get XXXResources instances
	///for accessing different types of resources.</p>
	///
	///<p>Thread Safety: Implementation of this interface must be thread safe.</p>
	///</summary>
	public interface SmartsheetClient
	{
		/// <summary>
		/// <para>Returns the HomeResources instance that provides access to Home resources.</para>
		/// </summary>
		/// <returns> the home resources instance </returns>
		HomeResources HomeResources { get; }

		/// <summary>
		/// <para>Returns the WorkspaceResources instance that provides access to Workspace resources.</para>
		/// </summary>
		/// <returns> the workspace resources instance </returns>
		WorkspaceResources WorkspaceResources { get; }

		/// <summary>
		/// <para>Returns the FolderResources instance that provides access to Folder resources.</para>
		/// </summary>
		/// <returns> the folder resources instance </returns>
		FolderResources FolderResources { get; }

		/// <summary>
		/// <para>Returns the TemplateResources instance that provides access to Template resources.</para>
		/// </summary>
		/// <returns> the template resources instance </returns>
		TemplateResources TemplateResources { get; }

		/// <summary>
		/// <para>Returns the ReportResources instance that provides access to Report resources.</para>
		/// </summary>
		/// <returns> the report resources instance </returns>
		ReportResources ReportResources { get; }

		/// <summary>
		/// <para>Returns the SheetResources instance that provides access to Sheet resources.</para>
		/// </summary>
		/// <returns> the sheet resources instance </returns>
		SheetResources SheetResources { get; }

		///// <summary>
		///// <para>Returns the ColumnResources instance that provides access to Column resources.</para>
		///// </summary>
		///// <returns> the column resources instance </returns>
		//ColumnResources Columns();

		///// <summary>
		///// <para>Returns the RowResources instance that provides access to Row resources.</para>
		///// </summary>
		///// <returns> the row resources instance </returns>
		//RowResources RowResources();

		///// <summary>
		///// <para>Returns the AttachmentResources instance that provides access to Attachment resources.</para>
		///// </summary>
		///// <returns> the attachment resources instance </returns>
		//AttachmentResources Attachments();

		///// <summary>
		///// <para>Returns the DiscussionResources instance that provides access to Discussion resources.</para>
		///// </summary>
		///// <returns> the discussion resources instance </returns>
		//DiscussionResources Discussions();

		///// <summary>
		///// <para>Returns the CommentResources instance that provides access to Comment resources.</para>
		///// </summary>
		///// <returns> the comment resources instance </returns>
		//CommentResources Comments();

		/// <summary>
		/// <para>Returns the UserResources instance that provides access to User resources.</para>
		/// </summary>
		/// <returns> the user resources instance </returns>
		UserResources UserResources { get; }

		/// <summary>
		/// <para>Returns the SearchResources instance that provides access to searching resources.</para>
		/// </summary>
		/// <returns> the search resources instance </returns>
		SearchResources SearchResources { get; }

		/// <summary>
		/// <para>Returns the ServerInfoResources instance that provides access to server information resources.</para>
		/// </summary>
		/// <returns> the server info resources instance </returns>
		ServerInfoResources ServerInfoResources { get; }

		/// <summary>
		/// <para>Returns the GroupResources instance that provides access to group resources.</para>
		/// </summary>
		/// <returns> the group resources instance </returns>
		GroupResources GroupResources { get; }


		/// <summary>
		/// <para>Returns the FavoriteResources instance that provides access to favorite resources.</para>
		/// </summary>
		/// <returns> the favorite resources instance </returns>
		FavoriteResources FavoriteResources { get; }


		/// <summary>
		/// <para>Returns the TokenResources instance that provides access to token resources.</para>
		/// </summary>
		/// <returns> the token resources instance </returns>
		TokenResources TokenResources { get; }


		[Obsolete("use Smartsheet.Api.SmartsheetClient.HomeResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		HomeResources Home();

		[Obsolete("use Smartsheet.Api.SmartsheetClient.SheetResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		SheetResources Sheets();

		[Obsolete("use Smartsheet.Api.SmartsheetClient.ReportResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		ReportResources Reports();

		
		[Obsolete("use Smartsheet.Api.SmartsheetClient.SheetResources.AttachmentResources to get sheet level attachment resources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		AttachmentResources Attachments();

		[Obsolete("use Smartsheet.Api.SmartsheetClient.SheetResources.RowResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		RowResources Rows();

		[Obsolete("use Smartsheet.Api.SmartsheetClient.SheetResources.CommentResources to get sheet level comment resources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		CommentResources Comments();

		[Obsolete("use Smartsheet.Api.SmartsheetClient.UserResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		UserResources Users();

		[Obsolete("use Smartsheet.Api.SmartsheetClient.SearchResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		SearchResources Search();

		[Obsolete("use Smartsheet.Api.SmartsheetClient.TemplateResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		TemplateResources Templates();

		[Obsolete("use Smartsheet.Api.SmartsheetClient.FolderResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		FolderResources Folders();

		[Obsolete("use Smartsheet.Api.SmartsheetClient.WorkspaceResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		WorkspaceResources Workspaces();
	}
}