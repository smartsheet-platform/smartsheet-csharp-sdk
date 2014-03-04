namespace com.smartsheet.api
{

	/*
	 * #[license]
	 * Smartsheet SDK for C#
	 * %%
	 * Copyright (C) 2014 Smartsheet
	 * %%
	 * Licensed under the Apache License, Version 2.0 (the "License");
	 * you may not use this file except in compliance with the License.
	 * You may obtain a copy of the License at
	 * 
	 *      http://www.apache.org/licenses/LICENSE-2.0
	 * 
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 * %[license]
	 */



	using SmartsheetImpl = com.smartsheet.api.@internal.SmartsheetImpl;
	using DefaultHttpClient = com.smartsheet.api.@internal.http.DefaultHttpClient;
	using HttpClient = com.smartsheet.api.@internal.http.HttpClient;
	using JacksonJsonSerializer = com.smartsheet.api.@internal.json.JacksonJsonSerializer;
	using JsonSerializer = com.smartsheet.api.@internal.json.JsonSerializer;

	/// <summary>
	/// <para>A convenience class to help create a <seealso cref="Smartsheet"/> instance with the appropriate fields.</para>
	/// 
	/// <para>Thread Safety: This class is not thread safe since it's mutable, one builder instance is NOT expected to be used in
	/// multiple threads.</para>
	/// </summary>
	public class SmartsheetBuilder
	{
		/// <summary>
		/// <para>Represents the HttpClient.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private HttpClient httpClient_Renamed;

		/// <summary>
		/// <para>Represents the JsonSerializer.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private JsonSerializer jsonSerializer_Renamed;

		/// <summary>
		/// <para>Represents the base URI.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string baseURI_Renamed;

		/// <summary>
		/// <para>Represents the access token.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string accessToken_Renamed;

		/// <summary>
		/// <para>Represents the assumed user.</para>
		/// 
		/// <para>It can be set using corresponding setter.</para>
		/// </summary>
		private string assumedUser_Renamed;

		/// <summary>
		/// <para>Represents the default base URI of the Smartsheet REST API.</para>
		/// 
		/// <para>It is a constant with value "https://api.smartsheet.com/1.1".</para>
		/// </summary>
		public const string DEFAULT_BASE_URI = "https://api.smartsheet.com/1.1/";

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
		/// <returns> the smartsheet builder </returns>
		public virtual SmartsheetBuilder SetHttpClient(HttpClient httpClient)
		{
			this.httpClient_Renamed = httpClient;
			return this;
		}

		/// <summary>
		/// <para>Set the JsonSerializer.</para>
		/// </summary>
		/// <param name="jsonSerializer"> the JsonSerializer </param>
		/// <returns> the SmartsheetBuilder </returns>
		public virtual SmartsheetBuilder SetJsonSerializer(JsonSerializer jsonSerializer)
		{
			this.jsonSerializer_Renamed = jsonSerializer;
			return this;
		}

		/// <summary>
		/// <para>Set the base URI.</para>
		/// </summary>
		/// <param name="baseURI"> the base uri </param>
		/// <returns> the smartsheet builder </returns>
		public virtual SmartsheetBuilder SetBaseURI(string baseURI)
		{
			this.baseURI_Renamed = baseURI;
			return this;
		}

		/// <summary>
		/// <para>Set the access token.</para>
		/// </summary>
		/// <param name="accessToken"> the access token </param>
		/// <returns> the smartsheet builder </returns>
		public virtual SmartsheetBuilder SetAccessToken(string accessToken)
		{
			this.accessToken_Renamed = accessToken;
			return this;
		}

		/// <summary>
		/// <para>Set the assumed user.</para>
		/// </summary>
		/// <param name="assumedUser"> the assumed user </param>
		/// <returns> the smartsheet builder </returns>
		public virtual SmartsheetBuilder SetAssumedUser(string assumedUser)
		{
			this.assumedUser_Renamed = assumedUser;
			return this;
		}

		/// <summary>
		/// <para>Gets the http client.</para>
		/// </summary>
		/// <returns> the http client </returns>
		public virtual HttpClient httpClient
		{
			get
			{
				return httpClient_Renamed;
			}
		}

		/// <summary>
		/// <para>Gets the json serializer.</para>
		/// </summary>
		/// <returns> the json serializer </returns>
		public virtual JsonSerializer jsonSerializer
		{
			get
			{
				return jsonSerializer_Renamed;
			}
		}

		/// <summary>
		/// <para>Gets the base uri.</para>
		/// </summary>
		/// <returns> the base uri </returns>
		public virtual string baseURI
		{
			get
			{
				return baseURI_Renamed;
			}
		}

		/// <summary>
		/// <para>Gets the access token.</para>
		/// </summary>
		/// <returns> the access token </returns>
		public virtual string accessToken
		{
			get
			{
				return accessToken_Renamed;
			}
		}

		/// <summary>
		/// <para>Gets the assumed user.</para>
		/// </summary>
		/// <returns> the assumed user </returns>
		public virtual string assumedUser
		{
			get
			{
				return assumedUser_Renamed;
			}
		}

		/// <summary>
		/// <para>Gets the default base uri.</para>
		/// </summary>
		/// <returns> the default base uri </returns>
		public static string defaultBaseUri
		{
			get
			{
				return DEFAULT_BASE_URI;
			}
		}

		/// <summary>
		/// <para>Build the Smartsheet instance.</para>
		/// </summary>
		/// <returns> the Smartsheet instance </returns>
		/// <exception cref="IllegalStateException"> if accessToken isn't set yet. </exception>
		public virtual Smartsheet Build()
		{
			if (httpClient_Renamed == null)
			{
				httpClient_Renamed = new DefaultHttpClient();
			}

			if (jsonSerializer_Renamed == null)
			{
				jsonSerializer_Renamed = new JacksonJsonSerializer();
			}

			if (baseURI_Renamed == null)
			{
				baseURI_Renamed = DEFAULT_BASE_URI;
			}

			SmartsheetImpl smartsheet = new SmartsheetImpl(baseURI_Renamed, accessToken_Renamed, httpClient_Renamed, jsonSerializer_Renamed);

			if (assumedUser_Renamed != null)
			{
				smartsheet.assumedUser = assumedUser_Renamed;
			}

			return smartsheet;
		}
	}

}