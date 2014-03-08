using Smartsheet.Api;
using System;

namespace Smartsheet.Api.Internal.Json
{
    public class JsonSerializationException : SmartsheetException
    {
        public JsonSerializationException(string message)
            : base(message)
        {
        }

        public JsonSerializationException(string message, Exception cause)
            : base(message, cause)
        {
        }

        public JsonSerializationException(Exception e)
            : base(e)
        {
        }
    }
}