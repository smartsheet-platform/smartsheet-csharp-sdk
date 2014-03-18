using System;

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
		HomeResources Home();

		/// <summary>
		/// <para>Returns the WorkspaceResources instance that provides access to Workspace resources.</para>
		/// </summary>
		/// <returns> the workspace resources instance </returns>
		WorkspaceResources Workspaces();

		/// <summary>
		/// <para>Returns the FolderResources instance that provides access to Folder resources.</para>
		/// </summary>
		/// <returns> the folder resources instance </returns>
		FolderResources Folders();

		/// <summary>
		/// <para>Returns the TemplateResources instance that provides access to Template resources.</para>
		/// </summary>
		/// <returns> the template resources instance </returns>
		TemplateResources Templates();

		/// <summary>
		/// <para>Returns the SheetResources instance that provides access to Sheet resources.</para>
		/// </summary>
		/// <returns> the sheet resources instance </returns>
		SheetResources Sheets();

		/// <summary>
		/// <para>Returns the ColumnResources instance that provides access to Column resources.</para>
		/// </summary>
		/// <returns> the column resources instance </returns>
		ColumnResources Columns();

		/// <summary>
		/// <para>Returns the RowResources instance that provides access to Row resources.</para>
		/// </summary>
		/// <returns> the row resources instance </returns>
		RowResources Rows();

		/// <summary>
		/// <para>Returns the AttachmentResources instance that provides access to Attachment resources.</para>
		/// </summary>
		/// <returns> the attachment resources instance </returns>
		AttachmentResources Attachments();

		/// <summary>
		/// <para>Returns the DiscussionResources instance that provides access to Discussion resources.</para>
		/// </summary>
		/// <returns> the discussion resources instance </returns>
		DiscussionResources Discussions();

		/// <summary>
		/// <para>Returns the CommentResources instance that provides access to Comment resources.</para>
		/// </summary>
		/// <returns> the comment resources instance </returns>
		CommentResources Comments();

		/// <summary>
		/// <para>Returns the UserResources instance that provides access to User resources.</para>
		/// </summary>
		/// <returns> the user resources instance </returns>
		UserResources Users();

		/// <summary>
		/// <para>Returns the SearchResources instance that provides access to searching resources.</para>
		/// </summary>
		/// <returns> the search resources instance </returns>
		SearchResources Search();
	}

}