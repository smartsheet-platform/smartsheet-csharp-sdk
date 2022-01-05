using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
    public class CallbackEvent
    {
        /// <summary>
        /// Id of the object that corresponds to objectType. Omitted if objectType is cell
        /// </summary>
        private long id;

        /// <summary>
        /// The Id of the column where the cell is located.  Only present if objectType is cell. 
        /// </summary>
        private long? columnId;

        /// <summary>
        /// The Id of the row where the cell is located.  Only present if objectType is cell. 
        /// </summary>
        private long? rowid;

        /// <summary>
        /// The user Id of the person who caused this event.
        /// </summary>
        private long userid;

        /// <summary>
        /// Type of object for which event occurred.
        /// </summary>
        private string objectType;

        /// <summary>
        /// A comma-delimited list of values that uniquely identify the agents responsible for making the changes that caused the callback to occur. Only present if the change agent included the Smartsheet-Change-Agent header in the API request that changed data in Smartsheet. For more information, see Preventing Infinite Loops.
        /// </summary>
        private string? changeAgent;

        /// <summary>
        /// Type of Event that occurred.
        /// </summary>
        private string eventType;

        /// <summary>
        /// Time that this event occurred. A callback may contain events with different timestamps, as multiple separate events may be aggregated into a single callback request.
        /// </summary>
        private DateTimeOffset timestamp;

        /// <summary>
        /// Webhook version. Currently, the only supported value is 1. This attribute is intended to ensure backward compatibility as new 
        /// webhook functionality is released. For example, a webhook with a version of 1 is guaranteed to always be sent callback objects 
        /// that are compatible with the version 1 release of webhooks.
        /// </summary>
        private int? version;

        /// <summary>
        /// Get the Id of the object that corresponds to objectType. Omitted if objectType is cell
        /// </summary>
        /// <returns> the Id </returns>
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Get the Id of the column where the cell is located.  Only present if objectType is cell. 
        /// </summary>
        /// <returns> the id of the column where the cell is located </returns>
        public long? ColumnId
        {
            get { return columnId; }
            set { columnId = value; }
        }

        /// <summary>
        /// Get the Id of the row where the cell is located.  Only present if objectType is cell. 
        /// </summary>
        /// <returns>the Id of the row where the cell is located</returns>
        public long? Rowid
        {
            get { return rowid; }
            set { rowid = value; }
        }

        /// <summary>
        /// Get the user Id of the person who caused this event.
        /// </summary>
        /// <returns>the user Id of the person who caused this event.</returns>
        public long Userid
        {
            get { return userid; }
            set { userid = value; }
        }

        /// <summary>
        /// Get the type of object for which event occurred.
        /// </summary>
        /// <returns>the type of object for which event occurred.</returns>
        public string ObjectType
        {
            get { return objectType; }
            set { objectType = value; }
        }

        /// <summary>
        /// Get tne comma-delimited list of values that uniquely identify the agents responsible for making the changes that caused the callback to occur. Only present if the change agent included the Smartsheet-Change-Agent header in the API request that changed data in Smartsheet. For more information, see Preventing Infinite Loops.
        /// </summary>
        /// <returns>Tne comma-delimited list of values that uniquely identify the agents responsible for making the changes that caused the callback to occur</returns>
        public string? ChangeAgent
        {
            get { return changeAgent; }
            set { changeAgent = value; }
        }

        /// <summary>
        /// Get the type of Event that occurred.
        /// </summary>
        /// <returns>the type of Event that occurred</returns>
        public string EventType
        {
            get { return eventType; }
            set { eventType = value; }
        }

        /// <summary>
        /// Get the time that this event occurred. A callback may contain events with different timestamps, as multiple separate events may be aggregated into a single callback request.
        /// </summary>
        /// <returns>the time that this event occurred</returns>
        public DateTimeOffset Timestamp
        {
            get { return timestamp; }
            set { timestamp = value; }
        }

    }

}