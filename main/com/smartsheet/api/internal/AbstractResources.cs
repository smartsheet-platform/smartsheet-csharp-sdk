using System;
using System.Collections.Generic;

namespace com.smartsheet.api.@internal
{

    using com.smartsheet.api.@internal.json;
    using com.smartsheet.api.models;
    using System.IO;
    using System.Net;
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



    //using JsonParseException = com.fasterxml.jackson.core.JsonParseException;
    //using JsonMappingException = com.fasterxml.jackson.databind.JsonMappingException;
    using HttpEntity = com.smartsheet.api.@internal.http.HttpEntity;
    using HttpMethod = com.smartsheet.api.@internal.http.HttpMethod;
    using HttpRequest = com.smartsheet.api.@internal.http.HttpRequest;
    using HttpResponse = com.smartsheet.api.@internal.http.HttpResponse;
    using Util = com.smartsheet.api.@internal.util.Util;

	/// <summary>
	/// This is the base class of the Smartsheet REST API resources.
	/// 
	/// Thread Safety: This class is thread safe because it is immutable and the underlying SmartsheetImpl is thread safe.
	/// </summary>
	public abstract class AbstractResources
	{
        public class ErrorCode{
            public static readonly ErrorCode BAD_REQUEST = new ErrorCode(HttpStatusCode.BadRequest, typeof(com.smartsheet.api.InvalidRequestException));
            public static readonly ErrorCode NOT_AUTHORIZED = new ErrorCode(HttpStatusCode.Unauthorized, typeof(com.smartsheet.api.AuthorizationException));
            public static readonly ErrorCode FORBIDDEN = new ErrorCode(HttpStatusCode.Forbidden, typeof(com.smartsheet.api.AuthorizationException));
            public static readonly ErrorCode NOT_FOUND = new ErrorCode(HttpStatusCode.NotFound, typeof(com.smartsheet.api.ResourceNotFoundException));
            public static readonly ErrorCode METHOD_NOT_SUPPORTED = new ErrorCode(HttpStatusCode.MethodNotAllowed, typeof(com.smartsheet.api.InvalidRequestException));
            public static readonly ErrorCode INTERNAL_SERVER_ERROR = new ErrorCode(HttpStatusCode.InternalServerError, typeof(com.smartsheet.api.InvalidRequestException));
            public static readonly ErrorCode SERVICE_UNAVAILABLE = new ErrorCode(HttpStatusCode.ServiceUnavailable, typeof(com.smartsheet.api.ServiceUnavailableException));

            public static IEnumerable<ErrorCode> Values
            {
                get{
                    yield return BAD_REQUEST;
                    yield return NOT_AUTHORIZED;
                    yield return FORBIDDEN;
                    yield return NOT_FOUND;
                    yield return METHOD_NOT_SUPPORTED;
                    yield return INTERNAL_SERVER_ERROR;
                    yield return SERVICE_UNAVAILABLE;
                }
            }

            private readonly HttpStatusCode errorCode;
            private readonly Type exceptionClass;

            ErrorCode(HttpStatusCode errorCode, System.Type exceptionClass)
            {
                this.errorCode = errorCode;
				this.exceptionClass = exceptionClass;
            }

            			/// <summary>
			/// Gets the error code.
			/// </summary>
			/// <param name="errorNumber"> the error number </param>
			/// <returns> the error code </returns>
			public static ErrorCode getErrorCode(HttpStatusCode errorNumber)
			{
				foreach (ErrorCode code in ErrorCode.Values)
				{
					if (code.errorCode == errorNumber)
					{
						return code;
					}
				}
	
				return null;
			}

            //            /// <summary>
            //            /// Gets the exception.
            //            /// </summary>
            //            /// <returns> the exception </returns>
            //            /// <exception cref="MemberAccessException"> the instantiation exception </exception>
            //            /// <exception cre="IllegalAccessException"> the illegal access exception </exception>
            public SmartsheetRestException getException()
            {
                return (SmartsheetRestException)Activator.CreateInstance(exceptionClass);
            }

            //            /// <summary>
            //            /// Gets the exception.
            //            /// </summary>
            //            /// <param name="error"> the error </param>
            //            /// <returns> the exception </returns>
            //            /// <exception cref="SmartsheetException"> the smartsheet exception </exception>
            public SmartsheetRestException getException(com.smartsheet.api.models.Error error)
            {
                object[] args = new object[]{error};
                return (SmartsheetRestException)Activator.CreateInstance(exceptionClass, args);
            }
        }

		/// <summary>
		/// Represents the SmartsheetImpl.
		/// 
		/// It will be initialized in constructor and will not change afterwards.
		/// </summary>
		private SmartsheetImpl smartsheet_Renamed;

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="smartsheet"> the smartsheet </param>
		protected internal AbstractResources(SmartsheetImpl smartsheet)
		{
			Util.ThrowIfNull(smartsheet);

			this.smartsheet_Renamed = smartsheet;
		}

		/// <summary>
		/// Get a resource from Smartsheet REST API.
		/// 
		/// Parameters: - path : the relative path of the resource - objectClass : the resource object class
		/// 
		/// Returns: the resource (note that if there is no such resource, this method will throw ResourceNotFoundException
		/// rather than returning null).
		/// 
		/// Exceptions: -
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// @param <T> the generic type </param>
		/// <param name="path"> the relative path of the resource. </param>
		/// <param name="objectClass"> the object class </param>
		/// <returns> the resource </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		protected internal virtual T GetResource<T>(string path, Type objectClass)
		{
			Util.ThrowIfNull(path, objectClass);

			if (path == null || path.Length == 0)
			{
				com.smartsheet.api.models.Error error = new com.smartsheet.api.models.Error();
				error.message = "An empty path was provided.";
				throw new ResourceNotFoundException(error);
			}

			HttpRequest request = null;
			try
			{       
                request = CreateHttpRequest(new Uri(smartsheet_Renamed.baseURI,path), HttpMethod.GET);
			}
			catch (Exception e)
			{
				throw new SmartsheetException(e);
			}

            HttpResponse response = this.smartsheet_Renamed.httpClient.Request(request);
            

			Object obj = null;
            
			switch (response.StatusCode)
			{
                case HttpStatusCode.OK:
					try
					{
                        obj = this.smartsheet_Renamed.jsonSerializer.deserialize<T>(response.entity.getContent());
					}
                    catch (JSONSerializationException ex)
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
				break;
				default:
					HandleError(response);
				break;
			}

			smartsheet_Renamed.httpClient.ReleaseConnection();

			return (T)obj;
		}

		/// <summary>
		/// Create a resource using Smartsheet REST API.
		/// 
		/// Exceptions: 
		///   IllegalArgumentException : if any argument is null, or path is empty string
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// @param <T> the generic type </param>
		/// <param name="path"> the relative path of the resource collections </param>
		/// <param name="objectClass"> the resource object class </param>
		/// <param name="object"> the object to create </param>
		/// <returns> the created resource </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		protected internal virtual T CreateResource<T>(string path, Type objectClass, T @object)
		{
			Util.ThrowIfNull(path, @object);
			Util.ThrowIfEmpty(path);

			HttpRequest request = null;
			try
			{
                request = CreateHttpRequest(new Uri(smartsheet_Renamed.baseURI, path), HttpMethod.POST);
			}
            catch (Exception e)
			{
				throw new SmartsheetException(e);
			}

            request.entity = serializeToEntity<T>(@object);

			HttpResponse response = this.smartsheet_Renamed.httpClient.Request(request);

            Object obj = null;
			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
                    obj = this.smartsheet_Renamed.jsonSerializer.deserializeResult<T>(
                        response.entity.getContent()).result;
					break;
				default:
					HandleError(response);
				break;
			}

			smartsheet_Renamed.httpClient.ReleaseConnection();

			return (T)obj;
		}

		/// <summary>
		/// Update a resource using Smartsheet REST API.
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null, or path is empty string
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// @param <T> the generic type </param>
		/// <param name="path"> the relative path of the resource </param>
		/// <param name="objectClass"> the resource object class </param>
		/// <param name="object"> the object to create </param>
		/// <returns> the updated resource </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		protected internal virtual T UpdateResource<T>(string path, Type objectClass, T @object)
		{
			Util.ThrowIfNull(path, @object);
			Util.ThrowIfEmpty(path);

			HttpRequest request = null;
			try
			{
                request = CreateHttpRequest(new Uri(smartsheet_Renamed.baseURI, path), HttpMethod.PUT);
			}
			catch (Exception e)
			{
				throw new SmartsheetException(e);
			}

            request.entity = request.entity = serializeToEntity<T>(@object);

			HttpResponse response = this.smartsheet_Renamed.httpClient.Request(request);

            Object obj = null;
			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
					//obj = this.smartsheet_Renamed.jsonSerializer.DeserializeResult(objectClass, response.entity.content).result;
                    obj = this.smartsheet_Renamed.jsonSerializer.deserializeResult<T>(response.entity.getContent()).result;
					break;
				default:
					HandleError(response);
				break;
			}

			smartsheet_Renamed.httpClient.ReleaseConnection();

			return (T)obj;
		}

		/// <summary>
		/// List resources using Smartsheet REST API.
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null, or path is empty string
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// @param <T> the generic type </param>
		/// <param name="path"> the relative path of the resource collections </param>
		/// <param name="objectClass"> the resource object class </param>
		/// <returns> the resources </returns>
		/// <exception cref="SmartsheetException"> if an error occurred during the operation </exception>
		protected internal virtual IList<T> ListResources<T>(string path, Type objectClass)
		{
			Util.ThrowIfNull(path, objectClass);
			Util.ThrowIfEmpty(path);

			HttpRequest request = null;
			try
			{
                request = CreateHttpRequest(new Uri(smartsheet_Renamed.baseURI, path), HttpMethod.GET);
			}
			catch (Exception e)
			{
				throw new SmartsheetException(e);
			}

			HttpResponse response = this.smartsheet_Renamed.httpClient.Request(request);

			IList<T> obj = null;
			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
					//obj = this.smartsheet_Renamed.jsonSerializer.DeserializeList(objectClass, response.entity.content);
                    obj = this.smartsheet_Renamed.jsonSerializer.deserializeList<T>(response.entity.getContent());
					break;
				default:
					HandleError(response);
				break;
			}

			smartsheet_Renamed.httpClient.ReleaseConnection();

			return obj;
		}

		/// <summary>
		/// Delete a resource from Smartsheet REST API.
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null, or path is empty string
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ResourceNotFoundException : if the resource can not be found
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// @param <T> the generic type </param>
		/// <param name="path"> the relative path of the resource </param>
		/// <param name="objectClass"> the resource object class </param>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		protected internal virtual void DeleteResource<T>(string path, Type objectClass)
		{
			Util.ThrowIfNull(path, objectClass);
			Util.ThrowIfEmpty(path);

			HttpRequest request = null;
			try
			{
                request = CreateHttpRequest(new Uri(smartsheet_Renamed.baseURI, path), HttpMethod.DELETE);
			}
			catch (Exception e)
			{
				throw new SmartsheetException(e);
			}
			HttpResponse response = this.smartsheet_Renamed.httpClient.Request(request);

			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
                    this.smartsheet_Renamed.jsonSerializer.deserializeResult<T>(response.entity.getContent());
					break;
				default:
					HandleError(response);
				break;
			}

			smartsheet_Renamed.httpClient.ReleaseConnection();
		}

		/// <summary>
		/// Post an object to Smartsheet REST API and receive a list of objects from response.
		/// 
		/// Parameters: - path : the relative path of the resource collections - objectToPost : the object to post -
		/// objectClassToReceive : the resource object class to receive
		/// 
		/// Returns: the object list
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null, or path is empty string
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// @param <T> the generic type </param>
		/// @param <S> the generic type </param>
		/// <param name="path"> the path </param>
		/// <param name="objectToPost"> the object to post </param>
		/// <param name="objectClassToReceive"> the object class to receive </param>
		/// <returns> the list </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		protected internal virtual IList<S> PostAndReceiveList<T, S>(string path, T objectToPost, Type objectClassToReceive)
		{
			Util.ThrowIfNull(path, objectToPost, objectClassToReceive);
			Util.ThrowIfEmpty(path);

			HttpRequest request = null;
			try
			{
                request = CreateHttpRequest(new Uri(smartsheet_Renamed.baseURI, path), HttpMethod.POST);
			}
			catch (Exception e)
			{
				throw new SmartsheetException(e);
			}

            request.entity = serializeToEntity<T>(objectToPost);

			HttpResponse response = this.smartsheet_Renamed.httpClient.Request(request);

			IList<S> obj = null;
			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
                    obj = this.smartsheet_Renamed.jsonSerializer.deserializeListResult<S>(
                        response.entity.getContent()).result;
					break;
				default:
					HandleError(response);
				break;
			}

			smartsheet_Renamed.httpClient.ReleaseConnection();

			return obj;
		}

		/// <summary>
		/// Put an object to Smartsheet REST API and receive a list of objects from response.
		/// 
		/// Exceptions:
		///   IllegalArgumentException : if any argument is null, or path is empty string
		///   InvalidRequestException : if there is any problem with the REST API request
		///   AuthorizationException : if there is any problem with the REST API authorization(access token)
		///   ServiceUnavailableException : if the REST API service is not available (possibly due to rate limiting)
		///   SmartsheetRestException : if there is any other REST API related error occurred during the operation
		///   SmartsheetException : if there is any other error occurred during the operation
		/// </summary>
		/// @param <T> the generic type </param>
		/// @param <S> the generic type </param>
		/// <param name="path"> the relative path of the resource collections </param>
		/// <param name="objectToPut"> the object to put </param>
		/// <param name="objectClassToReceive"> the resource object class to receive </param>
		/// <returns> the object list </returns>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
        protected internal virtual IList<S> PutAndReceiveList<T, S>(string path, T objectToPut, Type objectClassToReceive)
		{
			Util.ThrowIfNull(path, objectToPut, objectClassToReceive);
			Util.ThrowIfEmpty(path);

			HttpRequest request = null;
			try
			{
                request = CreateHttpRequest(new Uri(smartsheet_Renamed.baseURI, path), HttpMethod.PUT);
			}
			catch (Exception e)
			{
				throw new SmartsheetException(e);
			}

            request.entity = serializeToEntity<T>(objectToPut);

			HttpResponse response = this.smartsheet_Renamed.httpClient.Request(request);

			IList<S> obj = null;
			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
                    obj = this.smartsheet_Renamed.jsonSerializer.deserializeListResult<S>( 
                        response.entity.getContent()).result;
					break;
				default:
					HandleError(response);
				break;
			}

			smartsheet_Renamed.httpClient.ReleaseConnection();

			return obj;
		}

		/// <summary>
		/// Create an HttpRequest.
		/// 
		/// Exceptions: Any exception shall be propagated since it's a private method.
		/// </summary>
		/// <param name="uri"> the URI </param>
		/// <param name="method"> the HttpMethod </param>
		/// <returns> the http request </returns>
		protected internal virtual HttpRequest CreateHttpRequest(Uri uri, HttpMethod method)
		{
			HttpRequest request = new HttpRequest();
			request.Uri = uri;
			request.Method = method;

			// Set authorization header 
			request.headers = new Dictionary<string, string>();
			request.headers["Authorization"] = "Bearer " + smartsheet_Renamed.accessToken;

			// Set assumed user
			if (smartsheet_Renamed.assumedUser != null)
			{
				request.headers["Assume-User"] = Uri.EscapeDataString(smartsheet_Renamed.assumedUser);
			}

			return request;
		}

		/// <summary>
		/// Handles an error HttpResponse (non-200) returned by Smartsheet REST API.
		/// 
		/// Exceptions: 
		///   SmartsheetRestException : the exception corresponding to the error
		/// </summary>
		/// <param name="response"> the HttpResponse </param>
		/// <exception cref="SmartsheetException"> the smartsheet exception </exception>
		protected internal virtual void HandleError(HttpResponse response)
		{

			com.smartsheet.api.models.Error error;
			try
			{
                error = this.smartsheet_Renamed.jsonSerializer.deserialize<com.smartsheet.api.models.Error>(
                    response.entity.getContent());
            }
            catch (JSONSerializationException ex)
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
            
			ErrorCode code = ErrorCode.getErrorCode(response.StatusCode);

			if (code == null)
			{
				throw new SmartsheetRestException(error);
			}

			try
			{
				throw code.getException(error);
			}
			catch (System.ArgumentException ex)
			{
				throw new SmartsheetException(ex);
			}
			catch (Exception ex)
			{
				throw new SmartsheetException(ex);
			}
		}


		/// <summary>
		/// Gets the smartsheet.
		/// </summary>
		/// <returns> the smartsheet </returns>
		public virtual SmartsheetImpl Smartsheet
		{
			get
			{
				return smartsheet_Renamed;
			}
			set
			{
				this.smartsheet_Renamed = value;
			}
		}

        protected HttpEntity serializeToEntity<T>(T objectToPost)
        {
            HttpEntity entity = new HttpEntity();
            entity.contentType = "application/json";
            using (StreamWriter writer = new StreamWriter(new MemoryStream()))
            {
                this.smartsheet_Renamed.jsonSerializer.serialize<T>(objectToPost, writer);
                writer.Flush();

                using (StreamReader reader = new StreamReader(writer.BaseStream))
                {
                    entity.Content = reader.ReadToEnd();
                    entity.contentLength = reader.BaseStream.Length;
                }
            }
            return entity;
        }
	}
}