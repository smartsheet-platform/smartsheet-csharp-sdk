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
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]
namespace Smartsheet.Api.Internal
{
    using System;
    using System.IO;
    using System.ComponentModel;
    using System.Threading;
    using System.Reflection;
    using System.Diagnostics;
    using NLog;
    using RestSharp;
    using Api.Internal.Json;
    using Api.Internal.Util;
    using DefaultHttpClient = Api.Internal.Http.DefaultHttpClient;
    using HttpClient = Api.Internal.Http.HttpClient;
    using HttpResponse = Api.Internal.Http.HttpResponse;
    using Utils = Api.Internal.Utility.Utility;
    using System.Net;

    /// <summary>
    /// This is the implementation of Smartsheet interface.
    /// 
    /// Thread Safety: This class is thread safe because all its mutable fields are safe-guarded using AtomicReference to
    /// ensure atomic modifications, and also the underlying HttpClient and JsonSerializer interfaces are thread safe.
    /// </summary>
    public class SmartsheetImpl : SmartsheetClient
    {
        /// <summary>
        /// Represents the HttpClient.
        /// 
        /// It will be initialized in the constructor and will not change afterwards.
        /// </summary>
        private readonly HttpClient httpClient;

        /// <summary>
        /// Represents the JsonSerializer.
        /// 
        /// It will be initialized in the constructor and will not change afterwards.
        /// </summary>
        private JsonSerializer jsonSerializer;

        /// <summary>
        /// Represents the base URI of the Smartsheet REST API.
        /// 
        /// It will be initialized in the constructor and will not change afterwards.
        /// </summary>
        private System.Uri baseURI;

        /// <summary>
        /// Represents the AtomicReference for the access token.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and can be set via corresponding setter, therefore effectively the access token can be updated in the
        /// SmartsheetImpl in thread safe manner.
        /// </summary>
        private string accessToken;

        /// <summary>
        /// Represents the AtomicReference for assumed user email.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and can be set via corresponding setter, therefore effectively the assumed user can be updated in the
        /// SmartsheetImpl in thread safe manner.
        /// </summary>
        private string assumedUser;

        /// <summary>
        /// Represents the AtomicReference for the change agent.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and can be set via corresponding setter, therefore effectively the assumed user can be updated in the
        /// SmartsheetImpl in thread safe manner.
        /// </summary>
        private string changeAgent;

        /// <summary>
        /// Represents the AtomicReference to HomeResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and will be initialized to non-null the first time it is accessed via corresponding getter, therefore
        /// effectively the underlying value is lazily created in a thread safe manner.
        /// </summary>
        private HomeResources home;

        /// <summary>
        /// Represents the AtomicReference to WorkspaceResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and will be initialized to non-null the first time it is accessed via corresponding getter, therefore
        /// effectively the underlying value is lazily created in a thread safe manner.
        /// </summary>
        private WorkspaceResources workspaces;

        /// <summary>
        /// Represents the AtomicReference to FolderResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and will be initialized to non-null at the first time it is accessed via corresponding getter, therefore
        /// effectively the underlying value is lazily created in a thread safe manner.
        /// </summary>
        private FolderResources folders;

        /// <summary>
        /// Represents the AtomicReference to TemplateResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and will be initialized to non-null at the first time it is accessed via corresponding getter, therefore
        /// effectively the underlying value is lazily created in a thread safe manner.
        /// </summary>
        private TemplateResources templates;

        /// <summary>
        /// Represents the AtomicReference to ReportResources.
        /// 
        /// It will be initialized in constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and will be initialized to non-null the first time it is accessed via corresponding getter, therefore
        /// effectively the underlying value is lazily created in a thread safe manner.
        /// </summary>
        private ReportResources reports;

        /// <summary>
        /// Represents the AtomicReference to SheetResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and will be initialized to non-null the first time it is accessed via corresponding getter, therefore
        /// effectively the underlying value is lazily created in a thread safe manner.
        /// </summary>
        private SheetResources sheets;

        /// <summary>
        /// Represents the AtomicReference to SightResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and will be initialized to non-null the first time it is accessed via corresponding getter, therefore
        /// effectively the underlying value is lazily created in a thread safe manner.
        /// </summary>
        private SightResources sights;
        /// <summary>
        /// Represents the AtomicReference to WebhookResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and will be initialized to non-null the first time it is accessed via corresponding getter, therefore
        /// effectively the underlying value is lazily created in a thread safe manner.
        /// </summary>
        private WebhookResources webhooks;

        /// <summary>
        /// Represents the AtomicReference to UserResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and will be initialized to non-null the first time it is accessed via corresponding getter, therefore
        /// effectively the underlying value is lazily created in a thread safe manner.
        /// </summary>
        private UserResources users;

        /// <summary>
        /// Represents the AtomicReference to SearchResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and will be initialized to non-null the first time it is accessed via corresponding getter, therefore
        /// effectively the underlying value is lazily created in a thread safe manner.
        /// </summary>
        private SearchResources search;

        /// <summary>
        /// Represents the AtomicReference to ServerInfoResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and will be initialized to non-null the first time it is accessed via corresponding getter, therefore
        /// effectively the underlying value is lazily created in a thread safe manner.
        /// </summary>
        private ServerInfoResources serverInfo;

        /// <summary>
        /// Represents the AtomicReference to GroupResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and will be initialized to non-null the first time it is accessed via corresponding getter, therefore
        /// effectively the underlying value is lazily created in a thread safe manner.
        /// </summary>
        private GroupResources groups;

        /// <summary>
        /// Represents the AtomicReference to FavoriteResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and will be initialized to non-null the first time it is accessed via corresponding getter, therefore
        /// effectively the underlying value is lazily created in a thread safe manner.
        /// </summary>
        private FavoriteResources favorites;

        /// <summary>
        /// Represents the AtomicReference to TokenResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and will be initialized to non-null the first time it is accessed via corresponding getter, therefore
        /// effectively the underlying value is lazily created in a thread safe manner.
        /// </summary>
        private TokenResources tokens;

        /// <summary>
        /// Represents the AtomicReference to ContactResources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and will be initialized to non-null the first time it is accessed via corresponding getter, therefore
        /// effectively the underlying value is lazily created in a thread safe manner.
        /// </summary>
        private ContactResources contacts;

        /// <summary>
        /// Represents the AtomicReference for image Urls.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and can be set via corresponding setter, therefore effectively the assumed user can be updated in the
        /// SmartsheetImpl in thread safe manner.
        /// </summary>
        private ImageUrlsResources imageUrls;

        /// <summary>
        /// Represents the AtomicReference for passthrough resources.
        /// 
        /// It will be initialized in the constructor and will not change afterwards. The underlying value will be initially set
        /// as null, and can be set via corresponding setter, therefore effectively the assumed user can be updated in the
        /// SmartsheetImpl in thread safe manner.
        /// </summary>
        private PassthroughResources passthrough;

        /// <summary>
        /// static logger 
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Creates an instance with given server URI, HttpClient (optional), and JsonSerializer (optional)
        /// 
        /// Exceptions: - IllegalArgumentException : if serverURI/Version/AccessToken is null/empty
        /// </summary>
        /// <param name="baseURI"> the server uri </param>
        /// <param name="accessToken"> the access token </param>
        /// <param name="httpClient"> the HTTP client (optional) </param>
        /// <param name="jsonSerializer"> the JSON serializer (optional) </param>
        public SmartsheetImpl(string baseURI, string accessToken, HttpClient httpClient, JsonSerializer jsonSerializer)
        {
            Utils.ThrowIfNull(baseURI);
            Utils.ThrowIfEmpty(baseURI);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            this.baseURI = new Uri(baseURI);
            this.accessToken = accessToken;
            this.jsonSerializer = jsonSerializer == null ? new JsonNetSerializer() : jsonSerializer;
            this.httpClient = httpClient == null ? new DefaultHttpClient(new RestClient(), this.jsonSerializer) : httpClient;
            this.UserAgent = null;
        }

        /// <summary>
        /// Finalizes the object, this method is overridden to close the HttpClient.
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
            get { return httpClient; }
        }

        /// <summary>
        /// Getter of corresponding field.
        /// </summary>
        /// <returns> corresponding field </returns>
        public virtual JsonSerializer JsonSerializer
        {
            get { return jsonSerializer; }
        }

        /// <summary>
        /// Getter of corresponding field.
        /// 
        /// Returns: corresponding field.
        /// </summary>
        /// <returns> the base uri </returns>
        public Uri BaseURI
        {
            get { return baseURI; }
        }

        /// <summary>
        /// Return the access token
        /// </summary>
        /// <returns> the access token </returns>
        public string AccessToken
        {
            get { return accessToken; }
            set  { this.accessToken = value;    }
        }

        /// <summary>
        /// Return the assumed user.
        /// </summary>
        /// <returns> the assumed user </returns>
        public string AssumedUser
        {
            get { return assumedUser; }
            set { this.assumedUser = value; }
        }

        /// <summary>
        /// Return the change agent
        /// </summary>
        /// <returns> the change agent </returns>
        public string ChangeAgent
        {
            get { return changeAgent; }
            set { this.changeAgent = value; }
        }

        /// <summary>
        /// Set the RestSharp default user agent
        /// </summary>
        public string UserAgent
        {
            set { 
                if(this.httpClient is DefaultHttpClient)
                    ((DefaultHttpClient)this.httpClient).SetUserAgent(GenerateUserAgent(value));
            }
        }

        /// <summary>
        /// Set the maximum retry timeout
        /// </summary>
        public long MaxRetryTimeout
        {
            set
            {
                if (this.httpClient is DefaultHttpClient)
                    ((DefaultHttpClient)this.httpClient).SetMaxRetryTimeout(value);
            }
        }

        /// <summary>
        /// Returns the HomeResources instance that provides access to home resources.
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
        /// Returns the WorkspaceResources instance that provides access to workspace resources.
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
        /// Returns the FolderResources instance that provides access to folder resources.
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
        /// Returns the TemplateResources instance that provides access to template resources.
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
        /// Returns the ReportResources instance that provides access to report resources.
        /// </summary>
        /// <returns> the report resources </returns>
        public virtual ReportResources ReportResources
        {
            get
            {
                Interlocked.CompareExchange<ReportResources>(ref reports, new ReportResourcesImpl(this), null);
                return reports;
            }
        }

        /// <summary>
        /// Returns the SheetResources instance that provides access to sheet resources.
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
        /// Returns the SightResources instance that provides access to Sight resources.
        /// </summary>
        /// <returns> the Sight resources </returns>
        public virtual SightResources SightResources
        {
            get
            {
                Interlocked.CompareExchange<SightResources>(ref sights, new SightResourcesImpl(this), null);
                return sights;
            }
        }

        /// <summary>
        /// Returns the WebhookResources instance that provides access to webhook resources.
        /// </summary>
        /// <returns> the webhook resources </returns>
        public virtual WebhookResources WebhookResources
        {
            get
            {
                Interlocked.CompareExchange<WebhookResources>(ref webhooks, new WebhookResourcesImpl(this), null);
                return webhooks;
            }
        }

        /// <summary>
        /// Returns the UserResources instance that provides access to user resources.
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
        /// Returns the SearchResources instance that provides access to searching resources.
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
        /// Returns the ServerInfoResources instance that provides access to server information resources.
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
        /// Returns the GroupResources instance that provides access to group resources.
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
        /// Returns the FavoriteResources instance that provides access to favorite resources.
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
        /// Returns the TokenResources instance that provides access to token resources.
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
        /// Returns the ContactResources instance that provides access to contacts resources.
        /// </summary>
        /// <returns> the contacts resources </returns>
        public virtual ContactResources ContactResources
        {
            get
            {
                Interlocked.CompareExchange<ContactResources>(ref contacts, new ContactResourcesImpl(this), null);
                return contacts;
            }
        }

        /// <summary>
        /// Returns the ImageUrlResources instance that provides access to image URL resources.
        /// </summary>
        /// <returns> the image URL resources </returns>
        public virtual ImageUrlsResources ImageUrlResources
        {
            get
            {
                Interlocked.CompareExchange<ImageUrlsResources>(ref imageUrls, new ImageUrlsResourcesImpl(this), null);
                return imageUrls;
            }
        }

        /// <summary>
        /// Returns the PassthroughResources instance that provides access to passthrough resources.
        /// </summary>
        /// <returns> the passthrough resources </returns>
        public virtual PassthroughResources PassthroughResources
        {
            get
            {
                Interlocked.CompareExchange<PassthroughResources>(ref passthrough, new PassthroughResourcesImpl(this), null);
                return passthrough;
            }
        }

        /// <summary>
        /// Compose a User-Agent string that represents this version of the SDK (along with platform info)
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns> a User-Agent string </returns>
        private string GenerateUserAgent(string userAgent)
        {
            // Set User Agent
            string thisVersion = "";
            string title = "";
            Assembly assembly = Assembly.GetCallingAssembly();
            if (assembly != null)
            {
                thisVersion = assembly.GetName().Version.ToString();
                title = assembly.GetName().Name;
            }
            if (userAgent == null)
            {
                assembly = Assembly.GetEntryAssembly();
                if (assembly != null)
                {
                    string[] strings = assembly.GetName().ToString().Split(',');
                    if (strings.Length > 0)
                        userAgent = strings[0];
                }
            }
            return title + "/" + thisVersion + "/" + userAgent + "/" + Utils.GetOSFriendlyName();
        }
    }
}
