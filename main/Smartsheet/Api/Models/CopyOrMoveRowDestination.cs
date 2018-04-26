using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Information on the destination of the rows that were copied or moved.
    /// </summary>
    public class CopyOrMoveRowDestination
    {
        private long sheetId;

        /// <summary>
        /// ID of the destination sheet
        /// </summary>
        public long SheetId
        {
            get { return sheetId; }
            set { sheetId = value; }
        }
    }
}
