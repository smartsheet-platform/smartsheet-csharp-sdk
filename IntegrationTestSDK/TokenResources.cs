using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Collections.Generic;
using Smartsheet.Api.OAuth;
using System.Configuration;

namespace IntegrationTestSDK
{
	[TestClass]
	public class TokenResourcesTest
	{

		[TestMethod]
		public void TestTokenResources()
		{

			OAuthFlow oauth = new OAuthFlowBuilder().SetClientId("1tziajulcsbqsswgy37").SetClientSecret("sxouqll7zluvzmact3").SetRedirectURL("smartsheet.com").Build();
			
			//oauth.ObtainNewToken(authorizationResult);
			//oauth.RefreshToken(token);
			//oauth.RevokeTokenAccess(token);
		}
	}
}