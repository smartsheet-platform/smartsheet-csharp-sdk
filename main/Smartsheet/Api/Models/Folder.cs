//    #[license]
//    SmartsheetClient SDK for C#
//    %%
//    Copyright (C) 2014 SmartsheetClient
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

using System;
using System.Collections.Generic;

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents a folder.
    /// </summary>
    public class Folder : NamedModel
    {
        /// <summary>
        /// Represents whether a folder is marked as a favorite in the Home folder
        /// </summary>
        private bool? favorite;

        /// <summary>
        /// Represents the child folders contained in the folder.
        /// </summary>
        private IList<Folder> folders;

        /// <summary>
        /// Direct URL to folder
        /// </summary>
        private string permalink;

        /// <summary>
        /// Represents the reports contained in the folder.
        /// </summary>
        private IList<Report> reports;

        /// <summary>
        /// Represents the sheets contained in the folder.
        /// </summary>
        private IList<Sheet> sheets;

        /// <summary>
        /// Represents the Sights contained in the folder.
        /// </summary>
        private IList<Sight> sights;

        /// <summary>
        /// Represents the templates contained in the folder.
        /// </summary>
        private IList<Template> templates;

        /// <summary>
        /// Gets and sets whether this folder is favorited.
        /// </summary>
        /// <returns> the sheets </returns>
        public bool? Favorite
        {
            get { return favorite; }
            set { favorite = value; }
        }

        /// <summary>
        /// Gets the folders contained in this folder.
        /// </summary>
        /// <returns> the folders </returns>
        public IList<Folder> Folders
        {
            get { return folders; }
            set { folders = value; }
        }

        /// <summary>
        /// Gets and sets the permalink of this folder.
        /// </summary>
        /// <returns> the sheets </returns>
        public string Permalink
        {
            get { return permalink; }
            set { permalink = value; }
        }

        /// <summary>
        /// Gets the reports in the folder.
        /// </summary>
        /// <returns> the sheets </returns>
        public IList<Report> Reports
        {
            get { return reports; }
            set { reports = value; }
        }

        /// <summary>
        /// Gets the sheets in the folder.
        /// </summary>
        /// <returns> the sheets </returns>
        public IList<Sheet> Sheets
        {
            get { return sheets; }
            set { sheets = value; }
        }

        /// <summary>
        /// Gets the Sights contained in this folder.
        /// </summary>
        /// <returns> the Sights </returns>
        public IList<Sight> Sights
        {
            get { return sights; }
            set { sights = value; }
        }

        /// <summary>
        /// Gets the templates contained in this folder.
        /// </summary>
        /// <returns> the templates </returns>
        public IList<Template> Templates
        {
            get { return templates; }
            set { templates = value; }
        }

        /// <summary>
        /// A convenience class for setting up a folder with the appropriate fields for updating the folder.
        /// </summary>
        public class UpdateFolderBuilder
        {
            private string folderName;
            private long? id;

            /// <summary>
            /// Sets the required fields for updating a folder.
            /// </summary>
            /// <param name="id">the Id of the folder to update</param>
            /// <param name="name"> the name of the folder, need not be unique </param>
            public UpdateFolderBuilder(long? id, string name)
            {
                this.id = id;
                this.folderName = name;
            }

            /// <summary>
            /// Builds the folder.
            /// </summary>
            /// <returns> the folder </returns>
            public Folder Build()
            {
                Folder folder = new Folder();
                folder.Id = id;
                folder.Name = folderName;
                return folder;
            }
        }

        /// <summary>
        /// A convenience class for setting up a folder with the appropriate fields for creation.
        /// </summary>
        public class CreateFolderBuilder
        {
            private string folderName;

            /// <summary>
            /// Sets the required the fields for creating a folder.
            /// </summary>
            /// <param name="name"> the name of the folder, need not be unique </param>
            public CreateFolderBuilder(string name)
            {
                this.folderName = name;
            }

            /// <summary>
            /// Sets the name of the folder.
            /// </summary>
            /// <param name="name"> the name </param>
            /// <returns> the update folder builder </returns>
            public CreateFolderBuilder SetName(string name)
            {
                this.folderName = name;
                return this;
            }

            /// <summary>
            /// Gets the name.
            /// </summary>
            /// <returns> the name </returns>
            public string GetName()
            {
                return folderName;
            }

            /// <summary>
            /// Builds the folder.
            /// </summary>
            /// <returns> the folder </returns>
            public Folder Build()
            {
                Folder folder = new Folder();
                folder.Name = folderName;
                return folder;
            }
        }
    }
}
