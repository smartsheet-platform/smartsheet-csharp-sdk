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
    /// Represents the SelectionRange object. </summary>
    /// <seealso href="https://smartsheet-platform.github.io/api-docs/#selectionrange-object">SelectionRange Object Help</seealso>        
    public class SelectionRange
    {
        /// <summary>
        /// Defines beginning edge of range when specifying one or more columns.
        /// </summary>
        private long sourceColumnId1;

        /// <summary>
        /// Defines ending edge of range when specifying one or more columns.
        /// </summary>
        private long sourceColumnId2;

        /// <summary>
        /// Defines beginning edge of range when specifying one or more rows.
        /// </summary>
        private long sourceRowId1;

        /// <summary>
        /// Defines ending edge of range when specifying one or more rows.
        /// </summary>
        private long sourceRowId2;

        /// <summary>
        /// Defines beginning edge of range when specifying one or more columns.
        /// </summary>
        /// <returns>the source column id</returns>
        public long SourceColumnId1
        {
            get { return sourceColumnId1; }
            set { sourceColumnId1 = value; }
        }

        /// <summary>
        /// Defines ending edge of range when specifying one or more columns.
        /// </summary>
        /// <returns>the source column id</returns>
        public long SourceColumnId2
        {
            get { return sourceColumnId2; }
            set { sourceColumnId2 = value; }
        }

        /// <summary>
        /// Defines beginning edge of range when specifying one or more rows.
        /// </summary>
        /// <returns>the source row id</returns>
        public long SourceRowId1
        {
            get { return sourceRowId1; }
            set { sourceRowId1 = value; }
        }

        /// <summary>
        /// Defines ending edge of range when specifying one or more rows.
        /// </summary>
        /// <returns>the source row id</returns>
        public long SourceRowId2
        {
            get { return sourceRowId2; }
            set { sourceRowId2 = value; }
        }
    }
}
