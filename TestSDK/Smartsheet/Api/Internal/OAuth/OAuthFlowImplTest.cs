namespace Smartsheet.Api.Internal.OAuth
{
	using NUnit.Framework;
	 using System;


	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using HttpClient = Smartsheet.Api.Internal.Http.HttpClient;
	using HttpClientException = Smartsheet.Api.Internal.Http.HttpClientException;
	using JsonSerializer = Smartsheet.Api.Internal.Json.JsonSerializer;
	using AccessDeniedException = Smartsheet.Api.OAuth.AccessDeniedException;
	using AccessScope = Smartsheet.Api.OAuth.AccessScope;
	using InvalidOAuthClientException = Smartsheet.Api.OAuth.InvalidOAuthClientException;
	using InvalidScopeException = Smartsheet.Api.OAuth.InvalidScopeException;
	using OAuthAuthorizationCodeException = Smartsheet.Api.OAuth.OAuthAuthorizationCodeException;
	using OAuthTokenException = Smartsheet.Api.OAuth.OAuthTokenException;
	using Token = Smartsheet.Api.OAuth.Token;
	using UnsupportedResponseTypeException = Smartsheet.Api.OAuth.UnsupportedResponseTypeException;
	 using Smartsheet.Api.Internal.Json;
	 using System.Collections.Generic;

	public class OAuthFlowImplTest
	{

		internal OAuthFlowImpl oauth;
		internal string clientId = "clientID";
		internal string clientSecret = "clientSecret";
		internal string redirectURL = "redirectURL";
		internal string authorizationURL = "authorizationURL";
		internal string tokenURL = "tokenURL";
		internal HttpClient httpClient = new DefaultHttpClient();
		internal JsonSerializer json = new JsonNetSerializer();

		internal HttpTestServer server;

		[TearDown]
		public virtual void BaseTearDown()
		{
			server.Stop();
		}

		[SetUp]
		public virtual void SetUp()
		{
			oauth = new OAuthFlowImpl(clientId,clientSecret,redirectURL,authorizationURL,tokenURL, httpClient, json);

			// Setup test server
			server = new HttpTestServer();
			server.Start();

			// Setup the serializer
			JsonNetSerializer serializer = new JsonNetSerializer();
			serializer.failOnUnknownProperties = Newtonsoft.Json.MissingMemberHandling.Error;
		}

		[Test]
		public virtual void TestOAuthFlowImpl()
		{
			Assert.AreEqual(clientId,oauth.ClientId);
			Assert.AreEqual(clientSecret, oauth.ClientSecret);
			Assert.AreEqual(redirectURL, oauth.RedirectURL);
			Assert.AreEqual(authorizationURL, oauth.AuthorizationURL);
			Assert.AreEqual(tokenURL, oauth.TokenURL);
			Assert.AreEqual(httpClient, oauth.HttpClient);
			Assert.AreEqual(json, oauth.JsonSerializer);
		}

		[Test]
		public virtual void TestNewAuthorizationURL()
		{
			try
			{
				oauth.NewAuthorizationURL(null, null);
				Assert.Fail("Should have thrown an exception.");
			}
			catch (System.ArgumentException)
			{
				// Expected
			}

			oauth.NewAuthorizationURL(new List<AccessScope>((AccessScope[])Enum.GetValues(typeof(AccessScope))), null);
			string authURL = oauth.NewAuthorizationURL(new List<AccessScope>((AccessScope[])Enum.GetValues(
				typeof(AccessScope))), "state");

			Assert.AreEqual("authorizationURL?response_type=code&client_id=clientID&redirect_uri=redirectURL&state=state&scope=READ_SHEETS" +
			"%20WRITE_SHEETS%20SHARE_SHEETS%20DELETE_SHEETS%20CREATE_SHEETS%20READ_USERS%20READ_CONTACTS%20ADMIN_USERS%20ADMIN_SHEETS%20ADMIN_WORKSPACES", authURL);
		}

		[Test]
		public virtual void TestExtractAuthorizationResult()
		{

			try
			{
				oauth.ExtractAuthorizationResult(null);
				Assert.Fail("Should have thrown an exception.");
			}
			catch (System.ArgumentException)
			{
				// Expected
			}

			try
			{
				oauth.ExtractAuthorizationResult("");
				Assert.Fail("Should have thrown an exception.");
			}
			catch (System.ArgumentException)
			{
				// Expected
			}

			// Null query
			try
			{
				oauth.ExtractAuthorizationResult("http://smartsheet.com");
				Assert.Fail("Should have thrown an exception");
			}
			catch (OAuthAuthorizationCodeException)
			{
				// Expected
			}

			try
			{
				oauth.ExtractAuthorizationResult("http://smartsheet.com?error=access_denied");
				Assert.Fail("Should have thrown an exception");
			}
			catch (AccessDeniedException)
			{
				// Expected
			}

			try
			{
				oauth.ExtractAuthorizationResult("http://smartsheet.com?error=unsupported_response_type");
				Assert.Fail("Should have thrown an exception");
			}
			catch (UnsupportedResponseTypeException)
			{
				// Expected
			}

			try
			{
				oauth.ExtractAuthorizationResult("http://smartsheet.com?error=invalid_scope");
				Assert.Fail("Should have thrown an exception");
			}
			catch (InvalidScopeException)
			{
				// Expected
			}

			try
			{
				oauth.ExtractAuthorizationResult("http://smartsheet.com?error=something_undefined");
				Assert.Fail("Should have thrown an exception");
			}
			catch (OAuthAuthorizationCodeException)
			{
				// Expected
			}

			// No valid parameters (empty result)
			oauth.ExtractAuthorizationResult("http://smartsheet.com?a=b");

			// Empty Error (empty result)
			oauth.ExtractAuthorizationResult("http://smartsheet.com?error=");

			// All parameters set (good response)
			oauth.ExtractAuthorizationResult("http://smartsheet.com?code=code&state=state&expires_in=10");
		}

		[Test]
		public virtual void TestObtainNewToken()
		{
			server.Status = System.Net.HttpStatusCode.Forbidden;
			server.ContentType = "application/x-www-form-urlencoded";
			server.setResponseBody("../../../TestSDK/resources/OAuthException.json");
			server.setResponseBody("{\"errorCode\": \"1004\", " + "\"message\": \"You are not authorized to perform this action.\"}");

			oauth.TokenURL = "http://localhost:9090/1.1/token";
			// 403 access forbidden
			try
			{
				oauth.ObtainNewToken(oauth.ExtractAuthorizationResult("http://localhost?a=b"));
				Assert.Fail("Exception should have been thrown.");
			}
			catch (OAuthTokenException)
			{
				// Expected
			}
		}



		[Test]
		public virtual void TestRefreshToken()
		{
			oauth.TokenURL = "https://api.smartsheet.com/2.0/token";

			Token token = new Token();
			token.AccessToken = "AccessToken";
			token.ExpiresInSeconds = 10L;
			token.RefreshToken = "refreshToken";
			token.TokenType = "tokenType";
			Assert.AreEqual("AccessToken", token.AccessToken);
			Assert.AreEqual("refreshToken", token.RefreshToken);
			Assert.AreEqual(10L, token.ExpiresInSeconds);
			Assert.AreEqual("tokenType", token.TokenType);

			try
			{
				oauth.RefreshToken(token);
				Assert.Fail("An expection should have been thrown.");
			}
			catch (InvalidOAuthClientException)
			{
				// Expected
			}
		}

	}

}