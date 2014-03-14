namespace Smartsheet.Api.Internal.OAuth
{
	using NUnit.Framework;


	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using HttpClient = Smartsheet.Api.Internal.Http.HttpClient;
	using HttpClientException = Smartsheet.Api.Internal.Http.HttpClientException;
	using JSONSerializerException = Smartsheet.Api.Internal.Json.JSONSerializerException;
	using JacksonJsonSerializer = Smartsheet.Api.Internal.Json.JacksonJsonSerializer;
	using JsonSerializer = Smartsheet.Api.Internal.Json.JsonSerializer;
	using AccessDeniedException = Smartsheet.Api.OAuth.AccessDeniedException;
	using AccessScope = Smartsheet.Api.OAuth.AccessScope;
	using InvalidOAuthClientException = Smartsheet.Api.OAuth.InvalidOAuthClientException;
	using InvalidScopeException = Smartsheet.Api.OAuth.InvalidScopeException;
	using OAuthAuthorizationCodeException = Smartsheet.Api.OAuth.OAuthAuthorizationCodeException;
	using OAuthTokenException = Smartsheet.Api.OAuth.OAuthTokenException;
	using Token = Smartsheet.Api.OAuth.Token;
	using UnsupportedResponseTypeException = Smartsheet.Api.OAuth.UnsupportedResponseTypeException;

	public class OAuthFlowImplTest
	{

		internal OAuthFlowImpl oauth;
		internal string clientId = "clientID";
		internal string clientSecret = "clientSecret";
		internal string redirectURL = "redirectURL";
		internal string authorizationURL = "authorizationURL";
		internal string tokenURL = "tokenURL";
		internal HttpClient httpClient = new DefaultHttpClient();
		internal JsonSerializer json = new JacksonJsonSerializer();

		internal HttpTestServer server;

//ORIGINAL LINE: @After public void baseTearDown() throws Exception
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
			server.port = 9090;
			server.Start();

			// Setup the serializer
			JacksonJsonSerializer serializer = new JacksonJsonSerializer();
			serializer.failOnUnknownProperties = true;
		}

		[Test]
		public virtual void TestOAuthFlowImpl()
		{

			Assert.AreEqual(clientId,oauth.clientId);
			Assert.AreEqual(clientSecret, oauth.clientSecret);
			Assert.AreEqual(redirectURL, oauth.redirectURL);
			Assert.AreEqual(authorizationURL, oauth.authorizationURL);
			Assert.AreEqual(tokenURL, oauth.tokenURL);
			Assert.AreEqual(httpClient, oauth.httpClient);
			Assert.AreEqual(json, oauth.jsonSerializer);
		}

		[Test]
		public virtual void TestNewAuthorizationURL()
		{
			try
			{
				oauth.newAuthorizationURL(null, null);
				Assert.Fail("Should have thrown an exception.");
			}
			catch (System.ArgumentException)
			{
				// Expected
			}

			oauth.newAuthorizationURL(EnumSet.of(AccessScope.READ_SHEETS), null);
			string authURL = oauth.newAuthorizationURL(EnumSet.of(AccessScope.READ_SHEETS), "state");

			Assert.AreEqual("authorizationURL?scope=READ_SHEETS&response_type=code&redirect_uri=redirectURL&state=state&" + "client_id=clientID", authURL);
		}

		[Test]
		public virtual void TestExtractAuthorizationResult()
		{

			try
			{
				oauth.extractAuthorizationResult(null);
				Assert.Fail("Should have thrown an exception.");
			}
			catch (System.ArgumentException)
			{
				// Expected
			}

			try
			{
				oauth.extractAuthorizationResult("");
				Assert.Fail("Should have thrown an exception.");
			}
			catch (System.ArgumentException)
			{
				// Expected
			}

			// Null query
			try
			{
				oauth.extractAuthorizationResult("http://smartsheet.com");
				Assert.Fail("Should have thrown an exception");
			}
			catch (OAuthAuthorizationCodeException)
			{
				// Expected
			}

			try
			{
				oauth.extractAuthorizationResult("http://smartsheet.com?error=access_denied");
				Assert.Fail("Should have thrown an exception");
			}
			catch (AccessDeniedException)
			{
				// Expected
			}

			try
			{
				oauth.extractAuthorizationResult("http://smartsheet.com?error=unsupported_response_type");
				Assert.Fail("Should have thrown an exception");
			}
			catch (UnsupportedResponseTypeException)
			{
				// Expected
			}

			try
			{
				oauth.extractAuthorizationResult("http://smartsheet.com?error=invalid_scope");
				Assert.Fail("Should have thrown an exception");
			}
			catch (InvalidScopeException)
			{
				// Expected
			}

			try
			{
				oauth.extractAuthorizationResult("http://smartsheet.com?error=something_undefined");
				Assert.Fail("Should have thrown an exception");
			}
			catch (OAuthAuthorizationCodeException)
			{
				// Expected
			}

			// No valid parameters (empty result)
			oauth.extractAuthorizationResult("http://smartsheet.com?a=b");

			// Empty Error (empty result)
			oauth.extractAuthorizationResult("http://smartsheet.com?error=");

			// All parameters set (good response)
			oauth.extractAuthorizationResult("http://smartsheet.com?code=code&state=state&expires_in=10");
		}

		[Test]
		public virtual void TestObtainNewToken()
		{
			server.status = 403;
			server.contentType = "application/x-www-form-urlencoded";
			server.ResponseBody = "../../../TestSDK/resources/OAuthException.json";
			server.ResponseBody = "{\"errorCode\": \"1004\", " + "\"message\": \"You are not authorized to perform this action.\"}";

			oauth.tokenURL = "http://localhost:9090/1.1/token";
			// 403 access forbidden
			try
			{
				oauth.obtainNewToken(oauth.extractAuthorizationResult("http://localhost?a=b"));
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
			oauth.tokenURL = "https://api.smartsheet.com/1.1/token";

			Token token = new Token();
			token.accessToken = "AccessToken";
			token.expiresInSeconds = 10L;
			token.refreshToken = "refreshToken";
			token.tokenType = "tokenType";
			Assert.AreEqual("AccessToken", token.accessToken);
			Assert.AreEqual("refreshToken", token.refreshToken);
			Assert.AreEqual(10L, token.expiresInSeconds);
			Assert.AreEqual("tokenType", token.tokenType);

			try
			{
				oauth.refreshToken(token);
				Assert.Fail("An expection should have been thrown.");
			}
			catch (InvalidOAuthClientException)
			{
				// Expected
			}
		}

	}

}