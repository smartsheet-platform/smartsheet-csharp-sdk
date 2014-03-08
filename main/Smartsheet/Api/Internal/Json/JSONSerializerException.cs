using Smartsheet.Api;
using System;

namespace Smartsheet.Api.Internal.Json
{
    public class JSONSerializationException : SmartsheetException
    {
        public JSONSerializationException(string message)
            : base(message)
        {
        }

        public JSONSerializationException(string message, Exception cause)
            : base(message, cause)
        {
        }

        public JSONSerializationException(Exception e)
            : base(e)
        {
        }
    }
}