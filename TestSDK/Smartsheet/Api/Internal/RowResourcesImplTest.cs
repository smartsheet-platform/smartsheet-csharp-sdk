using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Internal
{
	using NUnit.Framework;





	using DefaultHttpClient = Smartsheet.Api.Internal.Http.DefaultHttpClient;
	using AccessLevel = Smartsheet.Api.Models.AccessLevel;
	using Cell = Smartsheet.Api.Models.Cell;
	using CellHistory = Smartsheet.Api.Models.CellHistory;
	using LinkType = Smartsheet.Api.Models.LinkType;
	using ObjectInclusion = Smartsheet.Api.Models.ObjectInclusion;
	using Row = Smartsheet.Api.Models.Row;
	using RowEmail = Smartsheet.Api.Models.RowEmail;
	using RowWrapper = Smartsheet.Api.Models.RowWrapper;
	using User = Smartsheet.Api.Models.User;

	public class RowResourcesImplTest : ResourcesImplBase
	{

		private RowResourcesImpl rowResourcesImpl;

		[SetUp]
		public virtual void SetUp()
		{
			rowResourcesImpl = new RowResourcesImpl(new SmartsheetImpl("http://localhost:9090/1.1/", "accessToken", 
				new DefaultHttpClient(), serializer));
		}

		[Test]
		public virtual void TestRowResourcesImpl()
		{
		}
		[Test]
		public virtual void TestGetRow()
		{
			server.setResponseBody("../../../TestSDK/resources/getRowByID.json");

			//IEnumerable<ObjectInclusion> test = new ObjectInclusion[]{ObjectInclusion.TEMPLATES,
			//    ObjectInclusion.DISCUSSIONS, ObjectInclusion.DATA, ObjectInclusion.COLUMNS,
			//    ObjectInclusion.ATTACHMENTS};
			Row row = rowResourcesImpl.GetRow(1234L, new List<ObjectInclusion>((ObjectInclusion[])Enum.
				GetValues(typeof(ObjectInclusion))));

			Assert.True(row.Cells.Count == 1);
			Assert.AreEqual("http://domain.com",row.Cells[0].Link.Url);
			Assert.AreEqual(LinkType.URL,row.Cells[0].Link.Type);
			Assert.Null(row.Cells[0].Link.SheetId);
			Assert.Null(row.Cells[0].Link.ColumnId);
			Assert.Null(row.Cells[0].Link.RowId);
			Assert.True(row.Columns.Count == 2);
			Assert.True(row.AccessLevel == AccessLevel.OWNER);

			server.setResponseBody("../../../TestSDK/resources/getCell.json");
			// Cell can contain a boolean or other type of object
			row = rowResourcesImpl.GetRow(6089772474099588L, new List<ObjectInclusion>((ObjectInclusion[])Enum.
				GetValues(typeof(ObjectInclusion))));
			Assert.AreNotEqual(row.Cells[7].Value, "true");
			Assert.AreEqual(row.Cells[7].Value, true);
		}

		[Test]
		public virtual void TestMoveRow()
		{
			server.setResponseBody("../../../TestSDK/resources/moveRow.json");

			RowWrapper rowWrapper = new RowWrapper();
			rowWrapper.ToTop = true;
			rowWrapper.ParentId = 1234L;
			rowWrapper.SiblingId = 1234L;
			IList<Row> rows = rowResourcesImpl.MoveRow(1234L, rowWrapper);

			Assert.True(rows.Count == 1);
			Assert.True(rows[0].Cells.Count == 1);
		}

		[Test]
		public virtual void TestDeleteRow()
		{
			server.setResponseBody("../../../TestSDK/resources/deleteRow.json");

			rowResourcesImpl.DeleteRow(12345L);
		}

		[Test]
		public virtual void TestSendRow()
		{
			server.setResponseBody("../../../TestSDK/resources/sendRow.json");

			RowEmail email = new RowEmail();
			IList<string> to = new List<string>();
			to.Add("email@email.com");
			email.To = to;
			email.Message = "Test Message";
			email.Subject = "Test Subject";
			email.IncludeAttachments = true;
			email.IncludeDiscussions = true;
			email.CCMe = true;
			rowResourcesImpl.SendRow(1234L, email);
		}

		[Test]
		public virtual void TestUpdateCells()
		{
			server.setResponseBody("../../../TestSDK/resources/updateCell.json");
			IList<Cell> cells = new List<Cell>();
			Cell cell = new Cell();
			cell.ColumnId = 8764071660021636L;
			cell.Value = "Some New Text";
			cells.Add(cell);
			cell.ColumnId = 2110316914993028L;
			cell.Value = "Started";
			cell.Strict = false;
			cells.Add(cell);

			IList<Cell> cellResult = rowResourcesImpl.UpdateCells(1234L, cells);
			Assert.True(cellResult.Count == cells.Count);
			Assert.AreEqual("test","test");
			Assert.True(8764071660021636L == cellResult[0].ColumnId);
		}

		[Test]
		public virtual void TestGetCellHistory()
		{
			server.setResponseBody("../../../TestSDK/resources/getCellHistory.json");

			IList<CellHistory> history = rowResourcesImpl.GetCellHistory(1234L, 123124L);
			Assert.True(history.Count == 2);

			DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).AddSeconds(1391109701000/1000);
			Assert.AreEqual(d, history[0].ModifiedAt);

			User user = new User();
			User newUser = history[0].ModifiedBy;
			Assert.NotNull(newUser);
			user.ID = 2L;

			// Not equal because user id's are not set
			Assert.AreNotEqual(user, history[0].ModifiedBy);

			// Make user id's the same so equals method works
			user.ID = newUser.ID;

			Assert.AreEqual(user, history[0].ModifiedBy);
				Assert.AreEqual(user, history[0].ModifiedBy, "message");
			Assert.AreEqual("Some New Text", history[0].DisplayValue);
		}

		[Test]
		public virtual void TestAttachments()
		{
			Assert.NotNull(rowResourcesImpl.Attachments());
		}

		[Test]
		public virtual void TestDiscussions()
		{
			Assert.NotNull(rowResourcesImpl.Discussions());
		}
	}

}