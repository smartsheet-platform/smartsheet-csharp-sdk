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
using System.Text;

namespace Smartsheet.Api.Internal.Utility
{
    public sealed class QueryStringBuilder
    {
        private readonly StringBuilder _querryString;
        public QueryStringBuilder()
        {
            _querryString = new StringBuilder();
        }

        public void AddParameter<T>(string name, T value)
        {
            _querryString.AppendFormat(_querryString.Length == 0 ? "?{0}={1}" : "&{0}={1}", name, value);
        }
        public string QueryString { get { return _querryString.ToString(); } }

    }
}
