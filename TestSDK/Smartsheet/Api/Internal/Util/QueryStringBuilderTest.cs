using System;
using NUnit.Framework;
using Smartsheet.Api.Internal.Utility;

namespace TestSDK.Smartsheet.Api.Internal.Util
{
    class QueryStringBuilderTest
    {
        private QueryStringBuilder _builder;
        [SetUp]
        public virtual void SetUp()
        {
            _builder = new QueryStringBuilder();
        }

        [Test]
        public virtual void WhenNoParametersAreAdded_QueryStringIsEmpty()
        {
            //assert
            Assert.True(_builder.QueryString.Length == 0);
        }

        [Test]
        public virtual void AddParamenter_WhenNoParametersWereAdded_QueryStringFirstCharacterIsquestionMark()
        {
            const string parameterName = "testParameter";
            const string parameterValue = "testParameterValue";
            //act
            _builder.AddParameter(parameterName, parameterValue);
            //assert
            Assert.AreEqual(_builder.QueryString[0], '?');
        }

        [Test]
        public virtual void AddParamenter_OneEmptyValueParameter_ParameterNameIsAfterQuestionMark()
        {
            const string parameterName = "testParameter";
            //act
            _builder.AddParameter(parameterName, string.Empty);
            //assert
            Assert.AreEqual(_builder.QueryString.IndexOf(parameterName, StringComparison.Ordinal), 1);
        }

        [Test]
        public virtual void AddParamenter_OneEmptyValueParameterAdded_LastCharacterIsEquals()
        {
            const string parameterName = "testParameter";
            // should be ?testParameter=

            //act
            _builder.AddParameter(parameterName, string.Empty);
            //assert
            Assert.True(_builder.QueryString.EndsWith("="));
        }

        [Test]
        public void AddParamenter_NotEmptyValueParameterAdded_CharacterBeforeValueIsEquals()
        {
            const string parameterName = "testParameter";
            const string parameterValue = "testParameterValue";
            // should be ?testParameter=testParameterValue
            const int expectedEqualsIndex = 14;

            //act
            _builder.AddParameter(parameterName, parameterValue);
            //assert
            Assert.AreEqual(_builder.QueryString[expectedEqualsIndex], '=');
        }

        [Test]
        public void AddParamenter_NotEmptyValueParameterAdded_ValueIsAtEndOfQueryString()
        {
            const string parameterName = "testParameter";
            const string parameterValue = "testParameterValue";
            //act
            _builder.AddParameter(parameterName, parameterValue);
            //assert
            Assert.True(_builder.QueryString.EndsWith(parameterValue));
        }

        [Test]
        public void AddParameter_FirstParameterNotEmptySecondParameterEmptyValue_EndsWidtEqul()
        {
            const string parameterName = "testParameter";
            const string parameterValue = "testParameterValue";
            const string secondParameterName = "secondParameter";
            _builder.AddParameter(parameterName, parameterValue);
            //act
            _builder.AddParameter(secondParameterName, string.Empty);
            //assert
            Assert.True(_builder.QueryString.EndsWith("="));
            
        }
        [Test]
        public void AddParameter_FirstParameterNotEmptySecondParameterEmptyValue_CharacterBeforeEndParameterIsAmpersand()
        {
            const string parameterName = "testParameter";
            const string parameterValue = "testParameterValue";
            const string secondParameterName = "secondParameter";
            _builder.AddParameter(parameterName, parameterValue);
            //act
            _builder.AddParameter(secondParameterName, string.Empty);
            //assert
            Assert.True(_builder.QueryString.EndsWith("&secondParameter="));
        }
    }
}
