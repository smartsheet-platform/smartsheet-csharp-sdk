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
//    Unless required by applicable law or agreed To in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//    %[license]

namespace Smartsheet.Api.Models
{
    /// <summary>
    /// Represents the scope of a share. For use with the <see cref="ShareResources.ListShares(long, PaginationParameters, ShareScope)"/>.
    /// </summary>
    /// <remarks>
    /// See http://smartsheet-platform.github.io/api-docs/#share-object and http://smartsheet-platform.github.io/api-docs/#list-sheet-shares for more information.
    /// </remarks>
    public struct ShareScope
    {
        public static readonly ShareScope Empty = new ShareScope();

        public static readonly ShareScope Item = new ShareScope("ITEM");
        public static readonly ShareScope Workspace = new ShareScope("WORKSPACE");

        private readonly string _value;

        public ShareScope(string value)
        {
            _value = value;
        }

        public bool Equals(ShareScope obj)
        {
            return 0 == string.CompareOrdinal(_value, obj._value);
        }

        public override bool Equals(object obj)
        {
            return obj is ShareScope ? this.Equals((ShareScope)obj) : false;
        }

        public override int GetHashCode()
        {
            return _value != null ? _value.GetHashCode() : base.GetHashCode();
        }

        public override string ToString()
        {
            return _value != null ? _value : base.ToString();
        }
    }
}