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

		/// <summary>
		/// <para>Returns the SightResources instance that provides access to Sight resources.</para>
		/// </summary>
		/// <returns> the sight resources instance </returns>
		SightResources SightResources { get; }

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

		/// <summary>
		/// <para>Returns the ContactResources instance that provides access to contact resources.</para>
		/// </summary>
		/// <returns> the contact resources instance </returns>
		ContactResources ContactResources { get; }


		/// <summary>
		/// Use Smartsheet.Api.SmartsheetClient.HomeResources instead.
		/// </summary>
		/// <returns>The HomeResources.</returns>
		[Obsolete("use Smartsheet.Api.SmartsheetClient.HomeResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		HomeResources Home();

		/// <summary>
		/// Use Smartsheet.Api.SmartsheetClient.FolderResources instead.
		/// </summary>
		/// <returns>The FolderResources.</returns>
		[Obsolete("use Smartsheet.Api.SmartsheetClient.SheetResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		SheetResources Sheets();

		/// <summary>
		/// Use Smartsheet.Api.SmartsheetClient.ReportResources instead.
		/// </summary>
		/// <returns>The ReportResources.</returns>
		[Obsolete("use Smartsheet.Api.SmartsheetClient.ReportResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		ReportResources Reports();

		/// <summary>
		/// <para>
		/// Use Smartsheet.Api.SmartsheetClient.SheetResources.AttachmentResources instead to get sheet level attachment resources.
		/// </para>
		/// <para>
		/// Use Smartsheet.Api.SmartsheetClient.SheetResources.DiscussionResources.AttachmentResources instead to get discussion level attachment resources.
		/// </para>
		/// <para>
		/// Use Smartsheet.Api.SmartsheetClient.SheetResources.CommentResources.AttachmentResources instead to get comment level attachment resources.
		/// </para>
		/// </summary>
		/// <returns>The AttachmentResources.</returns>
		[Obsolete("use Smartsheet.Api.SmartsheetClient.SheetResources.AttachmentResources to get sheet level attachment resources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		AttachmentResources Attachments();

		/// <summary>
		/// Use Smartsheet.Api.SmartsheetClient.SheetResources.RowResources instead.
		/// </summary>
		/// <returns>The RowResources.</returns>
		[Obsolete("use Smartsheet.Api.SmartsheetClient.SheetResources.RowResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		RowResources Rows();

		/// <summary>
		/// <para>
		/// Use Smartsheet.Api.SmartsheetClient.SheetResources.CommentResources instead to get sheet level comment resources.
		/// </para>
		/// <para>
		/// Use Smartsheet.Api.SmartsheetClient.SheetResources.DiscussionResources.CommentResources instead to get discussion level comment resources.
		/// </para>
		/// </summary>
		/// <returns>The CommentResources.</returns>
		[Obsolete("use Smartsheet.Api.SmartsheetClient.SheetResources.CommentResources to get sheet level comment resources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		CommentResources Comments();

		/// <summary>
		/// Use Smartsheet.Api.SmartsheetClient.UserResources instead.
		/// </summary>
		/// <returns>The UserResources.</returns>
		[Obsolete("use Smartsheet.Api.SmartsheetClient.UserResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		UserResources Users();

		/// <summary>
		/// Use Smartsheet.Api.SmartsheetClient.SearchResources instead.
		/// </summary>
		/// <returns>The SearchResources.</returns>
		[Obsolete("use Smartsheet.Api.SmartsheetClient.SearchResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		SearchResources Search();

		/// <summary>
		/// Use Smartsheet.Api.SmartsheetClient.TemplateResources instead.
		/// </summary>
		/// <returns>The TemplateResources.</returns>
		[Obsolete("use Smartsheet.Api.SmartsheetClient.TemplateResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		TemplateResources Templates();

		/// <summary>
		/// Use Smartsheet.Api.SmartsheetClient.FolderResources instead.
		/// </summary>
		/// <returns>The FolderResources.</returns>
		[Obsolete("use Smartsheet.Api.SmartsheetClient.FolderResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		FolderResources Folders();

		/// <summary>
		/// Use Smartsheet.Api.SmartsheetClient.WorkspaceResources instead.
		/// </summary>
		/// <returns>The WorkspaceResources.</returns>
		[Obsolete("use Smartsheet.Api.SmartsheetClient.WorkspaceResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		WorkspaceResources Workspaces();

		/// <summary>
		/// <para>Returns the ImageUrlResources instance that provides access to image Url resources.</para>
		/// </summary>
		/// <returns> the image Url resources instance </returns>
		ImageUrlsResources ImageUrlResources { get; }
	}
}