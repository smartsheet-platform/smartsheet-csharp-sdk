using System.Collections.Generic;
using Smartsheet.Api;
using Smartsheet.Api.Models;

namespace IntegrationTestSDK
{
    public class TestResources
    {
        protected SmartsheetClient smartsheet;

        public SmartsheetClient CreateClient()
        {
            smartsheet = new SmartsheetBuilder().SetMaxRetryTimeout(30000).Build();
            return smartsheet;
        }

        public Sheet CreateSheetObject()
        {
            Column colA = new Column.AddColumnBuilder("Favorite", null, ColumnType.CHECKBOX)
                .SetSymbol(Symbol.STAR)
                .Build();
            Column colB = new Column.AddColumnBuilder("Primary Column", null, ColumnType.TEXT_NUMBER)
                .Build();
            colB.Primary = true;
            Column colC = new Column.AddColumnBuilder("Col 3", null, ColumnType.PICKLIST)
                .SetOptions(new List<string> { "Not Started", "Started", "Completed" })
                .Build();
            Column colD = new Column.AddColumnBuilder("Date", null, ColumnType.DATE)
                .Build();
            Sheet sheet = new Sheet.CreateSheetBuilder("CSharp SDK Test", new List<Column> { colA, colB, colC, colD })
                .Build();
            return sheet;
        }

        public Folder CreateFolderHome()
        {
            Folder folder = new Folder.CreateFolderBuilder("CSharp SDK Test").Build();
            Folder newFolderHome = smartsheet.HomeResources.FolderResources.CreateFolder(folder);
            return newFolderHome;
        }

        public Workspace CreateWorkspace(string name)
        {
            Workspace newWorkspace = smartsheet.WorkspaceResources.CreateWorkspace(new Workspace.CreateWorkspaceBuilder(name).Build());
            return newWorkspace;
        }

        public void DeleteFolder(long folderId)
        {
            smartsheet.FolderResources.DeleteFolder(folderId);
        }

        public void DeleteSheet(long sheetId)
        {
            smartsheet.SheetResources.DeleteSheet(sheetId);
        }

        public void DeleteWorkspace(long workspaceId)
        {
            smartsheet.WorkspaceResources.DeleteWorkspace(workspaceId);
        }
    }
}