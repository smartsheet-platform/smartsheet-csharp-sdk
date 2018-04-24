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

namespace Smartsheet.Api
{
    using Api.Models;

    public interface WebhookResources
    {
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
        PaginatedResult<Webhook> ListWebhooks(PaginationParameters paging);

        /// <summary>
        /// <para>Gets the Webhook specified in the URL.</para>
        /// 
        /// <para>It mirrors to the following Smartsheet REST API method: GET /webhooks/{webhookId}</para>
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
        Webhook GetWebhook(long webhookId);

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
        Webhook CreateWebhook(Webhook webhook);
    
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
        Webhook UpdateWebhook(Webhook webhook);

        /// <summary>
        /// <para>Delete a webhook.</para>
        /// 
        /// <para>It mirrors to the following Smartsheet REST API method: DELETE /webhooks/{webhookId}</para>
        /// </summary>
        /// <param name="webhookId"> the webhook Id </param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        void DeleteWebhook(long webhookId);

        /// <summary>
        /// <para>Resets the shared secret for the specified Webhook. For more information about how a shared secret is used, see Authenticating Callbacks.</para>
        /// <para>The request body should be empty</para>
        /// <para>It mirrors to the following Smartsheet REST API method: POST /webhooks/{webhookId}/resetsharedsecret</para>
        /// </summary>
        /// <param name="webhookId"> the webhook Id </param>
        /// <returns> the Webhook shared secret </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        WebhookSharedSecret ResetSharedSecret(long webhookId);
    }
}
