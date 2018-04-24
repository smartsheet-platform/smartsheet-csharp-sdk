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
    /// <seealso href="https://smartsheet-platform.github.io/api-docs/#imageurl-object">ImageUrl Object Help</seealso>
    public class ImageUrl
    {
        /// <summary>
        /// Image ID</summary>
        private string imageId;

        /// <summary>
        /// Image width (in pixels).
        /// In the Get Image URLs request, this (optional) attribute represents requested width; 
        /// in the response, it represents actual width of the image returned. (See Get Image URLs.)</summary>
        private long? width;

        /// <summary>
        /// Image height (in pixels).
        /// In the Get Image URLs request, this (optional) attribute represents requested height; 
        /// in the response, it represents actual height of the image returned. (See Get Image URLs.)</summary>
        private long? height;

        /// <summary>
        /// Temporary URL that can be used to retrieve the image. This attribute can be present in a response but will never be specified in a request.</summary>
        private string url;

        /// <summary>
        /// Error object. Present in the Get Image URLs response only if an error occurred retrieving the image.</summary>
        Error error;

        /// <summary>
        /// Get Image Id.
        /// </summary>
        /// <returns> the Id </returns>
        public virtual string ImageId
        {
            get { return imageId; }
            set { this.imageId = value; }
        }

        /// <summary>
        /// Get the Width (in pixels) of the uploaded image.
        /// </summary>
        public long? Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <summary>
        /// Get the Height (in pixels) of the uploaded image.
        /// </summary>
        public long? Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// Temporary URL that can be used to retrieve the image.
        /// </summary>
        /// <returns> the Url </returns>
        public virtual string Url
        {
            get { return url; }
            set { this.url = value; }
        }

        /// <summary>
        /// Get the Error object. Present in the Get Image URLs response only if an error occurred retrieving the image.
        /// </summary>
        /// <returns> the Error </returns>
        public virtual Error Error
        {
            get { return error; }
            set { this.error = value; }
        }

        /// <summary>
        /// A convenience class to help generate ImageUrl object with the appropriate fields.
        /// </summary>
        public class ImageUrlBuilder
        {
            private string imageId;

            private long? width;
            
            private long? height;

            /// <summary>
            /// Sets the required properties for creating an ImageUrl.
            /// </summary>
            /// <param name="imageId"> the ImageUrl imageId</param>
            public ImageUrlBuilder(string imageId)
            {
                this.imageId = imageId;
            }

            /// <summary>
            /// Sets the required properties for creating an ImageUrl.
            /// </summary>
            /// <param name="imageId"> the ImageUrl imageId</param>
            /// <param name="width">Desired image width</param>
            /// <param name="height">Desired image height</param>
            public ImageUrlBuilder(string imageId, long? width, long? height)
            {
                this.imageId = imageId;
                this.width = width;
                this.height = height;
            }

            /// <summary>
            /// Sets the ImageId for the ImageUrlBuilder.
            /// </summary>
            /// <param name="imageId"> the imageId </param>
            /// <returns> creates the ImageUrlBuilder </returns>
            public virtual ImageUrlBuilder SetImageId(string imageId)
            {
                this.imageId = imageId;
                return this;
            }

            /// <summary>
            /// Gets the image Id.
            /// </summary>
            /// <returns> the imageId </returns>
            public virtual string GetImageId()
            {
                return imageId;
            }

            /// <summary>
            /// Builds the ImageUrl.
            /// </summary>
            /// <returns> the ImageUrl</returns>
            public virtual ImageUrl Build()
            {
                if (imageId == null)
                {
                    throw new MemberAccessException("An imageId is required.");
                }

                ImageUrl imageUrl = new ImageUrl();
                imageUrl.ImageId = imageId;
                imageUrl.Width = width;
                imageUrl.Height = height;
                return imageUrl;
            }
        }
    }
}
