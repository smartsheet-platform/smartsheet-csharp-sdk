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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
	/// <summary>
	/// Represents the user Status. </summary>
	/// <seealso href="http://smartsheet-platform.github.io/api-docs/#webhook-status">WebhookStatus Documentation</seealso>/>
	public enum WebhookStatus
	{
		/// <summary>
		/// Webhook is active.
		/// </summary>
		ENABLED,

		/// <summary>
		/// Webhook has been created but is not enabled because it has not yet been verified.
		/// </summary>
		NEW_NOT_VERIFIED,

		/// <summary>
		/// Webhook has been disabled by the owner.
		/// </summary>
		DISABLED_BY_OWNER,

		/// <summary>
		/// Webhook verification has failed.
		/// </summary>
		DISABLED_VERIFICATION_FAILED,

		/// <summary>
		/// Webhook has been disabled because callback was not successfully delivered to the Callback URL.
		/// </summary>
		DISABLED_CALLBACK_FAILED,

		/// <summary>
		/// Webhook has been disabled because the third-party app associated with the webhook has had its access revoked.
		/// </summary>
		DISABLED_APP_REVOKED,

		/// <summary>
		/// Webhook has been disabled because its owner lost access to the corresponding data in Smartsheet 
		/// (either because the object was deleted or sharing permissions were revoked).
		/// </summary>
		DISABLED_SCOPE_INACCESSIBLE,

		/// <summary>
		/// Webhook has been disabled by Smartsheet support.
		/// </summary>
		DISABLED_ADMINISTRATIVE
	}
}