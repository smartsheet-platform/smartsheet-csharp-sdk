using System;
using System.IO;
using System.Threading;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using Smartsheet.Api.Internal.Http;
using Newtonsoft.Json;

namespace sdk_csharp_sample
{
    class RetryHttpClient : DefaultHttpClient
    {
        /// <summary>
        /// Override this method to perform API requests for special cases
        /// </summary>
        /// <param name="previousAttempts"> number of previous attempts </param>
        /// <param name="totalElapsedTime"> the total elapsed time for the API request </param>
        /// <param name="response"> the last response from the API </param>
        /// <returns> true to retry, false to exit and return error to the caller </returns>
        public override bool ShouldRetry(int previousAttempts, long totalElapsedTime, HttpResponse response)
        {
            string contentType = response.Entity.ContentType;
            if (contentType != null && !contentType.StartsWith("application/json"))
            {
                // it's not JSON; don't try to parse it
                return false;
            }

            Error error;
            try
            {
                // Details about the Smartsheet API error condition
                error = jsonSerializer.deserialize<Error>(
                    response.Entity.GetContent());
            }
            catch (JsonSerializationException ex)
            {
                throw new SmartsheetException(ex);
            }
            catch (Newtonsoft.Json.JsonException ex)
            {
                throw new SmartsheetException(ex);
            }
            catch (IOException ex)
            {
                throw new SmartsheetException(ex);
            }

            switch (error.ErrorCode)
            {
                // The default shouldRetry, retries 4001, 4002, 4003, 4004 codes
                case 4001:
                case 4002:
                case 4003:
                case 4004:
                case 9999: // adding my fictional error code to the retry list
                    break;
                default:
                    return false;
            }

            // The default calcBackoff uses exponential backoff, add custom behavior by overriding calcBackoff
            long backoff = CalcBackoff(previousAttempts, totalElapsedTime, error);
            if (backoff < 0)
                return false;

            logger.Info(string.Format("HttpError StatusCode={0}: Retrying in {1} milliseconds", response.StatusCode, backoff));
            Thread.Sleep(TimeSpan.FromMilliseconds(backoff));
            return true;
        }
    }
}
