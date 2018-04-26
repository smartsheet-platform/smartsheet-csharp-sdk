using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the widget object. </summary>
    /// <seealso href="http://smartsheet-platform.github.io/api-docs/#shortcutdataitem-object">ShortDataItem Object Help</seealso>
    public class ShortcutDataItem
    {
        /// <summary>
        /// Label for the data point
        /// </summary>
        private string label;

        /// <summary>
        /// formatDescriptor
        /// </summary>
        private string labelFormat;

        /// <summary>
        /// Attachment type (one of FILE, GOOGLE_DRIVE, LINK, BOX_COM, DROPBOX, EVERNOTE, EGNYTE, ONEDRIVE, SMARTSHEET)
        /// </summary>
        private AttachmentType? attachmentType;

        /// <summary>
        /// Hyperlink  object
        /// </summary>
        private Hyperlink hyperlink;

        /// <summary>
        /// The display order for the ShortcutWidgetItem
        /// </summary>
        private int? order;

        /// <summary>
        /// Certain attachment types will also include a mimeType
        /// </summary>
        private string mimeType;

        /// <summary>
        /// Label for the data point. 
        /// </summary>
        /// <returns> the label </returns>
        public string Label
        {
            get { return label; }
            set { this.label = value; }
        }

        /// <summary>
        /// formatDescriptor.
        /// </summary>
        /// <returns> the labelFormat </returns>
        public string LabelFormat
        {
            get { return labelFormat; }
            set { this.labelFormat = value; }
        }

        /// <summary>
        /// Attachment type (one of FILE, GOOGLE_DRIVE, LINK, BOX_COM, DROPBOX, EVERNOTE, EGNYTE, ONEDRIVE, SMARTSHEET).
        /// </summary>
        /// <returns> the attachment type </returns>
        public AttachmentType? AttachmentType
        {
            get { return attachmentType; }
            set { this.attachmentType = value; }
        }

        /// <summary>
        /// Hyperlink object.
        /// </summary>
        /// <returns> the Link </returns>
        public Hyperlink Hyperlink
        {
            get { return hyperlink; }
            set { this.hyperlink = value; }
        }
        
        /// <summary>
        /// The display order for the CellDataItem.
        /// </summary>
        /// <returns> the display order </returns>
        public int? Order
        {
            get { return order; }
            set { this.order = value; }
        }

        /// <summary>
        /// Certain attachment types will also include a mimeType.
        /// </summary>
        /// <returns> the MIME type </returns>
        public string MimeType
        {
            get { return mimeType; }
            set { this.mimeType = value; }
        }
    }
}
