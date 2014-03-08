using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Smartsheet.Api.Internal.Json
{
    internal class ContractResolver : DefaultContractResolver
    {
        public ContractResolver()
        {
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            if (property.PropertyName.ToLower().Equals("id"))
            {
                property.ShouldSerialize = (object instance) => false;
            }
            return property;
        }

        protected override string ResolvePropertyName(string propertyName)
        {
            string str;
            str = ((string.IsNullOrEmpty(propertyName) || char.IsLower(propertyName, 0) ? false : 
                propertyName.Length >= 2) ? string.Concat(propertyName.Substring(0, 1).ToLower(), 
                propertyName.Substring(1)) : propertyName);
            return str;
        }
    }
}