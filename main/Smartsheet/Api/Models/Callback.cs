using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smartsheet.Api.Models
{
    public class Callback
    {
        /// <summary>
        /// Id of the object that corresponds to scope.
        /// </summary>
        private long scopeObjectId;

        /// <summary>
        /// Id of the corresponding webhook.
        /// </summary>
        private long webhookId;

        /// <summary>
        /// Array of CallbackEvent objects
        /// </summary>
        private List<CallbackEvent> events;

        /// <summary>
        /// New status of the corresponding webhook. Only returned for webhook status change callbacks (null for event callbacks).
        /// </summary>        
        private string? newWebhookStatus;

        /// <summary>
        /// Random value that is distinct for each callback
        /// </summary>
        private string nonce;

        /// <summary>
        ///Scope of the webhook. Currently, the only supported value is sheet.
        /// </summary>
        private string scope;

        /// <summary>
        /// Time that the callback was generated.
        /// </summary>
        private DateTimeOffset timestamp;

        /// <summary>
        /// Webhook version. Currently, the only supported value is 1. This attribute is intended to ensure backward compatibility as new 
        /// webhook functionality is released. For example, a webhook with a version of 1 is guaranteed to always be sent callback objects 
        /// that are compatible with the version 1 release of webhooks.
        /// </summary>
        private int? version;

        /// <summary>
        /// Get the Id of the object that corresponds to scope.
        /// </summary>
        /// <returns> the scope object id </returns>
        public long ScopeObjectId {
            get { return scopeObjectId; }
            set { scopeObjectId = value; }
        }

        /// <summary>
        /// Get the Id of the corresponding webhook.
        /// </summary>
        /// <returns> the webhook id </returns>
        public long WebhookId {
            get { return webhookId; }
            set { webhookId = value; }
        }

        /// <summary>
        /// Get the Array of CallbackEvent objects
        /// </summary>
        /// <returns> a list of the callback events</returns>
        public List<CallbackEvent> Events {
            get { return events; }
            set { events = value; }
        }

        /// <summary>
        /// Get the New status of the corresponding webhook. Only returned for webhook status change callbacks (null for event callbacks).
        /// </summary>
        /// <returns> the new status of the webhook </returns>
        public string? NewWebhookStatus{
            get { return newWebhookStatus; }
            set { newWebhookStatus = value; }
        }

        /// <summary>
        /// Get the Random value that is distinct for each callback
        /// </summary>
        /// <returns> the nonce or random value that is distinct for each callback </returns>
        public string Nonce {
            get { return nonce; }
            set { nonce = value; }
        }

        /// <summary>
        /// Get the scope of the webhook. Currently, the only supported value is sheet.
        /// </summary>
        /// <returns> the scope of the webhook </returns>
        public string Scope{
            get { return scope; }
            set { scope = value; }
        }

        /// <summary>
        /// Get the time that the callback was generated.
        /// </summary>
        /// <returns> the timestamp that the callback was generated</returns>
        public DateTimeOffset timestamp{
            get { return timestamp ; }
            set { timestamp = value; }
        }
    }
}