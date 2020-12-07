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

using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the ImageWidgetContent object.</summary>
    /// <seealso href="http://smartsheet-platform.github.io/api-docs/#imagewidgetcontent-object">ImageWidgetContent Object Help</seealso>    
    public class ImageWidgetContent : IWidgetContent
    {
        /// <summary>
        /// The image private Id
        /// </summary>
        private string privateId;

        /// <summary>
        /// Name of the image file
        /// </summary>
        private string fileName;

        /// <summary>
        /// Format Descriptor <seealso href="https://smartsheet-platform.github.io/api-docs/?ruby#formatting">FormatDescriptor</seealso>
        /// </summary>
        private string format;

        /// <summary>
        /// Original height of the image in pixels
        /// </summary>
        private int? height;

        /// <summary>
        /// The widget has when clicked attribute set to that hyperlink (if present and non-null)
        /// </summary>
        private WidgetHyperlink hyperlink;

        /// <summary>
        /// Original width of the image in pixels
        /// </summary>
        private int? width;

        /// <summary>
        /// Returns the type for this widget content object
        /// </summary>
        public WidgetType WidgetType
        {
            get { return WidgetType.IMAGE; }
        }
        /// <summary>
        /// The image private ID.
        /// </summary>
        /// <returns> the ID </returns>
        public string PrivateId
        {
            get { return privateId; }
            set { privateId = value; }
        }

        /// <summary>
        /// Name of the image file.
        /// </summary>
        /// <returns> the name </returns>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        /// <summary>
        /// The formatDescriptor for the image file.
        /// </summary>
        /// <returns> the formatDescriptor </returns>
        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        /// <summary>
        /// Original height of the image in pixels.
        /// </summary>
        /// <returns> the height </returns>
        public int? Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// The widget has when clicked attribute set to that hyperlink (if present and non-null)
        /// </summary>
        /// <returns> the Link </returns>
        public WidgetHyperlink Hyperlink
        {
            get { return hyperlink; }
            set { hyperlink = value; }
        }

        /// <summary>
        /// Original width of the image in pixels.
        /// </summary>
        /// <returns> the width </returns>
        public int? Width
        {
            get { return width; }
            set { width = value; }
        }
    }
}
