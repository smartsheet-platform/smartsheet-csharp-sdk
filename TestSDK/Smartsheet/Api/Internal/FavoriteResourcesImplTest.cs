using System.Collections.Generic;
using System;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;

	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Api.Models;
	using System.IO;

	public class FavoriteResourcesImplTest : ResourcesImplBase
	{
		internal FavoriteResourcesImpl favoriteResource;

		[SetUp]
		public virtual void SetUp()
		{
			// Create a folder resource
			favoriteResource = new FavoriteResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestListFavorites()
		{
			server.setResponseBody("../../../TestSDK/resources/listFavorites.json");

			PaginatedResult<Favorite> result = favoriteResource.ListFavorites(null);

			Assert.IsTrue(result.Data[0].Type == ObjectType.SHEET);
			Assert.IsTrue(result.Data[0].ObjectId == 5897312590423940);
			Assert.IsTrue(result.Data[1].Type == ObjectType.FOLDER);
			Assert.IsTrue(result.Data[1].ObjectId == 1493728255862660);

		}

		[Test]
		public virtual void TestAddFavorites()
		{
			server.setResponseBody("../../../TestSDK/resources/addFavorites.json");

			Favorite fav1 = new Favorite.AddFavoriteBuilder(ObjectType.SHEET, 8400677765441412).Build();
			IList<Favorite> favorites = favoriteResource.AddFavorites(new Favorite[] { fav1 });

			Assert.IsTrue(favorites[0].Type == ObjectType.SHEET);
			Assert.IsTrue(favorites[0].ObjectId == 8400677765441412);
		}

		[Test]
		public virtual void TestRemoveFavorites()
		{
			server.setResponseBody("../../../TestSDK/resources/deleteFavorites.json");

			favoriteResource.RemoveFavorites(ObjectType.FOLDER, new long[] { 117117117, 343434343 });
		}
	}

}