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

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the TitleWidgetContent object.</summary>
    /// <seealso href="https://smartsheet-platform.github.io/api-docs/#titlewidgetcontent-object">TitleWidgetContent Object Help</seealso>    
    public class TitleRichTextWidgetContent : IWidgetContent
    {
        /// <summary>
        /// Represents the TitleWidgetContent object
        /// </summary>
        private string backgroundColor;

        /// <summary>
        /// HTML snippet to render report
        /// </summary>
        private string htmlContent;

        /// <summary>
        /// Returns the type for this widget content object
        /// </summary>
        public WidgetType WidgetType
        {
            get { return WidgetType.TITLE; }
        }

        /// <summary>
        /// Gets the background color of a title widget
        /// </summary>
        /// <returns> the background color </returns>
        public string BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; }
        }

        /// <summary>
        /// HTML snippet to render Report.
        /// </summary>
        /// <returns> the HTML string </returns>
        public string HtmlContent
        {
            get { return htmlContent; }
            set { htmlContent = value; }
        }
    }
}
