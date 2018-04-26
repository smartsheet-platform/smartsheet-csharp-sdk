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

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// A template object that is a default layout for future Sheets. </summary>
    /// <seealso href="http://help.Smartsheet.com/customer/portal/articles/522123-using-Templates">Using Templates Help</seealso>
    public class Template : NamedModel
    {
        /// <summary>
        /// Represents the Description for the template.
        /// </summary>
        private string description;

        /// <summary>
        /// Represents the access level for the template.
        /// </summary>
        private AccessLevel? accessLevel;

        /// <summary>
        /// URL to the small preview image for this template.
        /// </summary>
        private string image;

        /// <summary>
        /// URL to the large preview image for this template
        /// </summary>
        private string largeImage;

        /// <summary>
        /// Locale of the template
        /// </summary>
        private string locale;

        /// <summary>
        /// Type of the template. One of “sheet” or “report”
        /// </summary>
        private string type;

        /// <summary>
        /// List of search tags for this template
        /// </summary>
        private IList<string> tags;

        /// <summary>
        /// List of categories this template belongs to
        /// </summary>
        private IList<string> categories;

        /// <summary>
        /// Flag indicating whether the template is blank
        /// </summary>
        private bool? blank;

        /// <summary>
        /// Type of global template. One of: “BLANK_SHEET”, “TASK_LIST”, or “PROJECT_SHEET”
        /// </summary>
        private GlobalTemplate? globalTemplate;

        /// <summary>
        /// Gets the Description of the template.
        /// </summary>
        /// <returns> the Description </returns>
        public string Description
        {
            get { return description; }
            set { this.description = value; }
        }

        /// <summary>
        /// Gets the access level of the template.
        /// </summary>
        /// <returns> the access level </returns>
        public AccessLevel? AccessLevel
        {
            get { return accessLevel; }
            set { this.accessLevel = value;}
        }

        /// <summary>
        /// Gets the URL to the small preview image for this template.
        /// </summary>
        /// <returns> the URL </returns>
        public string Image
        {
            get { return image; }
            set { this.image = value; }
        }

        /// <summary>
        /// Gets the URL to the large preview image for this template.
        /// </summary>
        /// <returns> the URL </returns>
        public string LargeImage
        {
            get { return largeImage; }
            set { this.largeImage = value; }
        }

        /// <summary>
        /// Gets the locale of the template.
        /// </summary>
        /// <returns> the locale </returns>
        public string Locale
        {
            get { return locale; }
            set { this.locale = value; }
        }

        /// <summary>
        /// Gets the type of the template. One of “sheet” or “report”.
        /// </summary>
        /// <returns> "sheet" or "report" </returns>
        public string Type
        {
            get { return type; }
            set { this.type = value; }
        }

        /// <summary>
        /// Gets the list of search tags for this template.
        /// </summary>
        /// <returns> list of tags </returns>
        public IList<string> Tags
        {
            get { return tags; }
            set { this.tags = value; }
        }

        /// <summary>
        /// Gets the list of categories this template belongs to.
        /// </summary>
        /// <returns> list of categories </returns>
        public IList<string> Categories
        {
            get { return categories; }
            set { this.categories = value; }
        }

        /// <summary>
        /// Gets the flag indicating whether the template is blank.
        /// </summary>
        /// <returns> blank flag </returns>
        public bool? Blank
        {
            get { return blank; }
            set { this.blank = value; }
        }

        /// <summary>
        /// Gets the type of global template.
        /// </summary>
        /// <returns> template type </returns>
        public GlobalTemplate? GlobalTemplate
        {
            get { return globalTemplate; }
            set { this.globalTemplate = value; }
        }
    }
}