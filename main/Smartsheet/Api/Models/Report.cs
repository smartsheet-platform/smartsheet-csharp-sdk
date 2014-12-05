using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the Report object.
    /// </summary>
    public class Report:AbstractSheet<ReportRow, ReportColumn>
    {
        public Report()
        {
            
        }

        public Report(Sheet[] sourceSheet)
        {
            _sourceSheet = sourceSheet;
        }
        private IList<Sheet> _sourceSheet;

        public IList<Sheet> SourceSheet
        {
            get { return _sourceSheet; }
            set { _sourceSheet = value; }
        }
    }

    /// <summary>
    /// A report column is a "virtual" column, in that it appears identical to source sheet column(s), but is in fact a different column belonging to the report.  
    /// Cells in the report refer to this column via their virtualColumnId attribute, and their actual column from their source sheet via their columnId attribute.
    /// </summary>
    public class ReportColumn : Column
    {
        /// <summary>
        /// The virtual ID of this report column
        /// </summary>
        public long VirtualId { get; set; }

        /// <summary>
        /// Only included for the special "Sheet Name" report column
        /// </summary>
        public bool SheetNameColumn { get; set; }

    }

    public class ReportRow : AbstractRow<ReportColumn, ReportCell>
    {
        /// <summary>
        /// The ID of the sheet that this row originates from.
        /// </summary>
        public long SheetId { get; set; }
    }

    public class ReportCell : Cell
    {
        /// <summary>
        /// The virtualId of this cell's column.  virtualColumnId refers to this cell's parent column in this report, 
        /// while columnId refers to the cell's parent column in its originating source sheet.
        /// </summary>
        public long VirtualColumnId { get; set; }
    }
}
