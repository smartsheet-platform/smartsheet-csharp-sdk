//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2019 SmartsheetClient
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

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the ShortcutWidgetContent object.</summary>
    /// <seealso href="https://smartsheet-platform.github.io/api-docs/#shortcutwidgetcontent-object">ShortcutWidgetContent Object Help</seealso>    
    public class ShortcutWidgetContent : IWidgetContent
    {
        /// <summary>
        /// Array of ShortcutDataItem objects
        /// </summary>
        private IList<ShortcutDataItem> shortcutData;

        /// <summary>
        /// Returns the type for this widget content object
        /// </summary>
        public WidgetType WidgetType
        {
            get { return WidgetType.SHORTCUT; }
        }

        /// <summary>
        /// An array of ShortcutDataItem objects.
        /// </summary>
        /// <returns> the array </returns>
        public IList<ShortcutDataItem> ShortcutData
        {
            get { return shortcutData; }
            set { shortcutData = value; }
        }
    }
}
