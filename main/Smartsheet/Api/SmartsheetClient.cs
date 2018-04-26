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
        /// Set the access token to use.
        /// </summary>
        string AccessToken { set; }

        /// <summary>
        /// Set the email of the user to assume
        /// </summary>
        string AssumedUser { set; }

        /// <summary>
        /// Set the change agent identifier
        /// </summary>
        string ChangeAgent { set; }

        /// <summary>
        /// Set the user agent header string
        /// </summary>
        string UserAgent { set; }

        /// <summary>
        /// Sets the max retyr time if the HtppClient is an instance of DefaultHttpClient
        /// </summary>
        long MaxRetryTimeout { set; }

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
        /// <para>Returns the WebhookResources instance that provides access to webhook resources.</para>
        /// </summary>
        /// <returns> the webhook resources instance </returns>
        WebhookResources WebhookResources { get; }

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
        /// <para>Returns the ImageUrlResources instance that provides access to image Url resources.</para>
        /// </summary>
        /// <returns> the image Url resources instance </returns>
        ImageUrlsResources ImageUrlResources { get; }

        /// <summary>
        /// <para>Returns the PassthroughResources instance that provides access to passthrough resources.</para>
        /// </summary>
        /// <returns> the passthrough resources instance </returns>
        PassthroughResources PassthroughResources { get; }
    }
}