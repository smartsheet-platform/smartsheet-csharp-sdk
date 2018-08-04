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

namespace Smartsheet.Api.Internal
{
    using Smartsheet.Api.Models;
    using Smartsheet.Api.Internal.Util;
    using System;

    public class SheetAutomationRuleResourcesImpl : AbstractResources, SheetAutomationRuleResources
    {
        public SheetAutomationRuleResourcesImpl(SmartsheetImpl smartsheet) : base(smartsheet)
        {
        }

        /// <summary>
        /// <para>Gets all automation rules for this sheet.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: POST /sheets/{sheetId}/automationrules</para>
        /// </summary>
        /// <param name="sheetId"> the Id of the sheet </param>
        /// <param name="paging"> the pagination parameters </param>
        /// <returns> a list of automation rules </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual PaginatedResult<AutomationRule> ListAutomationRules(long sheetId, PaginationParameters paging = null)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            if (paging != null)
            {
                parameters = paging.toDictionary();
            }

            return this.ListResourcesWithWrapper<AutomationRule>("sheets/" + sheetId + "/automationrules" + 
                QueryUtil.GenerateUrl(null, parameters));
        }

        /// <summary>
        /// <para>Gets an automation rule for this sheet.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: GET /sheets/{sheetId}/automationrules/{automationRuleId}</para>
        /// </summary>
        /// <param name="sheetId"> the Id of the sheet </param>
        /// <param name="automationRuleId"> the automation rule Id </param>
        /// <returns> the automation rule </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual AutomationRule GetAutomationRule(long sheetId, long automationRuleId)
        {
            return this.GetResource<AutomationRule>("sheets/" + sheetId + "/automationrules/" + automationRuleId, typeof(AutomationRule));
        }

        /// <summary>
        /// <para>Updates an automation rule for this sheet.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: PUT /sheets/{sheetId}/automationrules/{automationRuleId}</para>
        /// </summary>
        /// <param name="sheetId"> the Id of the sheet </param>
        /// <param name="automationRule"> the automation rule </param>
        /// <returns> the automation rule </returns>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual AutomationRule UpdateAutomationRule(long sheetId, AutomationRule automationRule)
        {
            return this.UpdateResource("sheets/" + sheetId + "/automationrules/" + automationRule.Id, 
                typeof(AutomationRule), automationRule);
        }

        /// <summary>
        /// <para>Deletes an automation rule for this sheet.</para>
        /// <para>Mirrors to the following Smartsheet REST API method: DELETE /sheets/{sheetId}/automationrules/{automationRuleId}</para>
        /// </summary>
        /// <param name="sheetId"> the Id of the sheet </param>
        /// <param name="automationRuleId"> the automation rule Id </param>
        /// <exception cref="System.InvalidOperationException"> if any argument is null or an empty string </exception>
        /// <exception cref="InvalidRequestException"> if there is any problem with the REST API request </exception>
        /// <exception cref="AuthorizationException"> if there is any problem with the REST API authorization (access token) </exception>
        /// <exception cref="ResourceNotFoundException"> if the resource cannot be found </exception>
        /// <exception cref="ServiceUnavailableException"> if the REST API service is not available (possibly due to rate limiting) </exception>
        /// <exception cref="SmartsheetException"> if there is any other error during the operation </exception>
        public virtual void DeleteAutomationRule(long sheetId, long automationRuleId)
        {
            this.DeleteResource<AutomationRule>("sheets/" + sheetId + "/automationrules/" + automationRuleId, typeof(AutomationRule));
        }
    }
}
