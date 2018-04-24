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
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the widget object. </summary>
    /// <seealso href="http://smartsheet-platform.github.io/api-docs/#widget-object">Widget Object Help</seealso>
    public class Widget : IdentifiableModel
    {
        /// <summary>
        /// Type of widget
        /// </summary>
        private WidgetType type;

        /// <summary>
        /// (Optional) Title of the widget
        /// </summary>
        private string title;

        /// <summary>
        /// True indicates that the client should display the widget title. Note that this is independent of the “title” string which may be null or empty.
        /// </summary>
        private bool? showTitle;

        /// <summary>
        /// True indicates that the client should display the Sheet icon in the widget title
        /// </summary>
        private bool? showTitleIcon;

        /// <summary>
        /// FormatDescriptor
        /// </summary>
        private string titleFormat;

        /// <summary>
        /// X-coordinate of widget’s position on the Sight
        /// </summary>
        private int? xPosition;

        /// <summary>
        /// Y-coordinate of widget’s position on the Sight
        /// </summary>
        private int? yPosition;

        /// <summary>
        /// Number of Rows that the widget occupies on the Sight
        /// </summary>
        private int? height;

        /// <summary>
        /// Number of Columns that the widget occupies on the Sight
        /// </summary>
        private int? width;

        /// <summary>
        /// Widget version number
        /// </summary>
        private int? version;

        /// <summary>
        /// Data that specifies the contents of the widget. _Note: the type of WidgetContent object (and attributes within) will depend on the value of Widget.type:
        /// CELLLINK - CellLinkWidgetContent
        /// SHEETSUMMARY - CellLinkWidgetContent
        /// RICHTEXT - RichTextWidgetContent
        /// SHORTCUTICON - ShortcutWidgetContent
        /// SHORTCUTLIST - ShortcutWidgetContent
        /// GRIDGANTT - ReportWidgetContent
        /// IMAGE - ImageWidgetContent
        /// </summary>
        WidgetContent contents;

        /// <summary>
        /// Get the Type of widget.
        /// </summary>
        /// <returns> the WidgetType </returns>
        public virtual WidgetType Type
        {
            get { return type; }
            set { this.type = value; }
        }

        /// <summary>
        /// (Optional) Title of the widget.
        /// </summary>
        /// <returns> the Title </returns>
        public virtual string Title
        {
            get { return title; }
            set { this.title = value; }
        }

        /// <summary>
        /// True indicates that the client should display the widget title. Note that this is independent of the “title” string which may be null or empty.
        /// </summary>
        /// <returns> the showTitle flag </returns>
        public virtual bool? ShowTitle
        {
            get { return showTitle; }
            set { this.showTitle = value; }
        }

        /// <summary>
        /// True indicates that the client should display the Sheet icon in the widget title.
        /// </summary>
        /// <returns> the showTitleIcon flag </returns>
        public virtual bool? ShowTitleIcon
        {
            get { return showTitleIcon; }
            set { this.showTitleIcon = value; }
        }

        /// <summary>
        /// The title format FormatDescriptor string.
        /// </summary>
        /// <returns> the FormatDescriptor </returns>
        public virtual string TitleFormat
        {
            get { return titleFormat; }
            set { this.titleFormat = value; }
        }

        /// <summary>
        /// X-coordinate of widget’s position on the Sight.
        /// </summary>
        /// <returns> the xPosition </returns>
        public virtual int? XPosition
        {
            get { return xPosition; }
            set { this.xPosition = value; }
        }

        /// <summary>
        /// Y-coordinate of widget’s position on the Sight.
        /// </summary>
        /// <returns> the yPosition </returns>
        public virtual int? YPosition
        {
            get { return yPosition; }
            set { this.yPosition = value; }
        }

        /// <summary>
        /// Number of Rows that the widget occupies on the Sight.
        /// </summary>
        /// <returns> the Height </returns>
        public virtual int? Height
        {
            get { return height; }
            set { this.height = value; }
        }

        /// <summary>
        /// Number of Columns that the widget occupies on the Sight.
        /// </summary>
        /// <returns> the Width </returns>
        public virtual int? Width
        {
            get { return width; }
            set { this.width = value; }
        }

        /// <summary>
        /// Widget version number.
        /// </summary>
        /// <returns> the Version </returns>
        public virtual int? Version
        {
            get { return version; }
            set { this.version = value; }
        }

        /// <summary>
        /// Get the data that specifies the contents of the widget. 
        /// See description of contents variable for valid objects.
        /// </summary>
        /// <returns> the contents </returns>
        public virtual WidgetContent Contents
        {
            get { return contents; }
            set { this.contents = value; }
        }
    }
}
