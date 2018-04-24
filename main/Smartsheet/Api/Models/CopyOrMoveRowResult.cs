using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Result of rows moved or copies.
    /// </summary>
    public class CopyOrMoveRowResult
    {
        private long? destinationSheetId;

        private IList<RowMapping> rowMappings;

        /// <summary>
        /// List of RowMapping objects
        /// </summary>
        public IList<RowMapping> RowMappings
        {
            get { return rowMappings; }
            set { rowMappings = value; }
        }

        /// <summary>
        /// ID of the destination sheet
        /// </summary>
        public long? DestinationSheetId
        {
            get { return destinationSheetId; }
            set { destinationSheetId = value; }
        }
    }
}
