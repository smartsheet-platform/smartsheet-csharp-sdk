//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2020 SmartsheetClient
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
    /// Represents the Image object. </summary>
    /// <seealso href="https://smartsheet-platform.github.io/api-docs/#profileimage-object">ProfileImage Object Help</seealso>
    public class ProfileImage
    {
        /// <summary>
        /// Image ID</summary>
        private string imageId;

        /// <summary>
        /// Original height (in pixels) of the image. </summary>
        private long? height;

        /// <summary>
        /// Original width (in pixels) of the image. </summary>
        private long? width;

        /// <summary>
        /// Get Image Id.
        /// </summary>
        /// <returns> the Id </returns>
        public string ImageId
        {
            get { return imageId; }
            set { imageId = value; }
        }

        /// <summary>
        /// Get the Height (in pixels) of the image.
        /// </summary>
        public long? Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Get the Width (in pixels) of the image.
        /// </summary>
        public long? Width
        {
            get { return width; }
            set { width = value; }
        }
    }
}
