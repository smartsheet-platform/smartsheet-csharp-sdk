//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2018 SmartsheetClient
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
    public class AutomationRule : IdentifiableModel
    {
        /// <summary>
        /// AutomationAction object containing information for this rule
        /// </summary>
        private AutomationAction action;

        /// <summary>
        /// A timestamp of when the rule was originally active
        /// </summary>
        private DateTime? createdAt;

        /// <summary>
        /// A User object containing the name and email of the creator of this rule
        /// </summary>
        private User createdBy;

        /// <summary>
        /// Machine-readable reason a rule is disabled
        /// </summary>
        private AutomationRuleDisabledReason? disabledReason;

        /// <summary>
        /// Descriptive reason rule is disabled
        /// </summary>
        private string disabledReasonText;

        /// <summary>
        /// Indicates whether the rule is active
        /// </summary>
        private bool? enabled;

        /// <summary>
        /// A timestamp indicating when the last change was made to the rule
        /// </summary>
        private DateTime? modifiedAt;

        /// <summary>
        /// User object containing the name and email of the user who last modified this rule
        /// </summary>
        private User modifiedBy;

        /// <summary>
        /// Indicates that the current user can modify this rule
        /// </summary>
        private bool? userCanModify;

        /// <summary>
        /// Gets the automation action for this rule
        /// </summary>
        /// <returns> the automation action </returns>
        public AutomationAction Action
        {
            get { return action; }
            set { action = value; }
        }

        /// <summary>
        /// Gets a timestamp of when the rule was created
        /// </summary>
        /// <returns> the timestamp </returns>
        public DateTime? CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        /// <summary>
        /// Gets the User object for the author of this rule
        /// </summary>
        /// <returns> the User object </returns>
        public User CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        /// <summary>
        /// Gets a machine-readable reason a rule is disabled
        /// </summary>
        /// <returns> the reason </returns>
        public AutomationRuleDisabledReason? DisabledReason
        {
            get { return disabledReason; }
            set { disabledReason = value; }
        }

        /// <summary>
        /// Gets descriptive text for why this rule is disabled
        /// </summary>
        /// <returns> the reason </returns>
        public string DisabledReasonText
        {
            get { return disabledReasonText; }
            set { disabledReasonText = value; }
        }

        /// <summary>
        /// Gets flag indicating whether rule is active
        /// </summary>
        /// <returns> the flag </returns>
        public bool? Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        /// <summary>
        /// Gets a timestamp for the last modification to this rule
        /// </summary>
        /// <returns> the timestamp </returns>
        public DateTime? ModifiedAt
        {
            get { return modifiedAt; }
            set { modifiedAt = value; }
        }

        /// <summary>
        /// Gets the user who made the last modification to this rule
        /// </summary>
        /// <returns> the user </returns>
        public User ModifiedBy
        {
            get { return modifiedBy; }
            set { modifiedBy = value; }
        }

        /// <summary>
        /// Gets a flag indicating whether the current user can modify this rule
        /// </summary>
        /// <returns> the flag </returns>
        public bool? UserCanModify
        {
            get { return userCanModify; }
            set { userCanModify = value; }
        }
    }
}
