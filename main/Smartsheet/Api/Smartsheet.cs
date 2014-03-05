namespace Smartsheet.Api
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
	/// <para>This interface is the entry point of the Smartsheet SDK, it provides convenient methods To get XXXResources instances
	/// for accessing different types of resources.</para>
	/// 
	/// <para>Thread Safety: Implementation of this interface must be thread safe.</para>
	/// </summary>
	//TODO: could put some example Code in the documentation.
	public interface Smartsheet
	{

		/// <summary>
		/// <para>Returns the HomeResources instance that provides access To Home resources.</para>
		/// </summary>
		/// <returns> the home resources instance </returns>
		HomeResources Home();

		/// <summary>
		/// <para>Returns the WorkspaceResources instance that provides access To Workspace resources.</para>
		/// </summary>
		/// <returns> the workspace resources instance </returns>
		WorkspaceResources Workspaces();

		/// <summary>
		/// <para>Returns the FolderResources instance that provides access To Folder resources.</para>
		/// </summary>
		/// <returns> the folder resources instance </returns>
		FolderResources Folders();

		/// <summary>
		/// <para>Returns the TemplateResources instance that provides access To Template resources.</para>
		/// </summary>
		/// <returns> the template resources instance </returns>
		TemplateResources Templates();

		/// <summary>
		/// <para>Returns the SheetResources instance that provides access To Sheet resources.</para>
		/// </summary>
		/// <returns> the sheet resources instance </returns>
		SheetResources Sheets();

		/// <summary>
		/// <para>Returns the ColumnResources instance that provides access To Column resources.</para>
		/// </summary>
		/// <returns> the column resources instance </returns>
		ColumnResources Columns();

		/// <summary>
		/// <para>Returns the RowResources instance that provides access To Row resources.</para>
		/// </summary>
		/// <returns> the row resources instance </returns>
		RowResources Rows();

		/// <summary>
		/// <para>Returns the AttachmentResources instance that provides access To Attachment resources.</para>
		/// </summary>
		/// <returns> the attachment resources instance </returns>
		AttachmentResources Attachments();

		/// <summary>
		/// <para>Returns the DiscussionResources instance that provides access To Discussion resources.</para>
		/// </summary>
		/// <returns> the discussion resources instance </returns>
		DiscussionResources Discussions();

		/// <summary>
		/// <para>Returns the CommentResources instance that provides access To Comment resources.</para>
		/// </summary>
		/// <returns> the Comment resources instance </returns>
		CommentResources Comments();

		/// <summary>
		/// <para>Returns the UserResources instance that provides access To User resources.</para>
		/// </summary>
		/// <returns> the user resources instance </returns>
		UserResources Users();

		/// <summary>
		/// <para>Returns the SearchResources instance that provides access To searching resources.</para>
		/// </summary>
		/// <returns> the search resources instance </returns>
		SearchResources Search();

		/// <summary>
		/// <para>Set the Email of the user To assume.</para>
		/// </summary>
		/// <param Name="AssumedUser"> the new assumed user </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null/empty string </exception>
		string AssumedUser {set;}

		/// <summary>
		/// <para>Set the access token To use.</para>
		/// </summary>
		/// <param Name="AccessToken"> the new access token </param>
		/// <exception cref="System.InvalidOperationException"> if any argument is null/empty string </exception>
		string AccessToken {set;}
	}

}