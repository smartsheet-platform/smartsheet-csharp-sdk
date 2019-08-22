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

using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the SummaryField object.</summary>
    /// <seealso href="http://smartsheet-platform.github.io/api-docs/?shell#summaryfield-object">SummaryField Object Help</seealso>    
    public class SummaryField : IdentifiableModel
    {
        // Override Id property so that JSON.NET knows to make an exception of not serializating the Id.
        // (i.e. serialize the Id in this case)
        public override long? Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        /// <summary>
        /// Array of ContactOption objects to specify a pre-defined list of values for the column.
        /// Column type must be CONTACT_LIST
        /// </summary>
        private IList<Contact> contactOptions;

        /// <summary>
        /// Time of creation
        /// </summary>
        private DateTime? createdAt;

        /// <summary>
        /// User object containing name and email of the summaryField's author
        /// </summary>
        private User createdBy;

        /// <summary>
        /// Visual representation of cell contents, as presented to the user in the UI. See Cell Reference.
        /// </summary>
        private string displayValue;

        /// <summary>
        /// The format descriptor (see Formatting)
        /// Only returned if the include query string parameter contains format and this column has a non-default
        /// format applied to it.
        /// </summary>
        private string format;

        /// <summary>
        /// The formula for a cell, if set. NOTE: calculation errors or problems with a formula do not cause the API call
        /// to return an error code.Instead, the response contains the same value as in the UI,
        /// such as field.value = "#CIRCULAR REFERENCE".
        /// </summary>
        private string formula;

        /// <summary>
        /// A hyperlink to a URL, sheet, or report
        /// </summary>
        private Hyperlink hyperlink;

        /// <summary>
        /// The image that the field contains.
        /// Only returned if the field contains an image.
        /// </summary>
        private Image image;

        /// <summary>
        /// Field index or position. This number is zero-based.
        /// </summary>
        private int? index;

        /// <summary>
        /// Indicates whether the field is locked. In a response, a value of true indicates that the field has been
        /// locked by the sheet owner or the admin.
        /// </summary>
        private bool? locked;

        /// <summary>
        /// Indicates whether the field is locked for the requesting user. This attribute may be present in a response,
        /// but cannot be specified in a request.
        /// </summary>
        private bool? lockedForUser;

        /// <summary>
        /// Time of last modification
        /// </summary>
        private DateTime? modifiedAt;

        /// <summary>
        /// User object containing name and email of the summaryField's author
        /// </summary>
        private User modifiedBy;

        /// <summary>
        /// Required for date and contact fields
        /// </summary>
        ObjectValue objectValue;

        /// <summary>
        /// When applicable for PICKLIST column type. Array of the options available for the field
        /// </summary>
        private IList<string> options;

        /// <summary>
        /// When applicable for PICKLIST column type. See Symbol Columns.
        /// </summary>
        private string symbol;

        /// <summary>
        /// Arbitrary name, must be unique within summary
        /// </summary>
        private string title;

        /// <summary>
        /// See Column types
        /// </summary>
        private ColumnType type;

        /// <summary>
        /// Indicates whether summary field values are restricted to the type
        /// </summary>
        private bool? validation;

        /// <summary>
        /// Get contact options, only valid when type is CONTACT_LIST
        /// </summary>
        /// <returns> the list of contact options </returns>
        public IList<Contact> ContactOptions
        {
            get { return contactOptions; }
            set { contactOptions = value; }
        }

        /// <summary>
        /// Get summary field time of creation.
        /// </summary>
        /// <returns> createdAt </returns>
        public DateTime? CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        /// <summary>
        /// Get User object of summary field creator
        /// </summary>
        /// <returns> User object </returns>
        public User CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        /// <summary>
        /// Gets the display value of the summary field
        /// </summary>
        /// <returns> the display value </returns>
        public string DisplayValue
        {
            get { return displayValue; }
            set { displayValue = value; }
        }

        /// <summary>
        /// Gets the format descriptor
        /// </summary>
        /// <returns> the format </returns>
        public string Format
        {
            get { return format; }
            set { format = value; }
        }


        /// <summary>
        /// Gets the formula for the summary field
        /// </summary>
        /// <returns> the formula </returns>
        public string Formula
        {
            get { return formula; }
            set { formula = value; }
        }

        /// <summary>
        /// Gets the hyperlink associated with the field, if any
        /// </summary>
        /// <returns> the hyperlink </returns>
        public Hyperlink Hyperlink
        {
            get { return hyperlink; }
            set { hyperlink = value; }
        }

        /// <summary>
        /// Gets the image associated with the field, if any
        /// </summary>
        /// <returns> the image </returns>
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        /// <summary>
        /// Gets the field index or position
        /// </summary>
        /// <returns> the index </returns>
        public int? Index
        {
            get { return index; }
            set { index = value; }
        }

        /// <summary>
        /// Gets flag indicating whether field is locked
        /// </summary>
        /// <returns> true if row is locked </returns>
        public bool? Locked
        {
            get { return locked; }
            set { locked = value; }
        }

        /// <summary>
        /// Gets flag indicating whether field is locked for the requesting user
        /// </summary>
        /// <returns> true if row is locked for user </returns>
        public bool? LockedForUser
        {
            get { return lockedForUser; }
            set { lockedForUser = value; }
        }

        /// <summary>
        /// Gets the last modification date and time
        /// </summary>
        /// <returns> modified at </returns>
        public DateTime? ModifiedAt
        {
            get { return modifiedAt; }
            set { modifiedAt = value; }
        }

        /// <summary>
        /// Get the User who last modified the field
        /// </summary>
        /// <returns> User object </returns>
        public User ModifiedBy
        {
            get { return modifiedBy; }
            set { modifiedBy = value; }
        }

        /// <summary>
        /// Gets the field's objectValue
        /// </summary>
        /// <returns> the ObjectValue </returns>
        public ObjectValue ObjectValue
        {
            get { return objectValue; }
            set { objectValue = value; }
        }

        /// <summary>
        /// Gets PICKLIST options
        /// </summary>
        /// <returns> options </returns>
        public IList<string> Options
        {
            get { return options; }
            set { options = value; }
        }

        /// <summary>
        /// Gets applicable symbol for PICKLIST type
        /// </summary>
        /// <returns> symbol </returns>
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        /// <summary>
        /// Gets the field's title
        /// </summary>
        /// <returns> title </returns>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// Gets the field's type - see Column Type
        /// </summary>
        /// <returns> type </returns>
        public ColumnType Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// Gets flag indicating whether summary field values are restricted to type 
        /// </summary>
        /// <returns> validation </returns>
        public bool? Validation
        {
            get { return validation; }
            set { validation = value; }
        }
    }
}
