//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2019 SmartsheetClient
//    %%
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//        
//            http://www.apache.org/licenses/LICENSE-2.0
//        
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

namespace Smartsheet.Api.Models
{
    public enum EventAction
    {
        CREATE,
        UPDATE,
        LOAD,
        DELETE,
        PURGE,
        RESTORE,
        RENAME,
        ACTIVATE,
        DEACTIVATE,
        EXPORT,
        MOVE,
        MOVE_ROW,
        COPY_ROW,
        SAVE_AS_NEW,
        SAVE_AS_TEMPLATE,
        ADD_PUBLISH,
        REMOVE_PUBLISH,
        ADD_SHARE,
        REMOVE_SHARE,
        ADD_SHARE_MEMBER,
        REMOVE_SHARE_MEMBER,
        ADD_WORKSPACE_SHARE,
        REMOVE_WORKSPACE_SHARE,
        ADD_MEMBER,
        REMOVE_MEMBER,
        TRANSFER_OWNERSHIP,
        CREATE_CELL_LINK,
        REMOVE_SHARES,
        TRANSFER_OWNED_GROUPS,
        TRANSFER_OWNED_ITEMS,
        DOWNLOAD_SHEET_ACCESS_REPORT,
        DOWNLOAD_USER_LIST,
        DOWNLOAD_LOGIN_HISTORY,
        DOWNLOAD_PUBLISHED_ITEMS_REPORT,
        UPDATE_MAIN_CONTACT,
        IMPORT_USERS,
        BULK_UPDATE,
        LIST_SHEETS,
        REQUEST_BACKUP,
        CREATE_RECURRING_BACKUP,
        UPDATE_RECURRING_BACKUP,
        DELETE_RECURRING_BACKUP,
        REMOVE_FROM_GROUPS,
        SEND_AS_ATTACHMENT,
        SEND_ROW,
        SEND,
        SEND_COMMENT,
        SEND_INVITE,
        DECLINE_INVITE,
        ACCEPT_INVITE,
        SEND_PASSWORD_RESET,
        REMOVE_FROM_ACCOUNT,
        ADD_TO_ACCOUNT,
        AUTHORIZE,
        REVOKE
    }
}