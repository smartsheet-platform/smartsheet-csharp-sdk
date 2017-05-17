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
//    Unless required by applicable law or agreed To in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

namespace Smartsheet.Api
{
	using NLog;
	using System;
	using SmartsheetImpl = Api.Internal.SmartsheetImpl;
	using DefaultHttpClient = Api.Internal.Http.DefaultHttpClient;
	using HttpClient = Api.Internal.Http.HttpClient;
	using JsonNetSerializer = Api.Internal.Json.JsonNetSerializer;
	using JsonSerializer = Api.Internal.Json.JsonSerializer;

	/// <summary>
	/// Declare a prototype for user provided calcBackoff callbacks.
	/// </summary>
	/// <param name="previousAttempts"></param>
	/// <param name="totalElapsedTime"></param>
	/// <param name="error"></param>
	/// <returns></returns>
	public delegate long CalcBackoffCallback(int previousAttempts, long totalElapsedTime, Api.Models.Error error);

	/// <summary>
	/// An interface for userCalcBackoff class inheritence.
	/// </summary>
	public interface IUserCalcBackoff
	{
		CalcBackoffCallback CalcBackoffCallback { get; } 
	}

	/// <summary>
	/// Default calcBackoff, uses partial exponential backoff to calculate wait times.
	/// </summary>
	public class DefaultCalcBackoff : IUserCalcBackoff
	{
		private long maxRetryTime;

		/// <summary>
		/// static logger 
		/// </summary>
		private static Logger logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Maximum retry time may be specified by the caller
		/// </summary>
		/// <param name="maxRetryTime"></param>
		public DefaultCalcBackoff(long maxRetryTime)
		{
			this.maxRetryTime = maxRetryTime;
		}

		/// <summary>
		/// use partial exponential backoff to determine wait time.
		/// </summary>
		/// <param name="previousAttempts"></param>
		/// <param name="totalElapsedTime"></param>
		/// <param name="error"></param>
		/// <returns></returns>
		public long CalcBackoff(int previousAttempts, long totalElapsedTime, Api.Models.Error error)
		{
			if (totalElapsedTime > maxRetryTime)
			{
				logger.Info("Total elapsed timeout exceeded, exiting retry loop");
				return -1;
			}
			return (long)((Math.Pow(2, previousAttempts) * 1000) + new Random().Next(0, 1000));
		}

		public CalcBackoffCallback CalcBackoffCallback
		{
			get
			{
				return CalcBackoff;
			}
		}
	}

	/// <summary>
	/// <para>A convenience class To help create a <seealso cref="SmartsheetClient"/> instance with the appropriate fields.</para>
	/// 
	/// <para>Thread Safety: This class is not thread safe since it's mutable, one builder instance is NOT expected To be used in
	/// multiple threads.</para>
	/// </summary>
	public class SmartsheetBuilder
	{
		/// <summary>
		/// <para>Represents the HttpClient.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private HttpClient httpClient;

		/// <summary>
		/// <para>Represents the JsonSerializer.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private JsonSerializer jsonSerializer;

		/// <summary>
		/// <para>Represents the base URI.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string baseURI;

		/// <summary>
		/// <para>Represents the access token.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string accessToken;

		/// <summary>
		/// <para>Represents the assumed user.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string assumedUser;

		private IUserCalcBackoff calcBackoff = new DefaultCalcBackoff(15000);

		/// <summary>
		/// <para>Represents the default base URI of the SmartsheetClient REST API.</para>
		/// 
		/// <para>It is a constant with Value "https://Api.SmartsheetClient.com/2.0".</para>
		/// </summary>
		public const string DEFAULT_BASE_URI = "https://api.smartsheet.com/2.0/";

		/// <summary>
		/// Constructor.
		/// </summary>
		public SmartsheetBuilder()
		{
		}

		/// <summary>
		/// <para>Set the HttpClient.</para>
		/// </summary>
		/// <param name="httpClient"> the http client </param>
		/// <returns> the SmartsheetClient builder </returns>
		public virtual SmartsheetBuilder SetHttpClient(HttpClient httpClient)
		{
			this.httpClient = httpClient;
			return this;
		}

		/// <summary>
		/// <para>Set the JsonSerializer.</para>
		/// </summary>
		/// <param name="jsonSerializer"> the JsonSerializer </param>
		/// <returns> the SmartsheetBuilder </returns>
		public virtual SmartsheetBuilder SetJsonSerializer(JsonSerializer jsonSerializer)
		{
			this.jsonSerializer = jsonSerializer;
			return this;
		}

		/// <summary>
		/// <para>Set the base URI.</para>
		/// </summary>
		/// <param name="baseURI"> the base uri </param>
		/// <returns> the SmartsheetClient builder </returns>
		public virtual SmartsheetBuilder SetBaseURI(string baseURI)
		{
			this.baseURI = baseURI;
			return this;
		}

		/// <summary>
		/// <para>Set the access token.</para>
		/// </summary>
		/// <param name="accessToken"> the access token </param>
		/// <returns> the SmartsheetClient builder </returns>
		public virtual SmartsheetBuilder SetAccessToken(string accessToken)
		{
			this.accessToken = accessToken;
			return this;
		}

		/// <summary>
		/// <para>Set the assumed user.</para>
		/// </summary>
		/// <param name="assumedUser"> the assumed user </param>
		/// <returns> the SmartsheetClient builder </returns>
		public virtual SmartsheetBuilder SetAssumedUser(string assumedUser)
		{
			this.assumedUser = assumedUser;
			return this;
		}

		/// <summary>
		/// Create a DefaultCalcBackoff with a max elapsed timeout specified by the user. This interface 
		/// is only valid when the DefaultHttpClient is used.
		/// </summary>
		/// <param name="maxRetryTimeout"></param>
		/// <returns></returns>
		public virtual SmartsheetBuilder SetMaxRetryTimeout(long maxRetryTimeout)
		{
			this.calcBackoff = new DefaultCalcBackoff(maxRetryTimeout);
			return this;
		}

		/// <summary>
		/// Store a user provided IUserCalcBackoff. This interface is only valid when the DefaultHttpClient is used.
		/// </summary>
		/// <param name="calcBackoff"></param>
		/// <returns></returns>
		public virtual SmartsheetBuilder SetUserCalcBackoff(IUserCalcBackoff calcBackoff)
		{
			this.calcBackoff = calcBackoff;
			return this;
		}

		/// <summary>
		/// <para>Gets the http client.</para>
		/// </summary>
		/// <returns> the http client </returns>
		public virtual HttpClient HttpClient
		{
			get
			{
				return httpClient;
			}
		}

		/// <summary>
		/// <para>Gets the Json serializer.</para>
		/// </summary>
		/// <returns> the Json serializer </returns>
		public virtual JsonSerializer JsonSerializer
		{
			get
			{
				return jsonSerializer;
			}
		}

		/// <summary>
		/// <para>Gets the base uri.</para>
		/// </summary>
		/// <returns> the base uri </returns>
		public virtual string BaseURI
		{
			get
			{
				return baseURI;
			}
		}

		/// <summary>
		/// <para>Gets the access token.</para>
		/// </summary>
		/// <returns> the access token </returns>
		public virtual string AccessToken
		{
			get
			{
				return accessToken;
			}
		}

		/// <summary>
		/// <para>Gets the assumed user.</para>
		/// </summary>
		/// <returns> the assumed user </returns>
		public virtual string AssumedUser
		{
			get
			{
				return assumedUser;
			}
		}

		/// <summary>
		/// <para>Gets the default base uri.</para>
		/// </summary>
		/// <returns> the default base uri </returns>
		public static string DefaultBaseUri
		{
			get
			{
				return DEFAULT_BASE_URI;
			}
		}

		/// <summary>
		/// <para>Build the SmartsheetClient instance.</para>
		/// </summary>
		/// <returns> the SmartsheetClient instance </returns>
		public virtual SmartsheetClient Build()
		{
			if (baseURI == null)
			{
				baseURI = DEFAULT_BASE_URI;
			}

			SmartsheetImpl smartsheet = new SmartsheetImpl(baseURI, accessToken, httpClient, jsonSerializer);

			if (assumedUser != null)
			{
				smartsheet.AssumedUser = assumedUser;
			}

			smartsheet.CalcBackoff = calcBackoff;

			return smartsheet;
		}
	}

}