using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smartsheet.Api;
using Smartsheet.Api.Models;
using System;
using System.Collections.Generic;

namespace TestSDKMockAPI
{
    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void SerializeAttachment()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Attachment");
            Attachment attachment = new Attachment
            {
                Name = "Search Engine",
                Description = "A popular search engine",
                AttachmentType = AttachmentType.LINK,
                Url = "http://www.google.com"
            };
            Attachment resultAttachment = ss.SheetResources.AttachmentResources
                .AttachUrl(sheetId: 1, attachment: attachment);
            Assert.AreEqual("John Doe", resultAttachment.CreatedBy.Name);
        }

        [TestMethod]
        public void SerializeHome()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Home");
            var result = ss.HomeResources.GetHome();
            Assert.AreEqual("editor share sheet", result.Sheets[0].Name);
            Assert.AreEqual("folder sheet", result.Folders[1].Sheets[0].Name);
            Assert.AreEqual("admin report", result.Reports[0].Name);
            Assert.AreEqual("workspace folder folder sheet", result.Workspaces[0].Folders[0].Folders[0].Sheets[0].Name);
            Assert.AreEqual("sight", result.Sights[0].Name);
        }

        [TestMethod]
        public void SerializeGroups()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Groups");
            var group = new Group
            {
                Name = "mock api test group",
                Description = "it's a group",
                Members = new List<GroupMember>
                {
                    new GroupMember { Email = "john.doe@smartsheet.com" },
                    new GroupMember { Email = "jane.doe@smartsheet.com" }
                }
            };
            var result = ss.GroupResources.CreateGroup(group);
            Assert.AreEqual("john.doe@smartsheet.com", result.Members[0].Email);
        }

        [TestMethod]
        public void SerializeDiscussion()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Discussion");
            var discussion = new Discussion
            {
                Comment = new Comment
                {
                    Text = "This is a comment!"
                }
            };
            var result = ss
                .SheetResources
                .RowResources
                .DiscussionResources
                .CreateDiscussion(1, 2, discussion);
            Assert.AreEqual("John Doe", result.Comments[0].CreatedBy.Name);
        }

        [TestMethod]
        public void SerializeContact()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Contact");
            var result = ss.ContactResources.GetContact("ABC");
            Assert.AreEqual("John Doe", result.Name);
        }

        [TestMethod]
        public void SerializeFolder()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Folder");
            var folder = new Folder
            {
                Name = "folder"
            };
            var result = ss.HomeResources.FolderResources.CreateFolder(folder);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public void SerializeColumn()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Column");
            var columns = new List<Column>
            {
                new Column
                {
                    Title = "A Brave New Column",
                    Type = ColumnType.PICKLIST,
                    Options = new List<string>
                    {
                        "option1",
                        "option2",
                        "option3"
                    },
                    Index = 2,
                    Validation = false,
                    Width = 42,
                    Locked = false
                }
            };
            var result = ss.SheetResources.ColumnResources.AddColumns(sheetId: 1, columns: columns);
            Assert.AreEqual(2, result[0].Id);
        }

        [TestMethod]
        public void SerializeUserProfile()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - UserProfile");
            var result = ss.UserResources.GetCurrentUser();
            Assert.AreEqual(2, result.Account.Id);
        }

        [TestMethod]
        public void SerializeWorkspace()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Workspace");
            var workspace = new Workspace
            {
                Name = "A Whole New Workspace"
            };
            var result = ss.WorkspaceResources.CreateWorkspace(workspace);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        // Profile images currently use the wrong field name for image IDs in this scenario
        [Ignore]
        public void SerializeUser()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - User");
            var user = new User
            {
                Email = "john.doe@smartsheet.com",
                Admin = false,
                LicensedSheetCreator = true,
                FirstName = "John",
                LastName = "Doe",
                GroupAdmin = false,
                ResourceViewer = true
            };
            var result = ss.UserResources.AddUser(user);
            Assert.AreEqual(1050, result.ProfileImage.Height);
            Assert.AreEqual("abc", result.ProfileImage.Id);
        }

        [TestMethod]
        public void SerializeSheet()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Sheet");
            var sheet = new Sheet
            {
                Name = "The First Sheet",
                Columns = new List<Column>
                {
                    new Column
                    {
                        Title = "The First Column",
                        Primary = true,
                        Type = ColumnType.TEXT_NUMBER
                    },
                    new Column
                    {
                        Title = "The Second Column",
                        Primary = false,
                        Type = ColumnType.TEXT_NUMBER,
                        SystemColumnType = SystemColumnType.AUTO_NUMBER,
                        AutoNumberFormat = new AutoNumberFormat
                        {
                            Prefix = "{YYYY}-{MM}-{DD}-",
                            Suffix = "-SUFFIX",
                            Fill = "000000"
                        }
                    }
                }
            };
            var result = ss.SheetResources.CreateSheet(sheet);
            Assert.AreEqual(3, result.Columns[1].Id);
        }

        [TestMethod]
        public void SerializeAlternateEmail()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - AlternateEmail");
            var alternateEmails = new List<AlternateEmail>
            {
                new AlternateEmail
                {
                    Email = "not.not.john.doe@smartsheet.com"
                }
            };
            var result = ss.UserResources.AddAlternateEmail(userId: 1, altEmails: alternateEmails);
            Assert.AreEqual(false, result[0].Confirmed);
        }

        [TestMethod]
        // Implementation does not permit 'include' query parameters;
        // nor does it allow deserialization of object values
        [Ignore]
        public void SerializePredecessor()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Predecessor");
            var rows = new List<Row>
            {
                new Row
                {
                    Cells = new List<Cell>
                    {
                        new Cell.AddCellBuilder(2, new {
                            RowId = 3,
                            Type = "FS",
                            Lag = new
                            {
                                ObjectType = "DURATION",
                                Negative = false,
                                Elapsed = false,
                                Weeks = 1.5,
                                Days = 2.5,
                                Hours = 3.5,
                                Minutes = 4.5,
                                Seconds = 5.5,
                                Milliseconds = 6
                            }
                        }).Build()
                    }
                }
            };
            var result = ss.SheetResources.RowResources.AddRows(sheetId: 1, rows: rows);
            Assert.AreEqual(
                "=CALCSTART(Duration17, Start8, Finish8, 0, 300875506)",
                result[0].Cells[2].Formula);
            // Assert.AreEqual(5.5, result[0].Cells[4].ObjectValue.Predecessors.Lag.Seconds);
        }

        [TestMethod]
        public void SerializeIndexResult()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - IndexResult");
            var result = ss.UserResources.ListUsers();
            Assert.AreEqual("John Doe", result.Data[0].Name);
        }

        [TestMethod]
        public void SerializeImage()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Image");
            var result = ss.SheetResources.RowResources.GetRow(sheetId: 1, rowId: 2);
            Assert.AreEqual("puppy.jpg", result.Cells[0].Image.AltText);
        }

        [TestMethod]
        public void SerializeImageUrls()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Image Urls");
            var imageUrlRequests = new List<ImageUrl>
            {
                new ImageUrl
                {
                    ImageId = "abc",
                    Height = 100,
                    Width = 200
                }
            };
            var result = ss.ImageUrlResources.GetImageUrls(imageUrlRequests);
            Assert.AreEqual("https://my-image-url.jpg", result.ImageUrls[0].Url);
        }

        [TestMethod]
        // Implementation does not seem to be able to properly deserialize the response,
        // for reasons currently unknown.
        [Ignore]
        public void SerializeBulkFailure()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - BulkFailure");
            var rows = new List<Row>
            {
                new Row
                {
                    ToBottom = true,
                    Cells = new List<Cell>
                    {
                        new Cell
                        {
                            ColumnId = 2,
                            Value = "Some Value"
                        }
                    }
                },
                new Row
                {
                    ToBottom = true,
                    Cells = new List<Cell>
                    {
                        new Cell
                        {
                            ColumnId = 3,
                            Value = "Some Value"
                        }
                    }
                }
            };
            var result = ss.SheetResources.RowResources.AddRowsAllowPartialSuccess(sheetId: 1, rows: rows);
            Assert.AreEqual("PARTIAL_SUCCESS", result.Message);
            Assert.AreEqual("Some Value", result.Result[0].Cells[0].DisplayValue);
            Assert.AreEqual(1036, result.FailedItems[0].Error.ErrorCode);
        }

        [TestMethod]
        public void SerializeRows()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Rows");
            var rows = new List<Row>
            {
                new Row
                {
                    Expanded = true,
                    Format = ",,,,,,,,4,,,,,,,",
                    Locked = false,
                    Cells = new List<Cell>
                    {
                        new Cell
                        {
                            ColumnId = 2,
                            Value = "url link",
                            Strict = false,
                            Hyperlink = new Hyperlink
                            {
                                Url = "https://google.com"
                            }
                        },
                        new Cell
                        {
                            ColumnId = 3,
                            Value = "sheet id link",
                            Strict = false,
                            Hyperlink = new Hyperlink
                            {
                                SheetId = 4
                            }
                        },
                        new Cell
                        {
                            ColumnId = 5,
                            Value = "report id link",
                            Strict = false,
                            Hyperlink = new Hyperlink
                            {
                                ReportId = 6
                            }
                        }
                    }
                }
            };
            var result = ss.SheetResources.RowResources.AddRows(sheetId: 1, rows: rows);
            Assert.AreEqual("https://app.smartsheet.com/b/home?lx=a", result[0].Cells[1].Hyperlink.Url);
            Assert.AreEqual("https://app.smartsheet.com/b/home?lx=b", result[0].Cells[2].Hyperlink.Url);
        }

        [TestMethod]
        public void SerializeCellLink()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Cell Link");
            var rows = new List<Row>
            {
                new Row
                {
                    Id = 2,
                    Cells = new List<Cell>
                    {
                        new Cell
                        {
                            ColumnId = 3,
                            Value = null,
                            LinkInFromCell = new CellLink
                            {
                                SheetId = 4,
                                RowId = 5,
                                ColumnId = 6
                            }
                        }
                    }
                }
            };
            var result = ss.SheetResources.RowResources.UpdateRows(sheetId: 1,  rows: rows);
            Assert.AreEqual("Linked Sheet Name", result[0].Cells[0].LinkInFromCell.SheetName);
        }

        [TestMethod]
        public void SerializeFavorite()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Favorite");
            var favorites = new List<Favorite>
            {
                new Favorite
                {
                    Type = ObjectType.SHEET,
                    ObjectId = 1
                }
            };
            var result = ss.FavoriteResources.AddFavorites(favorites);
            Assert.AreEqual(ObjectType.SHEET, result[0].Type);
        }

        [TestMethod]
        public void SerializeReport()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Report");
            var result = ss.ReportResources.GetReport(1);
            Assert.AreEqual(11, result.TotalRowCount);
            Assert.AreEqual(AttachmentType.EVERNOTE, result.EffectiveAttachmentOptions[3]);
            Assert.AreEqual(2, result.Columns[0].VirtualId);
            Assert.AreEqual(2, result.Rows[0].Cells[0].VirtualColumnId);
        }

        [TestMethod]
        public void SerializeShare()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Share");
            var shares = new List<Share>
            {
                new Share
                {
                    Email = "john.doe@smartsheet.com",
                    AccessLevel = AccessLevel.VIEWER,
                    Subject = "Check out this sheet",
                    Message = "Let me know what you think. Thanks!",
                    CcMe = true
                }
            };
            var result = ss.SheetResources.ShareResources.ShareTo(objectId: 1, shares: shares, sendEmail: true);
            Assert.AreEqual("abc", result[0].Id);
        }

        [TestMethod]
        public void SerializeSendViaEmail()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Send via Email");
            var email = new SheetEmail
            {
                SendTo = new List<Recipient>
                {
                    new Recipient
                    {
                        Email = "john.doe@smartsheet.com"
                    },
                    new Recipient
                    {
                        GroupId = 2
                    }
                },
                Subject = "Some subject",
                Message = "Some message",
                CcMe = true,
                Format = SheetEmailFormat.PDF,
                FormatDetails = new FormatDetails
                {
                    PaperSize = PaperSize.LETTER
                }
            };
            ss.SheetResources.SendSheet(sheetId: 1, email: email);
        }

        [TestMethod]
        public void SerializeRowEmail()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Row Email");
            var multiRowEmails = new MultiRowEmail
            {
                SendTo = new List<Recipient>
                {
                    new Recipient
                    {
                        GroupId = 2
                    }
                },
                Subject = "Some subject",
                Message = "Some message",
                ColumnIds = new List<long>
                {
                    3
                },
                IncludeAttachments = false,
                IncludeDiscussions = true,
                Layout = "VERTICAL",
                RowIds = new List<long>
                {
                    4
                }
            };
            ss.SheetResources.RowResources.SendRows(sheetId: 1, email: multiRowEmails);
        }

        [TestMethod]
        public void SerializeTemplate()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Template");
            var result = ss.TemplateResources.ListPublicTemplates();
            Assert.AreEqual(100, result.PageSize);
            Assert.AreEqual("Create and customize a new sheet", result.Data[0].Description);
            Assert.AreEqual("Featured Templates", result.Data[0].Categories[0]);
        }

        [TestMethod]
        // Implementation does not treat optional Schedule fields 'lastSentAt' and 'nextSendAt'
        // as optional, causing them to be sent in outgoing requests.
        [Ignore]
        public void SerializeUpdateRequest()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Update Request");
            var updateRequest = new UpdateRequest
            {
                SendTo = new List<Recipient>
                {
                    new Recipient
                    {
                        Email = "john.doe@smartsheet.com"
                    }
                },
                RowIds = new List<long>
                {
                    2
                },
                ColumnIds = new List<long>
                {
                    3
                },
                IncludeAttachments = true,
                IncludeDiscussions = false,
                Subject = "Some subject",
                Message = "Some message",
                CcMe = true,
                Schedule = new Schedule
                {
                    Type = ScheduleType.MONTHLY,
                    StartAt = DateTime.Parse("2018-03-01T19:00:00Z").ToUniversalTime(),
                    EndAt = DateTime.Parse("2018-06-01T00:00:00Z").ToUniversalTime(),
                    DayOrdinal = DayOrdinal.FIRST,
                    DayDescriptors = new List<DayDescriptor>
                    {
                        DayDescriptor.FRIDAY
                    },
                    RepeatEvery = 1
                }
            };
            var result = ss.SheetResources.UpdateRequestResources
                .CreateUpdateRequest(sheetId: 1, updateRequest: updateRequest);
            Assert.AreEqual("Jane Doe", result.SentBy.Name);
            Assert.AreEqual(DateTime.Parse("2018-04-06T18:00:00Z").ToUniversalTime(), result.Schedule.NextSendAt);
        }

        [TestMethod]
        public void SerializeSentUpdateRequests()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Sent Update Requests");
            var result = ss.SheetResources.UpdateRequestResources
                .GetSentUpdateRequest(sheetId: 1, sentUpdateRequestId: 2);
            Assert.AreEqual(3, result.UpdateRequestId);
            Assert.AreEqual("Jane Doe", result.SentBy.Name);
            Assert.AreEqual("john.doe@smartsheet.com", result.SentTo.Email);
            Assert.AreEqual(4, result.RowIds[0]);
            Assert.AreEqual(5, result.ColumnIds[0]);
        }

        [TestMethod]
        // Implementation does not correctly handle date-level granularity, and instead sends full
        // date-times.
        [Ignore]
        public void SerializeSheetSettings()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Sheet Settings");
            var sheet = new Sheet
            {
                UserSettings = new SheetUserSettings
                {
                    CriticalPathEnabled = true,
                    DisplaySummaryTasks = true
                },
                ProjectSettings = new ProjectSettings
                {
                    WorkingDays = new List<string>
                    {
                        "MONDAY",
                        "TUESDAY"
                    },
                    NonWorkingDays = new List<DateTime>
                    {
                        DateTime.Parse("2018-04-04"),
                        DateTime.Parse("2018-05-05"),
                        DateTime.Parse("2018-06-06")
                    },
                    LengthOfDay = 23.5f
                }
            };
            var result = ss.SheetResources.UpdateSheet(sheet);
            Assert.AreEqual("https://app.smartsheet.com/b/home?lx=a", result.Permalink);
            Assert.AreEqual(true, result.UserSettings.CriticalPathEnabled);
            Assert.AreEqual(DateTime.Parse("2018-04-04"), result.ProjectSettings.NonWorkingDays[0]);
        }

        [TestMethod]
        public void SerializeContainerDestination()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Container Destination");
            var destination = new ContainerDestination
            {
                DestinationType = DestinationType.HOME,
                NewName = "Copy of Some Folder"
            };
            var result = ss.FolderResources.CopyFolder(folderId: 1, destination: destination);
            Assert.AreEqual("https://app.smartsheet.com/b/home?lx=a", result.Permalink);
        }

        [TestMethod]
        public void SerializeCrossSheetReference()
        {
            SmartsheetClient ss = HelperFunctions.SetupClient("Serialization - Cross Sheet Reference");
            var crossSheetReference = new CrossSheetReference
            {
                Name = "Some Cross Sheet Reference",
                SourceSheetId = 2,
                StartRowId = 3,
                EndRowId = 4,
                StartColumnId = 5,
                EndColumnId = 6
            };
            var result = ss.SheetResources.CrossSheetReferenceResources
                .CreateCrossSheetReference(sheetId: 1, crossSheetReference: crossSheetReference);
            Assert.AreEqual("Some Cross Sheet Reference", result.Name);
        }
    }
}
