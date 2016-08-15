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
namespace Smartsheet.Api.Internal
{

	using System;
	using System.ComponentModel;
	using System.Threading;
	using DefaultHttpClient = Api.Internal.Http.DefaultHttpClient;
	using HttpClient = Api.Internal.Http.HttpClient;
	using JsonNetSerializer = Api.Internal.Json.JsonNetSerializer;
	using JsonSerializer = Api.Internal.Json.JsonSerializer;
	using Utils = Api.Internal.Utility.Utility;

	/// <summary>
	/// This is the implementation of Smartsheet interface.
	/// 
	/// Thread Safety: This class is thread safe because all its mutable fields are safe-guarded using AtomicReference To
	/// ensure atomic modifications, and also the underlying HttpClient and JsonSerializer interfaces are thread safe.
	/// </summary>
	public class SmartsheetImpl : SmartsheetClient
	{
		/// <summary>
		/// Represents the HttpClient.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private readonly HttpClient httpClient;

		/// <summary>
		/// Represents the JsonSerializer.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private JsonSerializer jsonSerializer;

		/// <summary>
		/// Represents the base URI of the Smartsheet REST API.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private System.Uri baseURI;

		/// <summary>
		/// Represents the AtomicReference To HomeResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying Value is lazily created in a thread safe manner.
		/// </summary>
		private HomeResources home;

		/// <summary>
		/// Represents the AtomicReference To WorkspaceResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying Value is lazily created in a thread safe manner.
		/// </summary>
		private WorkspaceResources workspaces;

		/// <summary>
		/// Represents the AtomicReference To FolderResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying Value is lazily created in a thread safe manner.
		/// </summary>
		private FolderResources folders;

		/// <summary>
		/// Represents the AtomicReference To TemplateResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying Value is lazily created in a thread safe manner.
		/// </summary>
		private TemplateResources templates;

		/// <summary>
		/// Represents the AtomicReference To ReportResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying Value is lazily created in a thread safe manner.
		/// </summary>
		private ReportResources reports;

		/// <summary>
		/// Represents the AtomicReference To SheetResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying Value is lazily created in a thread safe manner.
		/// </summary>
		private SheetResources sheets;

		/// <summary>
		/// Represents the AtomicReference To SightResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying Value is lazily created in a thread safe manner.
		/// </summary>
		private SightResources sights;		

		///// <summary>
		///// Represents the AtomicReference To ColumnResources.
		///// 
		///// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		///// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		///// effectively the underlying Value is lazily created in a thread safe manner.
		///// </summary>
		//private ColumnResources columns;

		///// <summary>
		///// Represents the AtomicReference To RowResources.
		///// 
		///// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		///// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		///// effectively the underlying Value is lazily created in a thread safe manner.
		///// </summary>
		//private RowResources rows;

		///// <summary>
		///// Represents the AtomicReference To AttachmentResources.
		///// 
		///// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		///// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		///// effectively the underlying Value is lazily created in a thread safe manner.
		///// </summary>
		//private AttachmentResources attachments;

		///// <summary>
		///// Represents the AtomicReference To DiscussionResources.
		///// 
		///// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		///// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		///// effectively the underlying Value is lazily created in a thread safe manner.
		///// </summary>
		//private DiscussionResources discussions;

		///// <summary>
		///// Represents the AtomicReference To CommentResources.
		///// 
		///// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		///// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		///// effectively the underlying Value is lazily created in a thread safe manner.
		///// </summary>
		//private CommentResources comments;



		/// <summary>
		/// Represents the AtomicReference To UserResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying Value is lazily created in a thread safe manner.
		/// </summary>
		private UserResources users;

		/// <summary>
		/// Represents the AtomicReference To SearchResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying Value is lazily created in a thread safe manner.
		/// </summary>
		private SearchResources search;

		/// <summary>
		/// Represents the AtomicReference To ServerInfoResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying Value is lazily created in a thread safe manner.
		/// </summary>
		private ServerInfoResources serverInfo;

		/// <summary>
		/// Represents the AtomicReference To GroupResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying Value is lazily created in a thread safe manner.
		/// </summary>
		private GroupResources groups;

		/// <summary>
		/// Represents the AtomicReference To FavoriteResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying Value is lazily created in a thread safe manner.
		/// </summary>
		private FavoriteResources favorites;

		/// <summary>
		/// Represents the AtomicReference To TokenResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying Value is lazily created in a thread safe manner.
		/// </summary>
		private TokenResources tokens;

		/// <summary>
		/// Represents the AtomicReference To ContactResources.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and will be initialized To non-null at the first time it is accessed via corresponding getter, therefore
		/// effectively the underlying Value is lazily created in a thread safe manner.
		/// </summary>
		private ContactResources contacts;

		/// <summary>
		/// Represents the AtomicReference for assumed user Email.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and can be set via corresponding setter, therefore effectively the assumed user can be updated in the
		/// SmartsheetImpl in thread safe manner.
		/// </summary>
		private string assumedUser;

		/// <summary>
		/// Represents the AtomicReference for access token.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and can be set via corresponding setter, therefore effectively the access token can be updated in the
		/// SmartsheetImpl in thread safe manner.
		/// </summary>
		private string accessToken;

		/// <summary>
		/// Represents the AtomicReference for image Urls.
		/// 
		/// It will be initialized in constructor and will not change afterwards. The underlying Value will be initially set
		/// as null, and can be set via corresponding setter, therefore effectively the assumed user can be updated in the
		/// SmartsheetImpl in thread safe manner.
		/// </summary>
		private ImageUrlsResources imageUrls;

		/// <summary>
		/// Create an instance with given server URI, HttpClient (optional) and JsonSerializer (optional)
		/// 
		/// Exceptions: - IllegalArgumentException : if serverURI/Version/AccessToken is null/empty
		/// </summary>
		/// <param name="baseURI"> the server uri </param>
		/// <param name="accessToken"> the access token </param>
		/// <param name="httpClient"> the http client (optional) </param>
		/// <param name="jsonSerializer"> the Json serializer (optional) </param>
		public SmartsheetImpl(string baseURI, string accessToken, HttpClient httpClient, JsonSerializer jsonSerializer)
		{
			Utils.ThrowIfNull(baseURI);
			Utils.ThrowIfEmpty(baseURI);

			this.baseURI = new Uri(baseURI);
			this.httpClient = httpClient == null ? new DefaultHttpClient() : httpClient;
			this.jsonSerializer = jsonSerializer == null ? new JsonNetSerializer() : jsonSerializer;
			this.accessToken = accessToken;
		}

		/// <summary>
		/// Finalize the object, this method is overridden To close the HttpClient.
		/// </summary>
		/// <exception cref="System.IO.IOException"> Signals that an I/O exception has occurred. </exception>
		~SmartsheetImpl()
		{
			this.httpClient.Close();
		}

		/// <summary>
		/// Getter of corresponding field.
		/// </summary>
		/// <returns> corresponding field. </returns>
		public virtual HttpClient HttpClient
		{
			get
			{
				return httpClient;
			}
		}

		/// <summary>
		/// Getter of corresponding field.
		/// </summary>
		/// <returns> corresponding field </returns>
		public virtual JsonSerializer JsonSerializer
		{
			get
			{
				return jsonSerializer;
			}
		}

		/// <summary>
		/// Getter of corresponding field.
		/// 
		/// Returns: corresponding field.
		/// </summary>
		/// <returns> the base uri </returns>
		public Uri BaseURI
		{
			get
			{
				return baseURI;
			}
		}

		/// <summary>
		/// Return the assumed user.
		/// </summary>
		/// <returns> the assumed user </returns>
		public string AssumedUser
		{
			get
			{
				return assumedUser;
			}
			set
			{
				this.assumedUser = value;
			}
		}

		/// <summary>
		/// Return the access token
		/// </summary>
		/// <returns> the access token </returns>
		public string AccessToken
		{
			get
			{
				return accessToken;
			}
			set
			{
				this.accessToken = value;
			}
		}

		/// <summary>
		/// Returns the HomeResources instance that provides access To Home resources.
		/// </summary>
		/// <returns> the home resources </returns>
		public virtual HomeResources HomeResources
		{
			get
			{
				Interlocked.CompareExchange<HomeResources>(ref home, new HomeResourcesImpl(this), null);
				return home;
			}
		}

		/// <summary>
		/// Returns the WorkspaceResources instance that provides access To Workspace resources.
		/// </summary>
		/// <returns> the workspace resources </returns>
		public virtual WorkspaceResources WorkspaceResources
		{
			get
			{
				Interlocked.CompareExchange<WorkspaceResources>(ref workspaces, new WorkspaceResourcesImpl(this), null);
				return workspaces;
			}
		}

		/// <summary>
		/// Returns the FolderResources instance that provides access To Folder resources.
		/// </summary>
		/// <returns> the folder resources </returns>
		public virtual FolderResources FolderResources
		{
			get
			{
				Interlocked.CompareExchange<FolderResources>(ref folders, new FolderResourcesImpl(this), null);
				return folders;
			}
		}

		/// <summary>
		/// Returns the TemplateResources instance that provides access To Template resources.
		/// </summary>
		/// <returns> the template resources </returns>
		public virtual TemplateResources TemplateResources
		{
			get
			{
				Interlocked.CompareExchange<TemplateResources>(ref templates, new TemplateResourcesImpl(this), null);
				return templates;
			}
		}


		/// <summary>
		/// Returns the TemplateResources instance that provides access To Template resources.
		/// </summary>
		/// <returns> the template resources </returns>
		public virtual ReportResources ReportResources
		{
			get
			{
				Interlocked.CompareExchange<ReportResources>(ref reports, new ReportResourcesImpl(this), null);
				return reports;
			}
		}

		/// <summary>
		/// Returns the SheetResources instance that provides access To Sheet resources.
		/// </summary>
		/// <returns> the sheet resources </returns>
		public virtual SheetResources SheetResources
		{
			get
			{
				Interlocked.CompareExchange<SheetResources>(ref sheets, new SheetResourcesImpl(this), null);
				return sheets;
			}
		}

		/// <summary>
		/// Returns the SightResources instance that provides access To Sight resources.
		/// </summary>
		/// <returns> the sight resources </returns>
		public virtual SightResources SightResources
		{
			get
			{
				Interlocked.CompareExchange<SightResources>(ref sights, new SightResourcesImpl(this), null);
				return sights;
			}
		}

		///// <summary>
		///// Returns the ColumnResources instance that provides access To Column resources.
		///// </summary>
		///// <returns> the column resources </returns>
		//public virtual ColumnResources Columns()
		//{
		//	Interlocked.CompareExchange<ColumnResources>(ref columns, new ColumnResourcesImpl(this), null);
		//	return columns;
		//}

		///// <summary>
		///// Returns the RowResources instance that provides access To Row resources.
		///// </summary>
		///// <returns> the row resources </returns>
		//public virtual RowResources Rows()
		//{
		//		Interlocked.CompareExchange<RowResources>(ref rows, new RowResourcesImpl(this), null);
		//		return rows;
		//}

		///// <summary>
		///// Returns the AttachmentResources instance that provides access To Attachment resources.
		///// </summary>
		///// <returns> the attachment resources </returns>
		//public virtual AttachmentResources Attachments()
		//{
		//	Interlocked.CompareExchange<AttachmentResources>(ref attachments, new AttachmentResourcesImpl(this), null);
		//	return attachments;
		//}

		///// <summary>
		///// Returns the DiscussionResources instance that provides access To Discussion resources.
		///// </summary>
		///// <returns> the discussion resources </returns>
		//public virtual DiscussionResources Discussions()
		//{
		//	Interlocked.CompareExchange<DiscussionResources>(ref discussions, new DiscussionResourcesImpl(this), null);
		//	return discussions;
		//}

		///// <summary>
		///// Returns the CommentResources instance that provides access To Comment resources.
		///// </summary>
		///// <returns> the Comment resources </returns>
		//public virtual CommentResources Comments()
		//{
		//	Interlocked.CompareExchange<CommentResources>(ref comments, new CommentResourcesImpl(this), null);
		//	return comments;
		//}

		/// <summary>
		/// Returns the UserResources instance that provides access To User resources.
		/// </summary>
		/// <returns> the user resources </returns>
		public virtual UserResources UserResources
		{
			get
			{
				Interlocked.CompareExchange<UserResources>(ref users, new UserResourcesImpl(this), null);
				return users;
			}
		}

		/// <summary>
		/// Returns the SearchResources instance that provides access To searching resources.
		/// </summary>
		/// <returns> the search resources </returns>
		public virtual SearchResources SearchResources
		{
			get
			{
				Interlocked.CompareExchange<SearchResources>(ref search, new SearchResourcesImpl(this), null);
				return search;
			}
		}

		/// <summary>
		/// Returns the ServerInfoResources instance that provides access To server information resources.
		/// </summary>
		/// <returns> the server information resources </returns>
		public virtual ServerInfoResources ServerInfoResources
		{
			get
			{
				Interlocked.CompareExchange<ServerInfoResources>(ref serverInfo, new ServerInfoResourcesImpl(this), null);
				return serverInfo;
			}
		}

		/// <summary>
		/// Returns the GroupResources instance that provides access To group resources.
		/// </summary>
		/// <returns> the group resources </returns>
		public virtual GroupResources GroupResources
		{
			get
			{
				Interlocked.CompareExchange<GroupResources>(ref groups, new GroupResourcesImpl(this), null);
				return groups;
			}
		}

		/// <summary>
		/// Returns the FavoriteResources instance that provides access To favorite resources.
		/// </summary>
		/// <returns> the favorite resources </returns>
		public virtual FavoriteResources FavoriteResources
		{
			get
			{
				Interlocked.CompareExchange<FavoriteResources>(ref favorites, new FavoriteResourcesImpl(this), null);
				return favorites;
			}
		}

		/// <summary>
		/// Returns the TokenResources instance that provides access To token resources.
		/// </summary>
		/// <returns> the token resources </returns>
		public virtual TokenResources TokenResources
		{
			get
			{
				Interlocked.CompareExchange<TokenResources>(ref tokens, new TokenResourcesImpl(this), null);
				return tokens;
			}
		}

		/// <summary>
		/// Returns the ContactResources instance that provides access To contacts resources.
		/// </summary>
		/// <returns> the contacts resources </returns>
		public ContactResources ContactResources
		{
			get
			{
				Interlocked.CompareExchange<ContactResources>(ref contacts, new ContactResourcesImpl(this), null);
				return contacts;
			}
		}

		[Obsolete("use Smartsheet.Api.SmartsheetClient.HomeResources", true)]
		[EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public virtual HomeResources Home()
		{
			throw new NotSupportedException();
		}

		[Obsolete("use Smartsheet.Api.SmartsheetClient.SheetResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual SheetResources Sheets()
		{
			throw new NotSupportedException();
		}

		[Obsolete("use Smartsheet.Api.SmartsheetClient.ReportResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual ReportResources Reports()
		{
			throw new NotSupportedException();
		}

		[Obsolete("use Smartsheet.Api.SmartsheetClient.SheetResources.AttachmentResources to get sheet level attachment resources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual AttachmentResources Attachments()
		{
			throw new NotSupportedException();
		}

		[Obsolete("use Smartsheet.Api.SmartsheetClient.SheetResources.RowResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual RowResources Rows()
		{
			throw new NotSupportedException();
		}

		[Obsolete("use Smartsheet.Api.SmartsheetClient.SheetResources.CommentResources to get sheet level comment resources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual CommentResources Comments()
		{
			throw new NotSupportedException();
		}


		[Obsolete("use Smartsheet.Api.SmartsheetClient.UserResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual UserResources Users()
		{
			throw new NotSupportedException();
		}

		[Obsolete("use Smartsheet.Api.SmartsheetClient.SearchResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual SearchResources Search()
		{
			throw new NotSupportedException();
		}

		[Obsolete("use Smartsheet.Api.SmartsheetClient.TemplateResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual TemplateResources Templates()
		{
			throw new NotSupportedException();
		}

		[Obsolete("use Smartsheet.Api.SmartsheetClient.FolderResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual FolderResources Folders()
		{
			throw new NotSupportedException();
		}

		[Obsolete("use Smartsheet.Api.SmartsheetClient.WorkspaceResources", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual WorkspaceResources Workspaces()
		{
			throw new NotSupportedException();
		}

		public virtual ImageUrlsResources ImageUrlResources
		{
			get
			{
				Interlocked.CompareExchange<ImageUrlsResources>(ref imageUrls, new ImageUrlsResourcesImpl(this), null);
				return imageUrls;
			}
		}
	}
}