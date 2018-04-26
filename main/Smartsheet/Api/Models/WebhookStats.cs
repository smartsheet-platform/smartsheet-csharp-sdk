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

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the webhook stats object. </summary>
    /// <seealso href="http://smartsheet-platform.github.io/api-docs/#webhookstats-object">Webhook Stats Object Help</seealso>
    public class WebhookStats
    {
        /// <summary>
        /// The number of retries the webhook had performed as of the last callback attempt.
        /// </summary>
        private int? lastCallbackAttemptRetryCount;

        /// <summary>
        /// When this webhook last made a callback attempt.
        /// </summary>
        private DateTime? lastCallbackAttempt;

        /// <summary>
        /// When this webhook last made a successful callback.
        /// </summary>
        private DateTime? lastSuccessfulCallback;

        /// <summary>
        /// Get the number of retries the webhook had performed as of the last callback attempt.
        /// </summary>
        /// <returns> the retry count </returns>
        public int? LastCallbackAttemptRetryCount
        {
            get { return lastCallbackAttemptRetryCount; }
            set { lastCallbackAttemptRetryCount = value; }
        }

        /// <summary>
        /// Get the timestamp from last callback attempt.
        /// </summary>
        /// <returns> the attempt timestamp </returns>
        public DateTime? LastCallbackAttempt
        {
            get { return lastCallbackAttempt; }
            set { lastCallbackAttempt = value; }
        }

        /// <summary>
        /// Get the timestamp from the last successful callback.
        /// </summary>
        /// <returns> the successful timestamp</returns>
        public DateTime? LastSuccessfulCallback
        {
            get { return lastSuccessfulCallback; }
            set { lastSuccessfulCallback = value; }
        }
    }
}
