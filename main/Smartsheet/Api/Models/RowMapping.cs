using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Information between the source and destination sheet of rows that were copied or moved.
    /// </summary>
    public class RowMapping
    {
        private long from;

        private long to;

        /// <summary>
        /// Row ID in the source sheet
        /// </summary>
        public long From
        {
            get { return from; }
            set { from = value; }
        }

        /// <summary>
        /// Row ID in the source sheet
        /// </summary>
        public long To
        {
            get { return to; }
            set { to = value; }
        }
    }

}
