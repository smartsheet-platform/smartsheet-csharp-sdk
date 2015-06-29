using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;
	using Smartsheet.Api.Models;
	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using Group = Smartsheet.Api.Models.Group;

	public class GroupResourcesImplTest : ResourcesImplBase
	{
		GroupResourcesImpl groupResource;

		[SetUp]
		public virtual void SetUp()
		{
			// Create a folder resource
			groupResource = new GroupResourcesImpl(new SmartsheetImpl(
				"http://localhost:9090/2.0/", "accessToken", new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestGroupResourcesImpl()
		{
		}

		[Test]
		public virtual void TestGetGroup()
		{

			// Set a fake response
			server.setResponseBody("../../../TestSDK/resources/getGroup.json");

			Group group = groupResource.GetGroup(123L);

			// Verify results
			Assert.AreEqual("My group", group.Description);
			Assert.AreEqual(1, group.Members.Count);
			Assert.AreEqual("John", group.Members[0].FirstName);
		}

		[Test]
		public virtual void TestUpdateGroup()
		{
			server.setResponseBody("../../../TestSDK/resources/updateFolder.json");

			Group newGroup = new Group();
			newGroup.Name = "New name for folder";
			newGroup.ID = 1486948649985924;

			Group resultGroup = groupResource.UpdateGroup(13L, newGroup);

			Assert.AreEqual(resultGroup.Name, newGroup.Name);
		}

		[Test]
		public virtual void TestDeleteGroup()
		{

			server.setResponseBody("../../../TestSDK/resources/deleteGroup.json");

			groupResource.DeleteGroup(7752230582413188L);
		}

		[Test]
		public virtual void TestListGroups()
		{

			server.setResponseBody("../../../TestSDK/resources/listGroups.json");

			DataWrapper<Group> result = groupResource.ListGroups(new PaginationParameters(false, null, null));
			Assert.AreEqual(1, result.Data.Count);
			Assert.AreEqual("john.doe@smartsheet.com", result.Data[0].Owner);

		}

		[Test]
		public virtual void TestCreateGroup()
		{
			server.setResponseBody("../../../TestSDK/resources/createGroup.json");

			Group newGroup = new Group();
			newGroup.Name = "API-created Group";
			newGroup.Description = "Group created via API";
			newGroup.Members = new List<GroupMember> { new GroupMember { Email = "john.doe@smartsheet.com" } };
			Group createdFolder = groupResource.CreateGroup(newGroup);

			Assert.AreEqual(createdFolder.Name, newGroup.Name);
			Assert.AreEqual(createdFolder.Description, newGroup.Description);
			Assert.AreEqual(createdFolder.Members[0].Email, newGroup.Members[0].Email);
		}

		[Test]
		public virtual void AddGroupMembersToGroup()
		{
			server.setResponseBody("../../../TestSDK/resources/addGroupMember.json");

			IList<GroupMember> newGroupMembers = groupResource.GroupMemberResources().AddGroupMembers(123,
			new List<GroupMember> { new GroupMember { Email = "jane.doe@smartsheet.com" } });

			Assert.AreEqual(newGroupMembers[0].FirstName, "Jane");

			Assert.AreEqual(newGroupMembers[0].ID, 1539725208119172);
		}

	}

}