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

using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using HttpMethod = Api.Internal.Http.HttpMethod;
	using HttpRequest = Api.Internal.Http.HttpRequest;
	using Utils = Api.Internal.Utility.Utility;
	using Smartsheet.Api.Models;
	using System.IO;
	using Smartsheet.Api.Internal.Http;
	using System.Net;
	using System;
	using System.Text;

	/// <summary>
	/// This is the implementation of the ContactResources.
	/// Thread Safety: This class is thread safe because it is immutable and its base class is thread safe.
	/// </summary>
	public class ContactResourcesImpl : AbstractResources, ContactResources
	{
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="smartsheet"> the Smartsheet </param>
        /// <exception cref="InvalidOperationException">if any argument is null</exception>
        public ContactResourcesImpl(SmartsheetImpl smartsheet)
			: base(smartsheet)
		{
		}

		/// <summary>
		/// <para>Gets the specified Contact.</para>
		/// <para>It mirrors to the following Smartsheet REST API method:
		/// POST GET /contacts/{contactId}</para>
		/// </summary>
		/// <param name="contactId">the contactId</param>
		/// <returns>the Contact object</returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual Contact GetContact(string contactId)
		{
			return GetResource<Contact>("contacts/" + contactId, typeof(Contact));
		}

		/// <summary>
		/// <para>Gets a list of the user’s Smartsheet Contacts.</para>
		/// <para>It mirrors to the following Smartsheet REST API method:
		/// POST GET /contacts</para>
		/// </summary>
		/// <param name="paging"> the pagination info </param>
		/// <returns> The list of Contact objects </returns>
		/// <exception cref="System.InvalidOperationException"> if any argument is null or empty string </exception>
		/// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
		/// <exception cref="AuthorizationException"> if there is any problem with  the REST API authorization (access token) </exception>
		/// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
		/// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
		/// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
		public virtual PaginatedResult<Contact> ListContacts(PaginationParameters paging)
		{
			StringBuilder path = new StringBuilder("contacts");
			if (paging != null)
			{
				path.Append(paging.ToQueryString());
			}
			return ListResourcesWithWrapper<Contact>(path.ToString());
		}
	}
}