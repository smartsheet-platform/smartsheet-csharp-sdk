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
//

using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the ImageUrl object. </summary>
    /// <seealso href="https://smartsheet-platform.github.io/api-docs/#imageurlmap-object">ImageUrlMap Object Help</seealso>
    public class ImageUrlMap
    {
        /// <summary>
        /// Milliseconds before the URLs within imageUrls will expire.</summary>
        private long? urlExpiresInMillis;

        /// <summary>
        /// Array of ImageUrl objects
        /// </summary>
        private IList<ImageUrl> imageUrls;
        
        /// <summary>
        /// Get Milliseconds before the URLs within imageUrls will expire.
        /// </summary>
        public long? UrlExpiresInMillis
        {
            get { return urlExpiresInMillis; }
            set { urlExpiresInMillis = value; }
        }

        /// <summary>
        /// Gets the array of ImageUrl objects.
        /// </summary>
        /// <returns> the ImageUrls </returns>
        public IList<ImageUrl> ImageUrls
        {
            get { return imageUrls; }
            set { imageUrls = value; }
        }
    }
}
