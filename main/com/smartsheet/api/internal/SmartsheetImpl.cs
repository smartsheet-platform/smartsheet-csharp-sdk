namespace com.smartsheet.api.@internal
{

    using System;
    using System.Threading;
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




    using DefaultHttpClient = com.smartsheet.api.@internal.http.DefaultHttpClient;
    using HttpClient = com.smartsheet.api.@internal.http.HttpClient;
    using JacksonJsonSerializer = com.smartsheet.api.@internal.json.JacksonJsonSerializer;
    using JsonSerializer = com.smartsheet.api.@internal.json.JsonSerializer;
    using Util = com.smartsheet.api.@internal.util.Util;

	/// <summary>
	/// This is the implementation of Smartsheet interface.
	/// 
	/// Thread Safety: This class is thread safe because all its mutable fields are safe-guarded using AtomicReference to
	/// ensure atomic modifications, and also the underlying HttpClient and JsonSerializer interfaces are thread safe.
	/// </summary>
	public class SmartsheetImpl : Smartsheet
	{
		/// <summary>
		/// Represents the HttpClient.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private readonly HttpClient httpClient_Renamed;

		/// <summary>
		/// Represents the JsonSerializer.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private JsonSerializer jsonSerializer_Renamed;

		/// <summary>
		/// Represents the base URI of the Smartsheet REST API.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private System.Uri baseURI_Renamed;

		/// <summary>
		/// Represents the AtomicReference to HomeResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying value will be initially set
		/// as null, and will be initialized to non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying value is lazily created in a thread safe manner.
		/// </summary>
        private HomeResources home;

		/// <summary>
		/// Represents the AtomicReference to WorkspaceResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying value will be initially set
		/// as null, and will be initialized to non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying value is lazily created in a thread safe manner.
		/// </summary>
		private WorkspaceResources workspaces;

		/// <summary>
		/// Represents the AtomicReference to FolderResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying value will be initially set
		/// as null, and will be initialized to non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying value is lazily created in a thread safe manner.
		/// </summary>
		private FolderResources folders;

		/// <summary>
		/// Represents the AtomicReference to TemplateResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying value will be initially set
		/// as null, and will be initialized to non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying value is lazily created in a thread safe manner.
		/// </summary>
		private TemplateResources templates;

		/// <summary>
		/// Represents the AtomicReference to SheetResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying value will be initially set
		/// as null, and will be initialized to non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying value is lazily created in a thread safe manner.
		/// </summary>
		private SheetResources sheets;

		/// <summary>
		/// Represents the AtomicReference to ColumnResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying value will be initially set
		/// as null, and will be initialized to non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying value is lazily created in a thread safe manner.
		/// </summary>
		private ColumnResources columns;

		/// <summary>
		/// Represents the AtomicReference to RowResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying value will be initially set
		/// as null, and will be initialized to non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying value is lazily created in a thread safe manner.
		/// </summary>
		private RowResources rows;

		/// <summary>
		/// Represents the AtomicReference to AttachmentResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying value will be initially set
		/// as null, and will be initialized to non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying value is lazily created in a thread safe manner.
		/// </summary>
		private AttachmentResources attachments;

		/// <summary>
		/// Represents the AtomicReference to DiscussionResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying value will be initially set
		/// as null, and will be initialized to non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying value is lazily created in a thread safe manner.
		/// </summary>
		private DiscussionResources discussions;

		/// <summary>
		/// Represents the AtomicReference to CommentResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying value will be initially set
		/// as null, and will be initialized to non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying value is lazily created in a thread safe manner.
		/// </summary>
		private CommentResources comments;

		/// <summary>
		/// Represents the AtomicReference to UserResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying value will be initially set
		/// as null, and will be initialized to non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying value is lazily created in a thread safe manner.
		/// </summary>
		private UserResources users;

		/// <summary>
		/// Represents the AtomicReference to SearchResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying value will be initially set
		/// as null, and will be initialized to non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying value is lazily created in a thread safe manner.
		/// </summary>
		private SearchResources search;

		/// <summary>
		/// Represents the AtomicReference for assumed user email.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying value will be initially set
		/// as null, and can be set via corresponding setter, therefore effectively the assumed user can be updated in the
		/// SmartsheetImpl in thread safe manner.
		/// </summary>
		private string assumedUser_Renamed;

		/// <summary>
		/// Represents the AtomicReference for access token.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying value will be initially set
		/// as null, and can be set via corresponding setter, therefore effectively the access token can be updated in the
		/// SmartsheetImpl in thread safe manner.
		/// </summary>
		private string accessToken_Renamed;

		/// <summary>
		/// Create an instance with given server URI, HttpClient (optional) and JsonSerializer (optional)
		/// 
		/// Exceptions: - IllegalArgumentException : if serverURI/version/accessToken is null/empty
		/// </summary>
		/// <param name="baseURI"> the server uri </param>
		/// <param name="accessToken"> the access token </param>
		/// <param name="httpClient"> the http client (optional) </param>
		/// <param name="jsonSerializer"> the json serializer (optional) </param>
		public SmartsheetImpl(string baseURI, string accessToken, HttpClient httpClient, JsonSerializer jsonSerializer)
		{
			Util.ThrowIfNull(baseURI);
			Util.ThrowIfEmpty(baseURI);

			this.baseURI_Renamed = new Uri(baseURI);
			this.httpClient_Renamed = httpClient == null ? new DefaultHttpClient() : httpClient;
			this.jsonSerializer_Renamed = jsonSerializer == null ? new JacksonJsonSerializer() : jsonSerializer;
			this.accessToken_Renamed = accessToken;
		}

		/// <summary>
		/// Finalize the object, this method is overridden to close the HttpClient.
		/// </summary>
		/// <exception cref="IOException"> Signals that an I/O exception has occurred. </exception>
		~SmartsheetImpl()
		{
			this.httpClient_Renamed.Close();
		}

		/// <summary>
		/// Getter of corresponding field.
		/// </summary>
		/// <returns> corresponding field. </returns>
		public virtual HttpClient httpClient
		{
			get
			{
				return httpClient_Renamed;
			}
		}

		/// <summary>
		/// Getter of corresponding field.
		/// </summary>
		/// <returns> corresponding field </returns>
		public virtual JsonSerializer jsonSerializer
		{
			get
			{
				return jsonSerializer_Renamed;
			}
		}

		/// <summary>
		/// Getter of corresponding field.
		/// 
		/// Returns: corresponding field.
		/// </summary>
		/// <returns> the base uri </returns>
		public Uri baseURI
		{
			get
			{
				return baseURI_Renamed;
			}
		}

		/// <summary>
		/// Return the assumed user.
		/// </summary>
		/// <returns> the assumed user </returns>
		public string assumedUser
		{
			get
			{
				return assumedUser_Renamed;
			}
			set
			{
				this.assumedUser_Renamed = value;
			}
		}

		/// <summary>
		/// Return the access token
		/// </summary>
		/// <returns> the access token </returns>
		public string accessToken
		{
			get
			{
				return accessToken_Renamed;
			}
			set
			{
				this.accessToken_Renamed = value;
			}
		}

		/// <summary>
		/// Returns the HomeResources instance that provides access to Home resources.
		/// </summary>
		/// <returns> the home resources </returns>
		public virtual HomeResources Home()
		{
            Interlocked.CompareExchange<HomeResources>(ref home, new HomeResourcesImpl(this), null);
            return home;
		}

		/// <summary>
		/// Returns the WorkspaceResources instance that provides access to Workspace resources.
		/// </summary>
		/// <returns> the workspace resources </returns>
		public virtual WorkspaceResources Workspaces()
		{
            Interlocked.CompareExchange<WorkspaceResources>(ref workspaces, new WorkspaceResourcesImpl(this), null);
            return workspaces;
		}

		/// <summary>
		/// Returns the FolderResources instance that provides access to Folder resources.
		/// </summary>
		/// <returns> the folder resources </returns>
		public virtual FolderResources Folders()
		{
            Interlocked.CompareExchange<FolderResources>(ref folders, new FolderResourcesImpl(this), null);
            return folders;
		}

		/// <summary>
		/// Returns the TemplateResources instance that provides access to Template resources.
		/// </summary>
		/// <returns> the template resources </returns>
		public virtual TemplateResources Templates()
		{
            Interlocked.CompareExchange<TemplateResources>(ref templates, new TemplateResourcesImpl(this), null);
            return templates;
		}

		/// <summary>
		/// Returns the SheetResources instance that provides access to Sheet resources.
		/// </summary>
		/// <returns> the sheet resources </returns>
		public virtual SheetResources Sheets()
		{
            Interlocked.CompareExchange<SheetResources>(ref sheets, new SheetResourcesImpl(this), null);
            return sheets;
		}

		/// <summary>
		/// Returns the ColumnResources instance that provides access to Column resources.
		/// </summary>
		/// <returns> the column resources </returns>
		public virtual ColumnResources Columns()
		{
            Interlocked.CompareExchange<ColumnResources>(ref columns, new ColumnResourcesImpl(this), null);
            return columns;
		}

		/// <summary>
		/// Returns the RowResources instance that provides access to Row resources.
		/// </summary>
		/// <returns> the row resources </returns>
		public virtual RowResources Rows()
		{
            Interlocked.CompareExchange<RowResources>(ref rows, new RowResourcesImpl(this), null);
            return rows;
		}

		/// <summary>
		/// Returns the AttachmentResources instance that provides access to Attachment resources.
		/// </summary>
		/// <returns> the attachment resources </returns>
		public virtual AttachmentResources Attachments()
		{
            Interlocked.CompareExchange<AttachmentResources>(ref attachments, new AttachmentResourcesImpl(this), null);
            return attachments;
		}

		/// <summary>
		/// Returns the DiscussionResources instance that provides access to Discussion resources.
		/// </summary>
		/// <returns> the discussion resources </returns>
		public virtual DiscussionResources Discussions()
		{
            Interlocked.CompareExchange<DiscussionResources>(ref discussions, new DiscussionResourcesImpl(this), null);
            return discussions;
		}

		/// <summary>
		/// Returns the CommentResources instance that provides access to Comment resources.
		/// </summary>
		/// <returns> the comment resources </returns>
		public virtual CommentResources Comments()
		{
            Interlocked.CompareExchange<CommentResources>(ref comments, new CommentResourcesImpl(this), null);
            return comments;
		}

		/// <summary>
		/// Returns the UserResources instance that provides access to User resources.
		/// </summary>
		/// <returns> the user resources </returns>
		public virtual UserResources Users()
		{
            Interlocked.CompareExchange<UserResources>(ref users, new UserResourcesImpl(this), null);
            return users;
		}

		/// <summary>
		/// Returns the SearchResources instance that provides access to searching resources.
		/// </summary>
		/// <returns> the search resources </returns>
		public virtual SearchResources Search()
		{
            Interlocked.CompareExchange<SearchResources>(ref search, new SearchResourcesImpl(this), null);
            return search;
		}


	}

}