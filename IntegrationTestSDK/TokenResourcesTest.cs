using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System.Collections.Generic;
using Smartsheet.Api.OAuth;
using System.Configuration;
using System.Diagnostics;

namespace IntegrationTestSDK
{
    [TestClass]
    public class TokenResourcesTest
    {
        [Ignore]
        [TestMethod]
        public void TestTokenResources()
        {
            UseOAuthFlow();
            UseTokenResources();
        }

        private static void UseOAuthFlow()
        {
            OAuthFlow oauth = new OAuthFlowBuilder()
                     .SetClientId("1tziajulcsbqsswgy37")
                     .SetClientSecret("sxouqll7zluvzmact3")
                     .SetRedirectURL("https://www.google.com")
                     .Build();

            string url = oauth.NewAuthorizationURL
            (
                new Smartsheet.Api.OAuth.AccessScope[]
                {
                    Smartsheet.Api.OAuth.AccessScope.READ_SHEETS,
                    Smartsheet.Api.OAuth.AccessScope.WRITE_SHEETS,
                    Smartsheet.Api.OAuth.AccessScope.SHARE_SHEETS,
                    Smartsheet.Api.OAuth.AccessScope.DELETE_SHEETS,
                    Smartsheet.Api.OAuth.AccessScope.CREATE_SHEETS,
                    Smartsheet.Api.OAuth.AccessScope.READ_USERS,
                    Smartsheet.Api.OAuth.AccessScope.ADMIN_USERS,
                    Smartsheet.Api.OAuth.AccessScope.ADMIN_SHEETS,
                    Smartsheet.Api.OAuth.AccessScope.ADMIN_WORKSPACES,
                },
                "key=Test"
            );

            // Take the user to the following URL
            Debug.WriteLine(url);

            // After the user accepts or declines the authorization they are taken to the redirect URL. The URL of the page
            // the user is taken to can be used to generate an authorization RequestResult object.
            string authorizationResponseURL = "https://www.google.com/?code=yn8kl1kvruh31uj&expires_in=599957&state=key%3DTest";

            // On this page pass in the full URL of the page to create an authorizationResult object  
            AuthorizationResult authResult = oauth.ExtractAuthorizationResult(authorizationResponseURL);

            // Get the token from the authorization result
            Token token = oauth.ObtainNewToken(authResult);

            Assert.IsTrue(token.AccessToken == "ACCESS_TOKEN");

            Token tokenRefreshed = oauth.RefreshToken(token);
            Assert.IsTrue(token.AccessToken != "ACCESS_TOKEN");

            oauth.RevokeToken(token);
            SmartsheetClient smartsheet = new SmartsheetBuilder().SetAccessToken(token.AccessToken).Build();
            try
            {
                smartsheet.SheetResources.ListSheets(null, null);
                Assert.Fail();
            }
            catch
            {

            }
        }

        private static void UseTokenResources()
        {
            SmartsheetClient smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();
            try
            {
                smartsheet.TokenResources.GetAccessToken();
                Assert.Fail();
            }
            catch
            {

            }
            try
            {
                smartsheet.TokenResources.RefreshAccessToken();
                Assert.Fail();
            }
            catch
            {

            }
            smartsheet.TokenResources.RevokeAccessToken();
            try
            {
                smartsheet.SheetResources.ListSheets(null, null);
                Assert.Fail();
            }
            catch
            {

            }
        }
    }
}