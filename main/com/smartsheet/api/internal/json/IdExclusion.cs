using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace com.smartsheet.api.@internal.json
{
    class IdExclusion : DefaultContractResolver
    {
        public new static readonly IdExclusion Instance = new IdExclusion();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (property.PropertyName ==  "id")
            {
                property.ShouldSerialize = 
                    instance =>
                    {
                        return false;
                    };
            }

            return property;
        }
    }
}
