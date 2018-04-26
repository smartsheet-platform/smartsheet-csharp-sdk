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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Internal
{
    using System.Net;
    using Smartsheet.Api.Models;
    using Smartsheet.Api.Internal.Util;
    using Api.Internal.Http;

    public class WebhookResourcesImpl : AbstractResources, WebhookResources
    {
        /// <summary>
        /// Constructor.
        /// 
        /// Exceptions: - IllegalArgumentException : if any argument is null
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        public WebhookResourcesImpl(SmartsheetImpl smartsheet)
            : base(smartsheet)
        {

        }

        /// <summary>
        /// <para>Gets the list of all Webhooks that the user owns (if a user generated token was used to make the request)
        /// or the list of all Webhooks associated with the third-party app (if a third-party app made the request). Items 
        /// in the response are ordered by API Client name, then Webhook name, then creation date.</para>
        /// 
        /// <para>It mirrors to the following Smartsheet REST API method: GET /webhooks</para>
        /// </summary>
        /// <returns>IndexResult object containing an array of Webhook objects</returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual PaginatedResult<Webhook> ListWebhooks(PaginationParameters paging)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (paging != null)
            {
                parameters = paging.toDictionary();
            }

            return this.ListResourcesWithWrapper<Webhook>("webhooks" + QueryUtil.GenerateUrl(null, parameters));
        }

        /// <summary>
        /// <para>Gets the Webhook specified in the URL.</para>
        /// 
        /// <para>It mirrors to the following Smartsheet REST API method: GET /webhook/{webhookId}</para>
        /// </summary>
        /// <param name="webhookId"> the Id of the webhook </param>
        /// <returns> the webhook resource (note that if there is no such resource, this method will throw 
        /// ResourceNotFoundException rather than returning null). </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual Webhook GetWebhook(long webhookId)
        {
            return this.GetResource<Webhook>("webhooks/" + webhookId, typeof(Webhook));
        }

        /// <summary>
        /// <para>Creates a new Webhook.</para>
        /// <para>The request body is limited to name(required), callbackUrl (required), scope (required)
        /// scopeObjectId (required), events(required), version(required)</para>
        /// <para>It mirrors to the following Smartsheet REST API method:POST /webhooks</para>
        /// </summary>
        /// <param name="webhook"> the webhook to be created </param>
        /// <returns> the created webhook </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual Webhook CreateWebhook(Webhook webhook)
        {
            return this.CreateResource("webhooks", typeof(Webhook), webhook);
        }
        
        /// <summary>
        /// <para>Updates the Webhook specified in the URL.</para>
        /// <para>The request body is limited to the name, events, callbackUrl, enabled and version attributes.</para>
        /// <para>It mirrors to the following Smartsheet REST API method: PUT /webhooks/{webhookId}</para>
        /// </summary>
        /// <param name="webhook"> the webhook to update </param>
        /// <returns> the updated webhook </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual Webhook UpdateWebhook(Webhook webhook)
        {
            return this.UpdateResource("webhooks/" + webhook.Id, typeof(Webhook), webhook);
        }

        /// <summary>
        /// <para>Delete a webhook.</para>
        /// 
        /// <para>It mirrors to the following Smartsheet REST API method: DELETE /webhooks/{webhookId}</para>
        /// </summary>
        /// <param name="webhookId"> the sightId </param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual void DeleteWebhook(long webhookId)
        {
            this.DeleteResource<Webhook>("webhooks/" + webhookId, typeof(Webhook));
        }

        /// <summary>
        /// <para>Resets the shared secret for the specified Webhook. For more information about how a shared secret is used, see Authenticating Callbacks.</para>
        /// <para>The request body should be empty</para>
        /// <para>It mirrors to the following Smartsheet REST API method: POST /webhooks/{webhookId}/resetsharedsecret</para>
        /// </summary>
        /// <param name="webhookId"> the sightId </param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual WebhookSharedSecret ResetSharedSecret(long webhookId)
        {
            HttpRequest request = null;
            try
            {
                request = CreateHttpRequest(new Uri(Smartsheet.BaseURI, "webhooks/" + webhookId + "/resetsharedsecret"), HttpMethod.POST);
            }
            catch (Exception e)
            {
                throw new SmartsheetException(e);
            }

            HttpResponse response = this.Smartsheet.HttpClient.Request(request);

            WebhookSharedSecret secret = null;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    secret = this.Smartsheet.JsonSerializer.deserializeResult<WebhookSharedSecret>(
                        response.Entity.GetContent()).Result;
                    break;
                default:
                    HandleError(response);
                    break;
            }

            Smartsheet.HttpClient.ReleaseConnection();
            return secret;
        }
    }
}
