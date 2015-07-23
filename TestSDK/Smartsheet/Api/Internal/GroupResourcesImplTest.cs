using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;

	public class GroupResourcesImplTest : ResourcesImplBase
	{
		GroupResourcesImpl groupResources;

		[SetUp]
		public virtual void SetUp()
		{
			// Create a folder resource
			groupResources = new GroupResourcesImpl(new SmartsheetImpl(
				"http://localhost:9090/1.1/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestGetGroup()
		{

			// Set a fake response
			server.setResponseBody("../../../TestSDK/resources/getGroup.json");

			Group group = groupResources.GetGroup(123L);

			// Verify results
			Assert.AreEqual("Group 1", group.Name);
			Assert.AreEqual("john.doe@smartsheet.com", group.Owner);
			Assert.AreEqual("John Doe", group.Members[0].Name);
		}

		[Test]
		public virtual void TestUpdateGroup()
		{
			server.setResponseBody("../../../TestSDK/resources/updateGroup.json");

			Group groupToUpdate = new Group.UpdateGroupBuilder().SetName("Renamed Group").SetDescription("Some new description").Build();

			Group updatedGroup = groupResources.UpdateGroup(56464654, groupToUpdate);

			Assert.AreEqual(groupToUpdate.Name, updatedGroup.Name);
			Assert.AreEqual(groupToUpdate.Description, updatedGroup.Description);
			Assert.AreEqual(4583173393803140, updatedGroup.OwnerId);

		}

		[Test]
		public virtual void TestListGroups()
		{

			server.setResponseBody("../../../TestSDK/resources/listGroups.json");

			DataWrapper<Group> result = groupResources.ListGroups(new PaginationParameters(false, 100, 1));

			Assert.IsTrue(result.Data.Count == result.TotalCount);
			Assert.IsTrue(result.Data[0].Id == 4583173393803140);
			Assert.IsTrue(result.Data[0].Name == "Group 1");
			Assert.IsTrue(result.Data[0].Description == "My group");
			Assert.IsTrue(result.Data[0].OwnerId == 2331373580117892);
		}

		[Test]
		public virtual void TestCreateGroup()
		{
			server.setResponseBody("../../../TestSDK/resources/createGroup.json");

			GroupMember newMember = new GroupMember.AddGroupMemberBuilder("john.doe@smartsheet.com").Build();
			GroupMember[] members = new GroupMember[] { newMember };
			Group newGroup = new Group.CreateGroupBuilder("API-created Group", "Group created via API").SetMembers(members).Build();

			Group createdGroup = groupResources.CreateGroup(newGroup);

			Assert.AreEqual(newGroup.Name, createdGroup.Name);
			Assert.AreEqual(newGroup.Description, createdGroup.Description);
			Assert.AreEqual(newGroup.Members[0].Email, createdGroup.Members[0].Email);
			Assert.AreEqual(4583173393803140, createdGroup.Members[0].Id);

		}

	}

}