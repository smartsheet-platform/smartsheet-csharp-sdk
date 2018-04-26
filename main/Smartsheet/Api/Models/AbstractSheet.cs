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
using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the Sheet object.
    /// </summary>
    public abstract class AbstractSheet<TRow, TColumn, TCell> : NamedModel
        where TRow : AbstractRow<TColumn, TCell>
        where TColumn : Column
        where TCell : Cell
    {
        /// <summary>
        /// Represents the ID of the sheet/template from which the sheet was created.
        /// </summary>
        private long? fromId;

        /// <summary>
        /// Represents the owner Id of the owner
        /// </summary>
        private long? ownerId;

        /// <summary>
        /// Represents the access level for the sheet.
        /// </summary>
        private AccessLevel? accessLevel;

        /// <summary>
        /// Represents the attachments for the sheet.
        /// </summary>
        private IList<Attachment> attachments;

        /// <summary>
        /// Represents the columns for the sheet.
        /// </summary>
        [CLSCompliant(false)]
        protected IList<TColumn> columns;

        /// <summary>
        /// Represents the creation timestamp for the sheet.
        /// </summary>
        private DateTime? createdAt;

        /// <summary>
        /// Get a list of cross-sheet references used by this sheet
        /// </summary>
        private IList<CrossSheetReference> crossSheetReferences;

        /// <summary>
        /// Represents the dependencies enabled flag. </summary>
        /// <seealso href="http://help.Smartsheet.com/customer/portal/articles/765727-using-the-dependencies-functionality">
        /// Dependencies Functionality</seealso>
        private bool? dependenciesEnabled;

        /// <summary>
        /// Represents the discussions for the sheet.
        /// </summary>
        private IList<Discussion> discussions;

        /// <summary>
        /// Represents the effective attachment options
        /// </summary>
        private IList<AttachmentType> effectiveAttachmentOptions;

        /// <summary>
        /// Identifies whether the sheet is marked as a favorite
        /// </summary>
        private bool? favorite;

        /// <summary>
        /// List of sheet filters
        /// </summary>
        private IList<SheetFilter> filters;

        /// <summary>
        /// Represents the Gantt enabled flag.
        /// </summary>
        private bool? ganttEnabled;

        /// <summary>
        /// Represents the modification timestamp for the sheet.
        /// </summary>
        private DateTime? modifiedAt;

        /// <summary>
        /// Represents the owner of the sheet
        /// </summary>
        private string owner;

        /// <summary>
        /// Represents the direct URL to the sheet.
        /// </summary>
        private string permalink;

        /// <summary>
        /// Sheet’s project settings containing the working days, non-working days, and length of day for a project sheet.
        /// </summary>
        private ProjectSettings projectSettings;

        /// <summary>
        /// Represents the read only flag for the sheet.
        /// </summary>
        private bool? readOnly;

        /// <summary>
        /// Indicates whether resource management is enabled for a sheet
        /// </summary>
        private bool? resourceManagementEnabled;

        /// <summary>
        /// Represents the rows for the sheet.
        /// </summary>
        [CLSCompliant(false)]
        protected IList<TRow> rows;

        /// <summary>
        /// Identifies whether it is enabled to show parent rows for filters.
        /// </summary>
        private bool? showParentRowsForFilters;

        /// <summary>
        /// Represents the source of the sheet
        /// </summary>
        private Source source;

        /// <summary>
        /// Represents the ID of the sheet/template from which the sheet was created.
        /// </summary>
        private long? totalRowCount;

        /// <summary>
        /// Represents the user settings
        /// </summary>
        private SheetUserSettings userSettings;

        /// <summary>
        /// Represents the version for the sheet
        /// </summary>
        private int? version;

        /// <summary>
        /// Gets the Id of the sheet/template from which the sheet was created.
        /// </summary>
        /// <returns> the from Id </returns>
        public long? FromId
        {
            get { return fromId; }
            set { fromId = value; }
        }

        /// <summary>
        /// Represents the Id of the owner
        /// </summary>
        public long? OwnerId
        {
            get { return ownerId; }
            set { ownerId = value; }
        }

        /// <summary>
        /// Gets the access level for the sheet.
        /// </summary>
        /// <returns> the access level </returns>
        public AccessLevel? AccessLevel
        {
            get { return accessLevel; }
            set { accessLevel = value; }
        }

        /// <summary>
        /// Gets the attachments for the sheet.
        /// </summary>
        /// <returns> the attachments </returns>
        public IList<Attachment> Attachments
        {
            get { return attachments; }
            set { attachments = value; }
        }

        /// <summary>
        /// Gets the columns for the sheet.
        /// </summary>
        /// <returns> the columns </returns>
        public IList<TColumn> Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        /// <summary>
        /// Gets the date and time the sheet was created.
        /// </summary>
        /// <returns> the created at </returns>
        public DateTime? CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }

        /// <summary>
        /// Gets the list of cross-sheet references used by this sheet
        /// </summary>
        public IList<CrossSheetReference> CrossSheetReferences
        {
            get { return crossSheetReferences; }
            set { crossSheetReferences = value; }
        }

        /// <summary>
        /// Gets the dependencies enabled flag.
        /// </summary>
        /// <returns> the dependencies enabled </returns>
        public bool? DependenciesEnabled
        {
            get { return dependenciesEnabled; }
            set { dependenciesEnabled = value; }
        }

        /// <summary>
        /// Gets the discussions for the sheet.
        /// </summary>
        /// <returns> the discussions </returns>
        public IList<Discussion> Discussions
        {
            get { return discussions; }
            set { discussions = value; }
        }

        /// <summary>
        /// Array of enum strings (see Attachment.attachmentType) indicating the allowable attachment options for the current user and sheet
        /// </summary>
        /// <returns> list of attachment types </returns>
        public IList<AttachmentType> EffectiveAttachmentOptions
        {
            get { return effectiveAttachmentOptions; }
            set { effectiveAttachmentOptions = value; }
        }

        /// <summary>
        /// Returned only if the user has marked this sheet as a favorite in their Home tab (value = “true”).
        /// </summary>
        /// <returns> true if marked as favorite, false otherwise </returns>
        public bool? Favorite
        {
            get { return favorite; }
            set { favorite = value; }
        }

        /// <summary>
        /// Gets the list of sheet filters for this sheet.
        /// </summary>
        /// <returns> the list of sheet filters </returns>
        public IList<SheetFilter> Filters
        {
            get { return filters; }
            set { filters = value; }
        }

        /// <summary>
        /// Gets the Gantt enabled flag.
        /// </summary>
        /// <returns> the Gantt enabled flag </returns>
        public bool? GanttEnabled
        {
            get { return ganttEnabled; }
            set { ganttEnabled = value; }
        }

        /// <summary>
        /// Gets the date and time the sheet was last modified.
        /// </summary>
        /// <returns> the modified at </returns>
        public DateTime? ModifiedAt
        {
            get { return modifiedAt; }
            set { modifiedAt = value; }
        }

        /// <summary>
        /// Represents the email of the owner
        /// </summary>
        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        /// <summary>
        /// Gets the Permalink for the sheet.
        /// </summary>
        /// <returns> the Permalink </returns>
        public string Permalink
        {
            get { return permalink; }
            set { permalink = value; }
        }

        /// <summary>
        /// Gets sheet’s project settings containing the working days, non-working days, and length of day for a project sheet
        /// </summary>
        public ProjectSettings ProjectSettings
        {
            get { return projectSettings; }
            set { projectSettings = value; }
        }

        /// <summary>
        /// Gets the read only flag for the sheet.
        /// </summary>
        /// <returns> the read only </returns>
        public bool? ReadOnly
        {
            get { return readOnly; }
            set { readOnly = value; }
        }

        /// <summary>
        /// Indicates whether resource management is enabled.
        /// </summary>
        /// <returns> true if enabled, false otherwise </returns>
        public bool? ResourceManagementEnabled
        {
            get { return resourceManagementEnabled; }
            set { resourceManagementEnabled = value; }
        }

        /// <summary>
        /// Gets the rows for the sheet.
        /// </summary>
        /// <returns> the rows </returns>
        public IList<TRow> Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        /// <summary>
        /// Returned only if there are column filters on the sheet. Value = “true” if “show parent rows” is enabled for the filters.
        /// </summary>
        /// <returns> “true” if “show parent rows” is enabled for the filters </returns>
        public bool? ShowParentRowsForFilters
        {
            get { return showParentRowsForFilters; }
            set { showParentRowsForFilters = value; }
        }

        /// <summary>
        /// A Source object indicating the sheet or template from which this sheet was created.
        /// </summary>
        /// <returns> source of sheet </returns>
        public Source Source
        {
            get { return source; }
            set { source = value; }
        }

        /// <summary>
        /// The total number of rows in the sheet.
        /// </summary>
        /// <returns> The total number of rows in the sheet </returns>
        public long? TotalRowCount
        {
            get { return totalRowCount; }
            set { totalRowCount = value; }
        }

        /// <summary>
        /// A SheetUserSettings object containing the current user’s sheet-specific settings..
        /// </summary>
        /// <returns> SheetUserSettings object </returns>
        public SheetUserSettings UserSettings
        {
            get { return userSettings; }
            set { userSettings = value; }
        }

        /// <summary>
        /// Gets the version for the sheet.
        /// </summary>
        /// <returns> the version </returns>
        public int? Version
        {
            get { return version; }
            set { version = value; }
        }

        /// <summary>
        /// Gets a column by index.
        /// </summary>
        /// <param name="index"> the column index </param>
        /// <returns> the column by index </returns>
        public TColumn GetColumnByIndex(int index)
        {
            if (columns == null)
            {
                return null;
            }

            TColumn result = null;
            foreach (TColumn column in columns)
            {
                if (column.Index == index)
                {
                    result = column;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// Get a <seealso cref="Row"/> by row number.
        /// </summary>
        /// <param name="rowNumber"> the row number </param>
        /// <returns> the row by row number </returns>
        public TRow GetRowByRowNumber(int rowNumber)
        {
            if (rows == null)
            {
                return null;
            }

            TRow result = null;
            foreach (TRow row in rows)
            {
                if (row.RowNumber == rowNumber)
                {
                    result = row;
                    break;
                }
            }
            return result;
        }
    }
}
